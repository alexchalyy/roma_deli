using System.ComponentModel.DataAnnotations;

/*

The provided code defines a class named RegisterViewModel in C#. This class is typically used in ASP.NET Core applications to represent the data required for a user to register an account. It serves as a model for the registration form, encapsulating the necessary properties and their validation attributes.

The RegisterViewModel class contains several properties that capture user information during the registration process. Each property is decorated with data annotation attributes that enforce validation rules and provide metadata for the properties. These attributes ensure that the user input meets specific criteria before the data is processed.

The FirstName and LastName properties are strings that represent the user's first and last names, respectively. Both properties are decorated with the [Required] attribute, indicating that these fields are mandatory and must be provided by the user. The [Display(Name = "First Name")] and [Display(Name = "Last Name")] attributes specify the display names for these properties in the user interface.

The Email property is a string that represents the user's email address. It is decorated with the [Required] and [EmailAddress] attributes, ensuring that this field is mandatory and that the value entered is in a valid email address format. The [Display(Name = "Email")] attribute sets the display name for this property in the user interface.

The PhoneNumber property is a string that represents the user's phone number. It is marked with the [Required] and [Phone] attributes, making it a mandatory field and ensuring that the value entered is in a valid phone number format. The [Display(Name = "Phone Number")] attribute sets the display name for this property in the user interface.

The Address, City, State, and ZipCode properties are strings that represent the user's address details. Each of these properties is decorated with the [Required] attribute, indicating that these fields are mandatory. The [Display(Name = "Address")], [Display(Name = "City")], [Display(Name = "State")], and [Display(Name = "Zip Code")] attributes specify the display names for these properties in the user interface.

The Password property is a string that represents the user's password. It is marked with the [Required] and [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)] attributes, making it a mandatory field and ensuring that the password is between 6 and 100 characters long. The [DataType(DataType.Password)] attribute specifies that this property should be treated as a password, which typically means that the input will be masked (e.g., displayed as asterisks) in the user interface. The [Display(Name = "Password")] attribute sets the display name for this property in the user interface.

The ConfirmPassword property is a string that represents the confirmation of the user's password. It is decorated with the [DataType(DataType.Password)] and [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] attributes, ensuring that this field is treated as a password and that its value matches the value of the Password property. The [Display(Name = "Confirm password")] attribute sets the display name for this property in the user interface.

Overall, the RegisterViewModel class is a comprehensive model for capturing and validating user input during the registration process in an ASP.NET Core application. It ensures that all necessary information is provided and meets specific validation criteria, promoting a smooth and error-free registration experience for users.

Written by Alex Chalyy on 2/14/2025.

*/

namespace AuthApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}