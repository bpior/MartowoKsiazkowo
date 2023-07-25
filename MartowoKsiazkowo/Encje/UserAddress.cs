using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartowoKsiazkowo.Encje;


public class UserAddress
{
    public int UserAddressId { get; set; }
    [DisplayName("Użytkownik")]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public string Miasto { get; set; }
    public string Ulica { get; set; }
    [DisplayName("Nr Domu")]
    public int NrDomu { get; set; }
    [MinLength(9), MaxLength(9)]
    [DisplayName("Nr Telefonu")]
    public string NrTelefonu { get; set; }
}