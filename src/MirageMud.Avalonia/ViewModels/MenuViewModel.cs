using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MirageMud.Avalonia.ViewModels;

internal sealed partial class MenuViewModel : ObservableObject
{
    [ObservableProperty]
    private PageViewModelBase _currentPage = new PageLoginViewModel();

    private void SwitchPage<TPage>() where TPage : PageViewModelBase, new()
    {
        if (CurrentPage is TPage)
        {
            return;
        }
        
        CurrentPage = new TPage();
    }
    
    [RelayCommand]
    private void ShowHome()
    {
        SwitchPage<PageHomeViewModel>();
    }

    [RelayCommand]
    private void ShowNewAccountPage()
    {
        SwitchPage<PageNewAccountViewModel>();
    }

    [RelayCommand]
    private void ShowLoginPage()
    {
        SwitchPage<PageLoginViewModel>();
    }

    [RelayCommand]
    private void ShowIpConfigPage()
    {
        SwitchPage<PageIpConfigViewModel>();
    }

    [RelayCommand]
    private void ShowGameOptionsPage()
    {
        SwitchPage<PageGameOptionsViewModel>();
    }

    [RelayCommand]
    private void ShowCreditsPage()
    {
        SwitchPage<PageCreditsViewModel>();
    }

    [RelayCommand]
    private void ShowExitGamePage()
    {
        SwitchPage<PageExitGameViewModel>();
    }
}