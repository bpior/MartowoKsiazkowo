using System.Net.Mime;
using System.Text;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;
using MartowoKsiazkowo.Serwis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace MartowoKsiazkowo.Controller;


[Route("isbn")]
[Controller]
public class IsbnControler : ControllerBase
{
    
    private readonly ApplicationDbContext _context;
    public IConfiguration configuration;
    public IHttpClientFactory httpClientFactory;
    public IHostEnvironment _env;
    private readonly IzapiszSerwis _zapiszSerwis;
    
    
    //
    
    public  IsbnControler (IConfiguration configuration, IHttpClientFactory httpClientFactory, IHostEnvironment env, ApplicationDbContext context, IzapiszSerwis zapiszSerwis)
    {
        this.configuration = configuration;
        this.httpClientFactory = httpClientFactory;
        _env = env;
        _context = context;
        _zapiszSerwis = zapiszSerwis;
    }

    [HttpGet("nr/{data}")]
    
    public async Task<IActionResult> GetIsbn(string data)
    {
        using HttpClient client = httpClientFactory.CreateClient(("ISBN"));
        string uri = $"isbn:{data}";



        HttpResponseMessage response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        string json = await response.Content.ReadAsStringAsync();

        Isbn.Root isbn = JsonConvert.DeserializeObject<Isbn.Root>(json);

        return Ok(response);
    }


    [HttpGet("nr2/{data}")]
    public async Task<IActionResult> GetIsbn2(string data)
    {
        using HttpClient client =  httpClientFactory.CreateClient(("book"));
        //string uri = $"isbn:{data}";
       // using HttpClient client = new HttpClient();
        //  string uri = $"https://openlibrary.org/api/books?bibkeys=ISBN:{data}&jscmd=data&format=json";
   //     string uri = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{data}";
         string uri = $"volumes?q=isbn:{data}";

        HttpResponseMessage response = await client.GetAsync(uri);

        //response.EnsureSuccessStatusCode();
        string json = await response.Content.ReadAsStringAsync();

        List<Isbn.Root> result = JsonConvert.DeserializeObject<List<Isbn.Root>>(json);

        List<Isbn.Root> list = new List<Isbn.Root>();
        
        // string title = response.items[0].volumeInfo.title;
        // string author = result.items[0].volumeInfo.authors[0];
        //
        
        return Ok(list);




    }




    [HttpGet("nr3/{data}")]
    public async Task<Isbn.Root> GetIsbn3(string data)
    {
        using HttpClient client =  httpClientFactory.CreateClient(("book"));
        //string uri = $"isbn:{data}";
        // using HttpClient client = new HttpClient();
        //  string uri = $"https://openlibrary.org/api/books?bibkeys=ISBN:{data}&jscmd=data&format=json";
        //     string uri = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{data}";
     //   string uri = $"q=isbn:{data}";

     string key = "AIzaSyALbXPhCbT25bqtCptzSHOlr6jMWSrXtz4";
        
     string uri = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{data}&key={key}";
        HttpResponseMessage response = await client.GetAsync(uri);

        //response.EnsureSuccessStatusCode();
     //   string json = await response.Content.ReadAsStringAsync();
     string json = await response.Content.ReadAsStringAsync();
     Isbn.Root bookInfo = JsonConvert.DeserializeObject<Isbn.Root>(json);
     return bookInfo;
       
     
    }
        
        // List<Isbn.Root> result = JsonConvert.DeserializeObject<List<Isbn.Root>>(json);
        //
        // List<Isbn.Root> list = new List<Isbn.Root>();
        
        // string title = response.items[0].volumeInfo.title;
        // string author = result.items[0].volumeInfo.authors[0];
        //
        
       // return Ok();

       [HttpPost("post/{data}")]
       public async Task StworzIsbn(string data)
       {



          // var jakastrescjson = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
           
           var httpClient = httpClientFactory.CreateClient("GitHub");

      //     using var httpResponseMessage =
        //       await httpClient.PostAsync($"post/{data}", jakastrescjson);  //PostAsync("/api/TodoItems", todoItemJson);

          // httpResponseMessage.EnsureSuccessStatusCode();
           
       }
       
       [HttpPost("zapisz")]
       public ActionResult Zapisz([FromBody] Isbn isbn )
       {
         _zapiszSerwis.Zapisz(isbn);
            
           return Ok(StatusCodes.Status201Created +" Utworzono konto");
       }
       
       
       
       
       [HttpPost("isbn/{isbn}")]
       public async Task<IActionResult> PostIsbn([FromBody] string isbn)
       {
           if (string.IsNullOrWhiteSpace(isbn))
           {
               return BadRequest("Numer ISBN nie może być pusty.");
           }

           var book = new Author { AutorImie = isbn };

           _context.Author.Add(book);
           await _context.SaveChangesAsync();

           return Ok($"Zapisano numer ISBN: {isbn} do bazy danych.");
       }

       /*[HttpPost ("isbn2/{isbn}")]
       public async Task CreateItemAsync(Isbn.VolumeInfo isbnModel)
       {
           
           var httpClient = httpClientFactory.CreateClient();

           var isbnModelJson = new StringContent(
               JsonSerializer.Serialize(isbnModel),
               Encoding.UTF8,
               MediaTypeNames.Application.Json);

           using var httpResponseMessage =
               await httpClient.PostAsync("/api/isbn", isbnModelJson);

           httpResponseMessage.EnsureSuccessStatusCode();
       }*/
       
       /*[HttpPost ("isbn1/{isbn}")]
       public async Task CreateItemAsync(Isbn isbn)
       {
           
            
           var httpClient = httpClientFactory.CreateClient();
           
           var todoItemJson = new StringContent(
               JsonSerializer.Serialize(isbn),
               Encoding.UTF8,
               MediaTypeNames.Application.Json); // using static System.Net.Mime.MediaTypeNames;

           using var httpResponseMessage =
               await httpClient.PostAsync($"/isbn/{Isbn}", todoItemJson);

           httpResponseMessage.EnsureSuccessStatusCode();
       }*/


       
       [HttpPost("test")]
       public async Task<IActionResult> CreateBook([FromBody] Isbn.Root root)
       {
           if (root?.items == null || root.items.Count == 0)
           {
               return BadRequest("Brak danych do zapisania.");
           }

           foreach (var item in root.items)
           {
               var book = new Book
               {
                   Tytul = item.volumeInfo.title
                   
                   // Mapuj inne właściwości z item.volumeInfo do odpowiednich właściwości w modelu Book
               };

               _context.Books.Add(book);
           }

           await _context.SaveChangesAsync();

           return Ok("Dane zostały pomyślnie zapisane.");
       }
       
       
       [HttpGet("nr4/{data}")]
       public async Task<Isbn.Root> GetIsbn4(string data)
       {
           using HttpClient client =  httpClientFactory.CreateClient(("book"));
           //string uri = $"isbn:{data}";
           // using HttpClient client = new HttpClient();
           //  string uri = $"https://openlibrary.org/api/books?bibkeys=ISBN:{data}&jscmd=data&format=json";
           //     string uri = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{data}";
           //   string uri = $"q=isbn:{data}";

           string key = "AIzaSyALbXPhCbT25bqtCptzSHOlr6jMWSrXtz4";
        
           string uri = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{data}&key={key}";
           HttpResponseMessage response = await client.GetAsync(uri);

           //response.EnsureSuccessStatusCode();
           //   string json = await response.Content.ReadAsStringAsync();
           string json = await response.Content.ReadAsStringAsync();
           Isbn.Root bookInfo = JsonConvert.DeserializeObject<Isbn.Root>(json);
           
           
           
           
           /*
           if (bookInfo.items == null || bookInfo.items.Count == 0)
           {
               return BadRequest(); //BadRequest("Brak danych do zapisania.");
           }*/

           foreach (var item in bookInfo.items)
           {
               var book = new Book
               {
                   Tytul = item.volumeInfo.title
                   
                   // Mapuj inne właściwości z item.volumeInfo do odpowiednich właściwości w modelu Book
               };

               var autor = new Author
               {
                //   AuthorId = new int(Random(Next(1, 1000))),
                   AutorImie = item.volumeInfo.authors[0],
                    AutorNazwisko = item.volumeInfo.authors[1]
                   
               };
               
               _context.Author.Add(autor);
            //   _context.Books.Add(book);
           }

           await _context.SaveChangesAsync();


           foreach (var item in bookInfo.items)
           {
               var book = new Book
               {
                   Tytul = item.volumeInfo.title,
                   BookInfoId = 1,
                   AuthorId = 2
                   
                   // Mapuj inne właściwości z item.volumeInfo do odpowiednich właściwości w modelu Book
               };

               var autor = new Author
               {
                   //   AuthorId = new int(Random(Next(1, 1000))),
                   AutorImie = item.volumeInfo.authors[0],
                   AutorNazwisko = item.volumeInfo.authors[1]
                   
               };
               
               //_context.Author.Add(autor);
                  _context.Books.Add(book);
           }

           await _context.SaveChangesAsync();
           
           
           return bookInfo;
           //return Ok(bookInfo);


           // return bookInfo;


       }
       
       
       
}