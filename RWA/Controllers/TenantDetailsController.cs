using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWA.Data;
using RWA.Models;
using RWA.Services;
using System.IO;
using System.Threading.Tasks;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantDetailsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly SmtpService _smtpService;

        public TenantDetailsController(DataContext context, IWebHostEnvironment environment, SmtpService smtpService)
        {
            _context = context;
            _environment = environment;
            _smtpService = smtpService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTenantDetails([FromForm] TenantDetails tenantDetails, IFormFile? tenPOIFile = null, IFormFile? casteCertFile = null, 
            IFormFile? deedCopyFile = null, IFormFile? proofDOBDocFile = null, IFormFile? tenPOAFile = null, IFormFile? tenPhotoFile = null) // Mark these as nullable
        {
            // Ensure that TenantIdOriginal exists in the Tenant table
            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == tenantDetails.TenantIdOriginal);

            if (tenant == null)
            {
                return NotFound("Tenant with this TenantIdOriginal not found.");
            }

            // File upload handler function
            async Task<string?> UploadFile(IFormFile? file)
            {
                if (file == null) return null;

                // Ensure the uploads directory exists
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique file name and save file
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return fileName;
            }

            // Handle file uploads for each field
            tenantDetails.TenPOI = await UploadFile(tenPOIFile);
            tenantDetails.CasteCert = await UploadFile(casteCertFile);
            tenantDetails.DeedCopy = await UploadFile(deedCopyFile);
            tenantDetails.ProofDOBDoc = await UploadFile(proofDOBDocFile);
            tenantDetails.TenPOA = await UploadFile(tenPOAFile);
            tenantDetails.TenPhoto = await UploadFile(tenPhotoFile);

            // Link the existing tenant to the tenant details
            tenantDetails.Tenant = tenant;

            // Add the tenant details to the context
            _context.TenantDetails.Add(tenantDetails);
            await _context.SaveChangesAsync();

            return Ok(tenantDetails);
        }

        [HttpPost("send-pdf/{tenantIdOriginal}")]
        public async Task<IActionResult> SendPdfByEmail(string tenantIdOriginal)
        {
            // Retrieve tenant details by tenantIdOriginal
            var tenantDetails = await _context.TenantDetails
                .Include(t => t.Tenant)
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == tenantIdOriginal);

            if (tenantDetails == null)
            {
                return NotFound("Tenant details not found.");
            }

            // Generate PDF
            var pdfFilePath = await GenerateTenantDetailsPdf(tenantDetails);

            // Collect attachments (uploaded files)
            var attachments = new List<string>();

            if (!string.IsNullOrEmpty(tenantDetails.TenPOI))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.TenPOI));
            if (!string.IsNullOrEmpty(tenantDetails.CasteCert))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.CasteCert));
            if (!string.IsNullOrEmpty(tenantDetails.DeedCopy))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.DeedCopy));
            if (!string.IsNullOrEmpty(tenantDetails.ProofDOBDoc))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.ProofDOBDoc));
            if (!string.IsNullOrEmpty(tenantDetails.TenPOA))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.TenPOA));
            if (!string.IsNullOrEmpty(tenantDetails.TenPhoto))
                attachments.Add(Path.Combine(_environment.WebRootPath, "uploads", tenantDetails.TenPhoto));

            // Add the generated PDF to attachments
            attachments.Add(pdfFilePath);

            // Send email with all attachments
            var emailSubject = "Tenant Membership Application";
            var emailMessage = "Dear Tenant, please find your membership application form and related documents attached.";
            await _smtpService.SendEmailWithAttachmentsAsync(tenantDetails.Tenant.TenMail, emailSubject, emailMessage, attachments);

            return Ok("PDF and attachments emailed successfully.");
        }


        private async Task<string> GenerateTenantDetailsPdf(TenantDetails tenantDetails)
        {
            var pdfDirectory = Path.Combine(_environment.WebRootPath, "pdfs");
            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            var pdfFilePath = Path.Combine(pdfDirectory, $"{tenantDetails.TenantIdOriginal}_MembershipForm.pdf");

            using (var fs = new FileStream(pdfFilePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Add title and introductory paragraph
                document.Add(new Paragraph("Dear Sir,\n\nI wish to apply for admission as a member of Imperial Gardens Condominium Association.\n\nMy brief particulars are as under:\n"));

                // Create table for particulars (Sr. No., Subject, Particular)
                var table = new PdfPTable(3);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10, 45, 45 });

                // Add table header
                table.AddCell(new PdfPCell(new Phrase("Sr. No.")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Subject")) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase("Particular")) { HorizontalAlignment = Element.ALIGN_CENTER });

                // Add particulars rows
                AddTableRow(table, "1", "Name of the Applicant", tenantDetails.Tenant.TenName);
                AddTableRow(table, "2", "Father’s / Husband’s Name", tenantDetails.NameOfTenFather);
                AddTableRow(table, "3", "Permanent Address", tenantDetails.TenPerAddress);
                AddTableRow(table, "4", "Correspondence Address", tenantDetails.TenCorAddress);
                AddTableRow(table, "5", "Date of Birth", tenantDetails.TenDOB?.ToString("yyyy-MM-dd"));
                AddTableRow(table, "6", "Occupation", tenantDetails.TenOcc);
                AddTableRow(table, "7", "Phone No. with Code", tenantDetails.Tenant.TenPhoneNum);
                AddTableRow(table, "8", "Email ID", tenantDetails.Tenant.TenMail);
                AddTableRow(table, "9", "PAN No. (attach self-attested copy, if available)", tenantDetails.TenPAN);
                AddTableRow(table, "10", "Caste (restricted to any caste or community)", tenantDetails.TenCaste);
                AddTableRow(table, "11", "Aadhar", tenantDetails.TenAdhar);
                AddTableRow(table, "12", "Police Verification", tenantDetails.TenPoliceVer);

                // Add table to the document
                document.Add(table);

                // Certification section
                document.Add(new Paragraph("\n2. I certify that:\n"));
                document.Add(new Paragraph("(i) I unconditionally subscribe to the aims & objects of the Society and contribute towards the attainment of the same.\n"));
                document.Add(new Paragraph("(ii) I will abide by the Byelaws of the Society, as applicable and amended from time to time.\n"));
                document.Add(new Paragraph("(iii) I have not been convicted of an offence involving moral turpitude involving imprisonment.\n"));

                // Enclosures section
                document.Add(new Paragraph("\n3. I am enclosing herewith the following Documents:\n"));
                var enclosureList = new List();
                enclosureList.Add(new ListItem($"(i) Copy of {tenantDetails.TenPOI} towards proof of Identity."));
                enclosureList.Add(new ListItem($"(ii) Copy of {tenantDetails.TenPOA} towards proof of Address."));
                enclosureList.Add(new ListItem($"(iii) Copy of {tenantDetails.ProofDOBDoc} towards proof of date of birth."));
                enclosureList.Add(new ListItem($"(iv) Copy of {tenantDetails.CasteCert} towards proof of Identity."));
                enclosureList.Add(new ListItem($"(v) DD/Pay Order/ Cheque No. {tenantDetails.MemFeesNumber}, dated {tenantDetails.DateOfMemFee}, for Rs {tenantDetails.AmtOfMemFee}. Drawn in favor of {tenantDetails.MemFav} towards membership fee."));
                enclosureList.Add(new ListItem($"(vi) DD/Pay Order/ Cheque No. {tenantDetails.AnnFeesNumber}, dated {tenantDetails.DateOfAnnFee}, for Rs {tenantDetails.AmtOfAnnFee}. Drawn in favor of {tenantDetails.AnnFav} towards Annual Subscription Fee for the Year {tenantDetails.AnnYear}."));
                enclosureList.Add(new ListItem("(vii) Two passport size and one stamp size photographs."));
                enclosureList.Add(new ListItem($"(viii) 1-15 pages photocopy of conveyance deed.{tenantDetails.DeedCopy}"));
                enclosureList.Add(new ListItem("(ix) Rs 100 cheque for membership fee."));

                document.Add(enclosureList);

                // Admission request
                document.Add(new Paragraph("\n4. I request you to kindly admit me as a __________________ member of the Society.\nThanking you,\n"));
                document.Add(new Paragraph("Yours faithfully,\n\nDated: __________\nPlace: __________\n\n(Signature of the Applicant)\n"));

                // Recommendation section
                document.Add(new Paragraph("\n5. Recommendations of a regular member of the Society (if provided in the byelaws):\n"));
                document.Add(new Paragraph($"I recommend admission of Sh. {tenantDetails.MemName} s/o {tenantDetails.MemFatherName}, aged {tenantDetails.MemAge} years, r/o {tenantDetails.MemAddress}, as {tenantDetails.DecisionMemberType} member of the Society.\n"));
                var recommendationTable = new PdfPTable(2);
                recommendationTable.AddCell(new PdfPCell(new Phrase("Signature of the Member")) { HorizontalAlignment = Element.ALIGN_CENTER });
                recommendationTable.AddCell(new PdfPCell(new Phrase("Name of the Member")) { HorizontalAlignment = Element.ALIGN_CENTER });
                recommendationTable.AddCell(new PdfPCell(new Phrase("______________________")));
                recommendationTable.AddCell(new PdfPCell(new Phrase(tenantDetails.RMemName)));
                document.Add(recommendationTable);
                document.Add(new Paragraph($"Membership No.: {tenantDetails.RMemNumber}\nDate: {tenantDetails.RDate}\nPlace: {tenantDetails.RPlace}\n"));

                // Decision of the Governing Body
                document.Add(new Paragraph("\n6. Decision of the Governing Body:\n"));
                document.Add(new Paragraph($"Sh. {tenantDetails.DecisionMemberName} s/o {tenantDetails.DecisionMemberFather}, aged {tenantDetails.DecisionMemberAge} years, r/o {tenantDetails.DecisionMemberAddress}, is admitted as type {tenantDetails.DecisionMemberType} of the Society w.e.f. _______ under membership No. {tenantDetails.ResolutionNumber} vide resolution bearing No. {tenantDetails.ResolutionNumber} in the meeting of the Governing Body held on {tenantDetails.DecisionDate}.\n"));
                document.Add(new Paragraph("He may be issued an Identity Card of the Society & his name may be entered in the Register of Members.\n"));
                document.Add(new Paragraph("Secretary/ President\nDated: __________\nPlace: __________\n"));

                document.Close();
            }

            return pdfFilePath;
        }

        private void AddTableRow(PdfPTable table, string srNo, string subject, string particular)
        {
            table.AddCell(new PdfPCell(new Phrase(srNo)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase(subject)) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase(particular ?? "N/A")) { HorizontalAlignment = Element.ALIGN_LEFT });
        }


        [HttpGet("{tenIdOri}")]
        public async Task<IActionResult> GetTenantDetailsByTenantIdOriginal(string tenIdOri)
        {
            // Use Include to load related Tenant data
            var tenantDetails = await _context.TenantDetails
                .Include(t => t.Tenant)  // Eagerly load the related Tenant entity
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == tenIdOri);

            if (tenantDetails == null)
            {
                return NotFound("Tenant details not found.");
            }

            return Ok(tenantDetails);  // Return tenant details along with tenant data
        }
    }
}
