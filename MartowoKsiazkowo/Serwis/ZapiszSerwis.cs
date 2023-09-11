using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;

namespace MartowoKsiazkowo.Serwis;


public interface IzapiszSerwis
{
  void Zapisz(Isbn isbn);   
}


public class ZapiszSerwis : IzapiszSerwis
{
  
  private readonly ApplicationDbContext _context;
  private IzapiszSerwis _izapiszSerwisImplementation;

  public ZapiszSerwis (ApplicationDbContext context)
  {
    _context = context;
  }
  
  
  
  
  public void Zapisz(Isbn isbn)
  {
   // throw new NotImplementedException();
   var ksiazka = new Book
   {
      //Tytul = Isbn.VolumeInfo.title,
       
      
   };


   var autor = new Author
   {
      /*AutorImie = Isbn.VolumeInfo.authors[0],
      AutorNazwisko = Isbn.VolumeInfo.authors[1]*/
   };
_context.Books.Add(ksiazka);
_context.SaveChanges();




  }


}