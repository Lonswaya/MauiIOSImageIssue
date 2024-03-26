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
    }
}