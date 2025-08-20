using HaroohiePals.NitroEffectMaker.Gui.View.Main;

namespace HaroohiePals.NitroEffectMaker.Gui.ViewModel.Main;

class MainWindowViewModel(MainWindowManager mainWindowManager, ViewFactory viewFactory)
{
    public float GetUiScale() 
        => 1.0f;

    public void OpenParticleArchive()
    {
        // todo
        mainWindowManager.SetContentView(viewFactory.CreateParticlesArchiveContentView());
    }
}