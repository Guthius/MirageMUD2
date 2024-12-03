using CommunityToolkit.Mvvm.ComponentModel;

namespace MirageMud.Avalonia.ViewModels;

internal sealed class MainWindowViewModel : ObservableObject
{
    public string Greeting => "Welcome to Avalonia!";
}