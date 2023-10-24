using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MartowoKsiazkowo.Encje;

public class Book
{
    [Key]
    public int BookId { get; set; }
    [Required]
    [Display(Name = "Tytuł")]
    public string Tytul { get; set; }
    public int BookInfoId { get; set; }
    [ForeignKey("BookInfoId")]
    [Display(Name = "Gatunek")]
    public BookInfo BookInfo { get; set; }
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    [Display(Name = "Autor")]
    public Author Author { get; set; }
    public ICollection<User> User { get; set; }
    public byte [] Miniatura { get; set; }
    
    
    public byte[] ImageData { get; set; }
    public string ImageMimeType { get; set; }
    
}