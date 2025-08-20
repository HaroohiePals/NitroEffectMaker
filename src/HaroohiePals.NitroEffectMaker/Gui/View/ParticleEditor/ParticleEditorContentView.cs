using HaroohiePals.Gui.View;
using HaroohiePals.Gui.View.Menu;
using HaroohiePals.NitroEffectMaker.Application;
using HaroohiePals.NitroEffectMaker.Gui.View.Main;
using HaroohiePals.NitroEffectMaker.Gui.View.Shared;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

class ParticleEditorContentView(ViewFactory viewFactory, ParticleEditorContextService particleEditorContextService)
    : WindowContentView
{
    private readonly DockSpaceView _dockSpaceView = new();
    private readonly EmitterListPaneView _emitterListPaneView = viewFactory.CreateEmitterListPaneView();

    public override IReadOnlyCollection<MenuItem> MenuItems =>
    [
        new("File")
        {
            Items =
            [
                new("Save")
            ]
        }
    ];

    public override bool Draw()
    {
        _dockSpaceView.Draw();
        _emitterListPaneView.Draw();

        return true;
    }
}