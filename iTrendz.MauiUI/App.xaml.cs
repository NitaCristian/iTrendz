using Microsoft.Maui.Controls;

namespace iTrendz.MauiUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }
}