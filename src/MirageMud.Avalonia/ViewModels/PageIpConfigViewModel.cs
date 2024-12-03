using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MirageMud.Avalonia.ViewModels;

internal sealed partial class PageIpConfigViewModel : PageViewModelBase
{
    [ObservableProperty]
    private string _host = "localhost";

    [ObservableProperty]
    private int _port = 7000;

    private sealed record IpConfig(string Host, int Port);
    
    public PageIpConfigViewModel()
    {
        Load();
    }

    private static string GetIpConfigPath()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        
        path = Path.Combine(path, "MirageMUD");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        
        path = Path.Combine(path, "ipconfig.json");
        
        return path;
    }

    private void Load()
    {
        var path = GetIpConfigPath();

        try
        {
            var json = File.ReadAllText(path);
            
            var config = JsonSerializer.Deserialize<IpConfig>(json);
            if (config is null)
            {
                return;
            }
            
            Host = config.Host;
            Port = config.Port;
        }
        catch
        {
            // ignored
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        var config = new IpConfig(Host, Port);

        try
        {
            var json = JsonSerializer.Serialize(config);

            await File.WriteAllTextAsync(GetIpConfigPath(), json);
        }
        catch
        {
            // ignored
        }
    }
}