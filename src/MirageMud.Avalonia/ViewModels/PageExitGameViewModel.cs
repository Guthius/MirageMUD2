using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;

namespace MirageMud.Avalonia.ViewModels;

internal sealed partial class PageExitGameViewModel : PageViewModelBase
{
    [RelayCommand]
    private void ExitGame()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow?.Close();
        }
    }
}