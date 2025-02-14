using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthApp.Models;

namespace AuthApp.Controllers;

/*

The provided code defines a HomeController class in an ASP.NET Core application. This class inherits from the Controller base class, which provides the necessary functionality for handling HTTP requests and returning responses. The HomeController class is responsible for managing the actions related to the home page of the application.

The class contains a private readonly field _logger of type ILogger<HomeController>. This field is used for logging information, warnings, errors, and other messages. The HomeController constructor takes an ILogger<HomeController> parameter and assigns it to the _logger field. This allows the controller to use dependency injection to obtain an instance of the logger, which is configured in the application's dependency injection container.

The Index action method is a simple method that returns the default view for the home page. When a user navigates to the root URL of the application, this method is called, and it returns the Index view, which is typically the main landing page of the application.

The Privacy action method is similar to the Index method. It returns the Privacy view when a user navigates to the /Home/Privacy URL. This view is typically used to display the privacy policy of the application.

The Error action method is decorated with the [ResponseCache] attribute, which disables caching for the response. This method returns the Error view, passing an instance of the ErrorViewModel class to the view. The ErrorViewModel contains a RequestId property, which is set to the current activity ID or the HTTP context trace identifier. This information is useful for debugging and tracking errors that occur in the application.

Overall, the HomeController class provides basic functionality for handling requests to the home page, privacy policy page, and error page of the ASP.NET Core application. It uses dependency injection to obtain a logger instance and includes methods for returning views that correspond to different parts of the application.

Written by Alex Chalyy on 2/14/2025.

*/

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
