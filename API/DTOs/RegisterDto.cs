using System.ComponentModel.DataAnnotations;

namespace API.DTOs
    //DTOs sind Objekte, die im Body eines Requests empfangen werden
{
    public class RegisterDto
    {
        [Required] //nennt sich hier data Annotationm können auch RegEx enthalten, um Bedingungen für Variablen-Werte zu setzen
        public string Username { get; set; }
        [Required]
        public string KnownAs { get; set; }
        [Required]
        public  string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
