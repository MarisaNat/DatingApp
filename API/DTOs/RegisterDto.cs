using System.ComponentModel.DataAnnotations;

namespace API.DTOs
    //DTOs sind Objekte, die im Body eines Requests empfangen werden
{
    public class RegisterDto
    {
        [Required] //nennt sich hier data Annotationm können auch RegEx enthalten, um Bedingungen für Variablen-Werte zu setzen
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
