/*

The provided code defines a class named LoginViewModel in C#. This class is typically used in ASP.NET Core applications to represent the data required for a user to log in. It serves as a model for the login form, encapsulating the necessary properties and their validation attributes.

The LoginViewModel class contains three properties: Email, Password, and RememberMe. Each property is decorated with data annotation attributes that enforce validation rules and provide metadata for the properties.

The Email property is a string that represents the user's email address. It is decorated with the [Required] attribute, indicating that this field is mandatory and must be provided by the user. Additionally, the [EmailAddress] attribute ensures that the value entered is a valid email address format.

The Password property is also a string and represents the user's password. Similar to the Email property, it is marked with the [Required] attribute, making it a mandatory field. The [DataType(DataType.Password)] attribute specifies that this property should be treated as a password, which typically means that the input will be masked (e.g., displayed as asterisks) in the user interface.

The RememberMe property is a boolean that indicates whether the user wants the application to remember their login information for future sessions. It is decorated with the [Display(Name = "Remember me?")] attribute, which sets the display name for this property in the user interface to "Remember me?".

Overall, the LoginViewModel class is a simple yet essential part of the login functionality in an ASP.NET Core application, providing a structured way to capture and validate user input for the login process.


Written by Alex Chalyy on 2/14/2025.

*/

using System.ComponentModel.DataAnnotations;

namespace AuthApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}