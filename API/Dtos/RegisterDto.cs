using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
        public byte[] ProfilePicture { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
