using System.ComponentModel.DataAnnotations.Schema;

namespace MartowoKsiazkowo.Encje;

public class BookInfo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookInfoId { get; set; }
    public string Gatunek { get; set; }
    public ICollection<Book> Books { get; set; }
}