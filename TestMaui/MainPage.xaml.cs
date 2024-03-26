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
        
        // Workaround
        var assembly = Assembly.GetAssembly(typeof(ImagePaths));
        var resource = "MauiImageLibrary.Resources.Images.dotnet_bot_embedded.png";
        bot_embedded.Source = ImageSource.FromStream(() =>
        {
            var resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(n => n.ToLower() == resource.ToLower());
            return assembly.GetManifestResourceStream(resourceName);
        });
    }
}