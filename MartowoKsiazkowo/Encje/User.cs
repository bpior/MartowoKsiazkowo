using System.ComponentModel.DataAnnotations.Schema;

namespace MartowoKsiazkowo.Encje;



public class User
{
    public int UserId { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Email { get; set; }
    public UserAddress Address { get; set; }
    public ICollection<BookUser> BookUsers { get; set; }

    public string FullUserName
    {
        get
        {
            return Imie + " " + Nazwisko;
        }

    }
}