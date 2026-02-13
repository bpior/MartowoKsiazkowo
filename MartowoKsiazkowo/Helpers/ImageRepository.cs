using MartowoKsiazkowo.Data;

namespace MartowoKsiazkowo.Helpers;

public class ImageRepository : IImageRepository

{
    private readonly ApplicationDbContext _context;

    public ImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public byte[] SaveImage(Image image, string format)
    {
        using (MemoryStream stream = new MemoryStream())
        {
          //  image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteArray = stream.ToArray();

            // Tutaj zapisz byteArray w bazie danych (np. jako ImageData)

            return byteArray;
        }
    }
    
}

public class ImageDeletionRepository : IImageDeletionRepository
{
    private readonly ApplicationDbContext _context;

    public ImageDeletionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void DeleteImage(int imageId)
    {
        // Tutaj usuń zdjęcie z bazy danych na podstawie imageId
        // Przykład: var image = _context.Images.Find(imageId);
        
        /*if (image != null)
        {
            _context.Images.Remove(image);
            _context.SaveChanges();
        }*/
    }
}
