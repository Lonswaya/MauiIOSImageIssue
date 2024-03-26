using MauiImageLibrary;
using Microsoft.Maui.Controls;

namespace MauiViewLibrary;

public partial class ImagesView : ContentView
{
    public ImagesView()
    {
        InitializeComponent();
        bot.Source = ImageSource.FromFile(ImagePaths.BOT_PATH);
        devices.Source = ImageSource.FromFile(ImagePaths.DEVICES_PATH);
    }
    
}