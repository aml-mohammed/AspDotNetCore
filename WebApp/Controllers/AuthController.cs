using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {

        [Route("/SignUp")]
        public IActionResult SignUp()
        {
            var viewmodel = new SignUpViewModel();
            return View(viewmodel);
        }
        [Route("/SignUp")]
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
       
              return  RedirectToAction(nameof(SignIn));
        }

        [Route("/SignIn")]
        public IActionResult SignIn()
        {
            var viewmodel = new SignInViewModel();
            return View(viewmodel);
        }
        [Route("/SignIn")]
        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.ErrorMesssage = "Invalid Email or Password";
            return RedirectToAction("Account","Index");
        }
    }
}
