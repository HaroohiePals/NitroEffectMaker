using HaroohiePals.NitroEffectMaker.Application;
using HaroohiePals.NitroEffectMaker.Gui.View.Main;
using HaroohiePals.NitroEffectMaker.Gui.View.Shared;
using NativeFileDialogs.Net;

namespace HaroohiePals.NitroEffectMaker.Gui.ViewModel.Main;

class MainWindowViewModel(
    MainWindowManager mainWindowManager,
    ViewFactory viewFactory,
    ParticleEditorContextService particleEditorContextService)
{
    public float GetUiScale()
        => 1.0f;

    public void OpenParticleArchive()
    {
        var result = Nfd.OpenDialog(out string? filePath, new Dictionary<string, string>
        {
            { "All compatible files", "ispa,spa" },
            { "Intermediate Simple Particle Archive", "ispa" },
            { "Simple Particle Archive", "spa" }
        });

        if (result != NfdStatus.Ok || filePath is null)
            return;

        particleEditorContextService.InitializeContext(filePath);
        mainWindowManager.SetContentView(viewFactory.CreateParticleEditorContentView());
    }
}