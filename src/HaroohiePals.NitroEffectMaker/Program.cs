using HaroohiePals.Gui.View.Modal;
using HaroohiePals.NitroEffectMaker.Gui.View.Main;
using HaroohiePals.NitroEffectMaker.Gui.ViewModel.Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HaroohiePals.NitroEffectMaker;

static class Program
{
    private static void Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IModalService, ModalService>();
                services.AddSingleton<MainWindowManager>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainWindow>();
            }).Build();

        var app = host.Services.GetRequiredService<MainWindow>();
        app.Run();
    }
}