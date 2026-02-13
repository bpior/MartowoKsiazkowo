using System.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Image = SixLabors.ImageSharp.Image;

namespace MartowoKsiazkowo.Helpers;

public class Zdjecie_konwerter
{
    public string Konwertuj_na_ciąg(Image image)
    {
        // First Convert image to byte array.
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            //image.Save(Stream(stream), System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();

            byteArray = stream.ToArray();
        }

        // Convert byte[] to Base64 String
        string base64String = Convert.ToBase64String(byteArray);

        return base64String;

        MemoryStream Stream(MemoryStream stream)
        {
            return stream;
        }
    }
}
