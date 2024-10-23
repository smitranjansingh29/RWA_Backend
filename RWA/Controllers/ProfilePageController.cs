using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RWA.Data;
using RWA.Models;
using System.IO;
using System.Threading.Tasks;

namespace RWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePageController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProfilePageController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // Method to handle file uploads
        private async Task<string?> UploadFile(IFormFile? file)
        {
            if (file == null) return null;

            // Check for allowed MIME types (you can add more as needed)
            var allowedFileTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedFileTypes.Contains(file.ContentType))
            {
                throw new InvalidOperationException("Unsupported file type.");
            }

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }


        // POST: api/ProfilePage
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateProfilePage([FromForm] ProfilePage profilePage, IFormFile? coverPhotoFile, IFormFile? profilePhotoFile)
        {
            // Ensure that TenantIdOriginal exists in the TenantDetails table
            var tenantDetails = await _context.TenantDetails
                .FirstOrDefaultAsync(t => t.TenantIdOriginal == profilePage.TenantIdOriginal);

            if (tenantDetails == null)
            {
                return NotFound("Tenant with this TenantIdOriginal not found.");
            }

            // Check if profilePage already exists for this TenantIdOriginal
            var existingProfilePage = await _context.ProfilePages
                .FirstOrDefaultAsync(pp => pp.TenantIdOriginal == profilePage.TenantIdOriginal);

            if (existingProfilePage != null)
            {
                // Update existing profile
                existingProfilePage.Interests = profilePage.Interests;
                existingProfilePage.Bio = profilePage.Bio;
                existingProfilePage.Work = profilePage.Work;
                existingProfilePage.Location = profilePage.Location;

                // Handle file uploads for updates
                if (coverPhotoFile != null)
                {
                    existingProfilePage.CoverPhoto = await UploadFile(coverPhotoFile);
                }

                if (profilePhotoFile != null)
                {
                    existingProfilePage.ProfilePhoto = await UploadFile(profilePhotoFile);
                }

                // Update tenant details link
                existingProfilePage.TenantDetails = tenantDetails;

                // Save the changes
                _context.ProfilePages.Update(existingProfilePage);
                await _context.SaveChangesAsync();

                return Ok(existingProfilePage);
            }

            // This part will only execute if there is no existing profile page
            // Upload new cover photo and profile photo if new profile
            profilePage.CoverPhoto = await UploadFile(coverPhotoFile);
            profilePage.ProfilePhoto = await UploadFile(profilePhotoFile);

            // Link tenant details
            profilePage.TenantDetails = tenantDetails;

            // Add the new profile page details
            _context.ProfilePages.Add(profilePage);
            await _context.SaveChangesAsync();

            return Ok(profilePage);
        }



        // PUT: api/ProfilePage/{tenantIdOriginal}
        [HttpPut("{tenantIdOriginal}")]
        public async Task<IActionResult> UpdateProfilePage(string tenantIdOriginal, [FromForm] ProfilePage updatedProfilePage, IFormFile? coverPhotoFile, IFormFile? profilePhotoFile)
        {
            // Find the profile page by TenantIdOriginal
            var profilePage = await _context.ProfilePages
                .FirstOrDefaultAsync(pp => pp.TenantIdOriginal == tenantIdOriginal);

            if (profilePage == null)
            {
                return NotFound("Profile page not found.");
            }

            // Update fields
            profilePage.Interests = updatedProfilePage.Interests;
            profilePage.Bio = updatedProfilePage.Bio;
            profilePage.Work = updatedProfilePage.Work;
            profilePage.Location = updatedProfilePage.Location;

            // Handle file uploads
            if (coverPhotoFile != null)
            {
                profilePage.CoverPhoto = await UploadFile(coverPhotoFile);
            }
            if (profilePhotoFile != null)
            {
                profilePage.ProfilePhoto = await UploadFile(profilePhotoFile);
            }

            // Save changes
            await _context.SaveChangesAsync();

            return Ok(profilePage);
        }



        // GET: api/ProfilePage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfilePage>>> GetAllProfilePages()
        {
            var profilePages = await _context.ProfilePages.Include(pp => pp.TenantDetails).ToListAsync();
            return Ok(profilePages);
        }

        // GET: api/ProfilePage/{tenantIdOriginal}
        [HttpGet("{tenantIdOriginal}")]
        public async Task<ActionResult<ProfilePage>> GetProfilePageByTenantIdOriginal(string tenantIdOriginal)
        {
            var profilePage = await _context.ProfilePages
                .Include(pp => pp.TenantDetails)
                    .ThenInclude(td => td.Tenant)  // Include the Tenant navigation property
                .FirstOrDefaultAsync(pp => pp.TenantIdOriginal == tenantIdOriginal);

            if (profilePage == null)
            {
                return NotFound("Profile page not found for the given TenantIdOriginal.");
            }

            // Generate URLs for cover photo and profile photo
            var baseUrl = $"{Request.Scheme}://{Request.Host.Value}/uploads/";

            if (!string.IsNullOrEmpty(profilePage.CoverPhoto))
            {
                profilePage.CoverPhoto = baseUrl + profilePage.CoverPhoto;
            }

            if (!string.IsNullOrEmpty(profilePage.ProfilePhoto))
            {
                profilePage.ProfilePhoto = baseUrl + profilePage.ProfilePhoto;
            }

            return Ok(profilePage);
        }



        /*      // GET: api/ProfilePage/tenant/{tenantIdOriginal}
              [HttpGet("tenant/{tenantIdOriginal}")]
              public async Task<ActionResult<ProfilePage>> GetProfilePageByTenantIdOriginal(string tenantIdOriginal)
              {
                  var profilePage = await _context.ProfilePages.Include(pp => pp.TenantDetails)
                      .FirstOrDefaultAsync(pp => pp.TenantIdOriginal == tenantIdOriginal);

                  if (profilePage == null)
                  {
                      return NotFound("Profile page not found for the given TenantIdOriginal.");
                  }

                  return Ok(profilePage);
              }

              */
    }
}
