using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using Color = System.Drawing.Color;


namespace MartowoKsiazkowo.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
private readonly IWebHostEnvironment _environment;
    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        environment = _environment;
    }

    [HttpPost]
    public IActionResult Index (IFormCollection formCollection)
    {
        var writer = new QRCodeWriter();
        var resultBit = writer.encode(formCollection["QRCodeString"], BarcodeFormat.QR_CODE, 200, 200);
        var matrix = resultBit;
        int scale = 2;
        Bitmap restultBitmap = new Bitmap(matrix.Width * scale, matrix.Height * scale);
        for (int x = 0; x < matrix.Height; x++)
        {
            for (int y = 0; y < matrix.Width; y++)
            {
                
                Color pixel = matrix[x,y] ? Color.Black : Color.White;
                for (int i = 0; i < scale; i++)
                // {
                //     
                // }
                    for (int j = 0; j < scale; j++)
                // {
                //     
                // }
                        restultBitmap.SetPixel(x * scale + i, y * scale + j, pixel);
            }
        }
        
        string webRootPath = _environment.WebRootPath;
        restultBitmap.Save(webRootPath + "/Images/QRCodeNew.png");
  //    ViewData[Url.ToString()] = "QRCodeNew.png";
  //   ViewBag.Url = "QRCodeNew.png";
  ViewData["URL"] = "/Images/QRCodeNew.png";
  
  
     return Page();
        
//        return RedirectToPage("/Books/Index");
    }
    
    public void OnGet()
    {
    }
}