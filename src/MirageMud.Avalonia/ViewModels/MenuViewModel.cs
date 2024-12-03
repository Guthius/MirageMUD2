using ReactiveUI;

namespace MirageMud.Avalonia.ViewModels;

public sealed class MenuViewModel : ViewModelBase
{
    private PageViewModelBase _currentPage = new PageWelcomeViewModel();

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }
}