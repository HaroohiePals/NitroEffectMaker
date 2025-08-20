using HaroohiePals.Gui.View;
using HaroohiePals.NitroEffectMaker.Gui.View.Main;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticlesArchive;

class ParticlesArchiveContentView(ViewFactory viewFactory) : WindowContentView
{
    private readonly DockSpaceView _dockSpaceView = new();
    private readonly ParticlesArchivePaneView _particlesArchivePaneView = viewFactory.CreateParticlesArchivePaneView();

    public override bool Draw()
    {
        _dockSpaceView.Draw();
        _particlesArchivePaneView.Draw();
        
        return true;
    }
}