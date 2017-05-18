using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamScreen.Data.Entities;

namespace TeamScreen.Controllers
{
    public class PhotoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PhotoController(UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<FileContentResult> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return GetFallBackPhoto();

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user?.UserPhoto == null)
                return GetFallBackPhoto();

            return new FileContentResult(user.UserPhoto, "image/jpeg");
        }

        private FileContentResult GetFallBackPhoto()
        {
            var fileName = Path.Combine(_hostingEnvironment.WebRootPath, "images\\fallback_photo.png");
            var content = System.IO.File.ReadAllBytes(fileName);

            return File(content, "image/png");
        }
    }
}