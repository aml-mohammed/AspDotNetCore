using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        [Route("/Account")]
        public IActionResult Details()
        {
            var model = new AccountDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult BasicInfo(AccountDetailsViewModel model)
        {
          
                return RedirectToAction(nameof(Details));

           
        }

        [HttpPost]
        public IActionResult AddressInfo(AccountDetailsViewModel model)
        {

            return RedirectToAction(nameof(Details));


        }
    }
}
