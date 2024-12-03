using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MirageMud.Avalonia.ViewModels;

internal sealed partial class MenuViewModel : ObservableObject
{
    [ObservableProperty]
    private PageViewModelBase _currentPage = new PageLoginViewModel();

    [RelayCommand]
    private void ShowHome()
    {
        CurrentPage = new PageHomeViewModel();
    }

    [RelayCommand]
    private void ShowNewAccountPage()
    {
        CurrentPage = new PageNewAccountViewModel();
    }

    [RelayCommand]
    private void ShowLoginPage()
    {
        CurrentPage = new PageLoginViewModel();
    }

    [RelayCommand]
    private void ShowIpConfigPage()
    {
        CurrentPage = new PageIpConfigViewModel();
    }

    [RelayCommand]
    private void ShowGameOptionsPage()
    {
        CurrentPage = new PageGameOptionsViewModel();
    }

    [RelayCommand]
    private void ShowCreditsPage()
    {
        CurrentPage = new PageCreditsViewModel();
    }

    [RelayCommand]
    private void ShowExitGamePage()
    {
        CurrentPage = new PageExitGameViewModel();
    }
}