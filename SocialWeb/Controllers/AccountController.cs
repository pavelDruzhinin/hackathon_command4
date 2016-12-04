using System.Web.Mvc;
using System.Web.Security;
using SocialWeb.Services;
using SocialWeb.ViewModels;
using SocialWeb.Models;
using SocialWeb.DataAccess;
using System.Linq;

namespace SocialWeb.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (_accountService.Login(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                var db = new SocialWebContext();
                User user = db.Users.FirstOrDefault(x => x.Login == model.Login);
                return RedirectToAction("Details", "Users", new { id = user.Id });
            }

            ModelState.AddModelError("", "Имя пользователя и пароль были введены неверно. Либо ваш пользователь не зарегистрирован.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}