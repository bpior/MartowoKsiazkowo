namespace MartowoKsiazkowo.Helpers;

public interface IImageRepository
{
    byte[] SaveImage(Image image, string format);
}