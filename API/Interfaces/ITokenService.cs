using API.Entities;
//Interfaces werden in erster Linie für einfacheres Testen implementiert (7:00)
namespace API.Interfaces
{
    public interface ITokenService
    {
       public string CreateToken(AppUser user);
    }
}
