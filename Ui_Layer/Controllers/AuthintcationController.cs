using Business.BusinessImplemint;
using Business.BusinessInterface;
using Doman.Model;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ui_Layer.Models;
using Ui_Layer.Models.RegisterModel;

namespace Ui_Layer.Controllers
{
   
    public class AuthintcationController : Controller
    {
        private readonly IUser _UserService;

        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomer _Cust;

        public AuthintcationController(IUser userService, ApplicationDbContext db,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ICustomer customer)

        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _UserService = userService;
            _Cust = customer;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login_Actions(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginView.Email);
                if (user != null)
                {
                    var res = await _signInManager.PasswordSignInAsync(user, loginView.Password, false, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                        return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Login");

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register_Action(RegisterView registerView)
        {
            var user = new User
            {
                Name = registerView.Neme,
                UserName = registerView.Email,
                Email=registerView.Email,
            };

            var results = await _userManager.CreateAsync(user, registerView.Password);
            if (results.Succeeded)
            {
             await _signInManager.SignInAsync(user, isPersistent: false);
           
                return RedirectToAction("Index", "Customer");
            }
            return RedirectToAction("Register");
        }

        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
