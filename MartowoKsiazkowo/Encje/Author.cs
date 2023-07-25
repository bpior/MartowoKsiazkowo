using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartowoKsiazkowo.Encje;

public class Author
{
    public int AuthorId { get; set; }
    [Display(Name = "Imie")]
    public string AutorImie { get; set; }
    [Display(Name = "Nazwisko")]
    public string AutorNazwisko { get; set; }
    public ICollection<Book> Books { get; set; }
    public string FullAutorName
    {
        get
        {
            return AutorImie + " " + AutorNazwisko;
        }
    }
}
