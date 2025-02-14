/*

The provided code defines a class named ApplicationUser that inherits from the IdentityUser class. This class is typically used in ASP.NET Core applications to extend the default user model provided by ASP.NET Core Identity. By inheriting from IdentityUser, ApplicationUser gains all the properties and methods necessary for user authentication and management, such as UserName, Email, PasswordHash, and more.

In addition to the inherited properties, the ApplicationUser class defines several custom properties to store additional user information. These properties include FirstName, LastName, Address, City, State, and ZipCode. Each of these properties is a string and represents specific details about the user. For example, FirstName and LastName store the user's first and last names, respectively, while Address, City, State, and ZipCode store the user's address details.

By adding these custom properties, the ApplicationUser class allows the application to capture and store more detailed information about users beyond the default properties provided by IdentityUser. This can be particularly useful for applications that require additional user information for personalization, communication, or other purposes. Overall, the ApplicationUser class provides a flexible and extensible way to manage user data in an ASP.NET Core application.

Written by Alex Chalyy on 2/14/2025.

*/

using Microsoft.AspNetCore.Identity;

namespace AuthApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}