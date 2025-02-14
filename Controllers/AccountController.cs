using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AuthApp.Models;
using AuthApp.ViewModels;
using System.Threading.Tasks;

/*

The provided code defines an AccountController class in an ASP.NET Core application, which is responsible for handling user account-related actions such as registration, login, and logout. This controller uses ASP.NET Core Identity to manage user authentication and authorization.

The AccountController class has two private fields: _userManager and _signInManager. These fields are instances of UserManager<ApplicationUser> and SignInManager<ApplicationUser>, respectively. The UserManager is used to manage user accounts, while the SignInManager handles user sign-in operations. The constructor of the AccountController class takes these two dependencies as parameters and assigns them to the private fields.

The Register action methods handle user registration. The [HttpGet] version of the Register method simply returns the registration view. The [HttpPost] version of the Register method takes a RegisterViewModel as a parameter, which contains the user input from the registration form. If the model state is valid, a new ApplicationUser object is created and populated with the data from the RegisterViewModel. The UserManager.CreateAsync method is then called to create the user in the database. If the user creation is successful, the user is signed in using the SignInManager.SignInAsync method, and the user is redirected to the home page. If there are any errors during user creation, they are added to the model state and displayed to the user.

The Login action methods handle user login. The [HttpGet] version of the Login method returns the login view. The [HttpPost] version of the Login method takes a LoginViewModel as a parameter, which contains the user input from the login form. If the model state is valid, the SignInManager.PasswordSignInAsync method is called to sign in the user with the provided email and password. If the login is successful, the user is redirected to the home page. If the login fails, an error message is added to the model state and displayed to the user.

The Logout action method handles user logout. It is decorated with the [HttpPost] attribute, indicating that it should be called via an HTTP POST request. The SignInManager.SignOutAsync method is called to sign out the user, and the user is redirected to the home page.

Overall, the AccountController class provides essential functionality for managing user accounts in an ASP.NET Core application, including registration, login, and logout, using the ASP.NET Core Identity framework.

Written by Alex Chalyy on 2/14/2025.

*/

namespace AuthApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    Console.WriteLine($"Error: {error.Description}");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine($"Login failed: {result}");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}