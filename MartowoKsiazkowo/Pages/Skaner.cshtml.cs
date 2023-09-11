/*
using System.Drawing;
using System.Drawing.Text;
*/

//using System.Drawing;
/*
using System.Drawing.Text;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using QRCoder;
using System.IO;


namespace MartowoKsiazkowo.Pages;

public class Skaner : PageModel
{
    [BindProperty]
    public string QRCodeText { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(QRCodeText))
        {
            // Generuj kod QR na podstawie wprowadzonego tekstu
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRCodeText, QRCodeGenerator.ECCLevel.Q);
         //   QRCode qrCode = new QRCode(qrCodeData);
         //   BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCode);
        //    byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

            // Przekonwertuj dane obrazu na format ImageSharp
          //  using (var image = Image.Load<Rgba32>(qrCodeBytes, out var format))
            {
                // Zapisz obraz jako plik PNG
                var filePath = Path.Combine("wwwroot", "QRCode.png");
          //      image.Save(filePath);
            }

            // Przekieruj użytkownika do strony z wygenerowanym kodem QR
            return RedirectToPage("/QRCode");
        }

        return Page();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*[BindProperty]
    public string QRCodeText { get; set; }

    public IActionResult OnPost()
    {
        if (string.IsNullOrEmpty(QRCodeText))
            return Page();

        // Tworzenie kodu QR z podanego tekstu
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRCodeText, QRCodeGenerator.ECCLevel.Q);
        //qrcode`
        QRCode qrCode = new QRCode(qrCodeData);
        BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCode);

        // Wyświetlanie kodu QR jako obrazek na stronie
        using (Image<Rgba32> qrImage = MediaTypeNames.Image.Load(qrCodeImage.GetGraphic(20)))
        {
            using (var graphics = new Image<Rgba32>(400, 400))
            {
                graphics.Mutate(ctx => ctx.Fill(Rgba32.White));
                graphics.Mutate(ctx => ctx.DrawImage(qrImage, new SixLabors.ImageSharp.PointF(0, 0), 1));
                graphics.Mutate(ctx => ctx.ApplyScalingWaterMark(CreateTextWatermark(QRCodeText, 20), Rgba32.Black, 1F, 1F));

                using (var stream = new System.IO.MemoryStream())
                {
                    graphics.Save(stream, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
                    ViewData["QRCodeImage"] = $"data:image/png;base64,{Convert.ToBase64String(stream.ToArray())}";
                }
            }
        }
        */

    //     return Page();
    // }

    /*private IImageProcessingContext CreateTextWatermark(string text, int fontSize)
    {
        var fontCollection = new FontCollection();
        var font = fontCollection.Install("Arial.ttf");
        var fontConfig = new TextGraphicsOptions(true)
        {
            WrapTextWidth = 300,
            TextOptions = {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextStyle = new TextStyle()
                {
                    Font = new Font(font, fontSize, FontStyle.Regular),
                    Color = Rgba32.Black,
                    DpiX = 96,
                    DpiY = 96
                }
            }
        };

        return new Image<Rgba32>(400, 400).DrawText(fontConfig, text);
    }*/
    
    
    
    
    
}