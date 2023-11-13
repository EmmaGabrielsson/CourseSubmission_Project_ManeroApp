using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    [Route("Wishlist")]
    public class WishlistController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }

}
