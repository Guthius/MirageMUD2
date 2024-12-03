using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MirageMud.Avalonia.ViewModels;

internal sealed partial class PageGameOptionsViewModel : PageViewModelBase
{
    public sealed record Language(string Code, string Description);

    [ObservableProperty]
    private bool _enableMusic = true;

    [ObservableProperty]
    private bool _enableSound = true;

    [ObservableProperty]
    private string _selectedLanguage = "en-us";

    [ObservableProperty]
    private List<Language> _languages =
    [
        new("cy", "Welsh (Cymraeg)"),
        new("de", "German (Deutsch)"),
        new("en-gb", "British English (English)"),
        new("en-us", "American English (English)"),
        new("es", "Spanish (Español)"),
        new("fr", "French (Français)"),
        new("it", "Italian (Italiano)"),
        new("pt", "Portuguese (Português)"),
        new("ja-ro", "Romanized Japanese (Romaji)"),
        new("pl", "Polish (Polski)"),
        new("wv", "Swedish (Svenska)")
    ];
}