using System.Reflection;
using MauiImageLibrary;

namespace TestMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        view_device.Source = ImageSource.FromFile("view_devices.png");
        bot.Source = ImageSource.FromFile(ImagePaths.BOT_PATH);
        devices.Source = ImageSource.FromFile(ImagePaths.DEVICES_PATH);
        
        devices_embedded.Source = ImageSource.FromStream(token =>
        {
            return GetImageStream(CancellationToken.None, "MauiImageLibrary.Resources.SVGs.devices.devices_embedded.svg", Assembly.GetAssembly(typeof(ImagePaths)));;
        });
    }
    
    // Workaround 
    private static Task<Stream> GetImageStream(CancellationToken token, string resource, Assembly assembly)
    {
        return Task.Run<Stream>(() =>
        {
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.ToLower() == resource.ToLower());

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                var svg = new Svg.Skia.SKSvg();
                svg.Load(stream);

                using (var bitMap = new SkiaSharp.SKBitmap((int)svg.Drawable.Bounds.Width, (int)svg.Drawable.Bounds.Height))
                using (var canvas = new SkiaSharp.SKCanvas(bitMap))
                {
                    canvas.DrawPicture(svg.Picture);
                    canvas.Flush();
                    canvas.Save();

                    using (var image = SkiaSharp.SKImage.FromBitmap(bitMap))
                    using (var data = image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 80))
                    {
                        var memStream = new MemoryStream();
                        data.SaveTo(memStream);
                        memStream.Seek(0, SeekOrigin.Begin);

                        return memStream;
                    }
                }
            }
        });
    }
}