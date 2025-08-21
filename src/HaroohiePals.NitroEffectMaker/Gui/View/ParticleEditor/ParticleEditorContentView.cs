using HaroohiePals.Gui.View;
￼￼Scegli fileNessun file selezionato
Message #hacking_and_development

using HaroohiePals.Gui.View.Menu;
using HaroohiePals.NitroEffectMaker.Application;
using HaroohiePals.NitroEffectMaker.Gui.View.Main;
using HaroohiePals.NitroEffectMaker.Gui.View.Shared;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

class ParticleEditorContentView(ViewFactory viewFactory, ParticleEditorContextService particleEditorContextService)
    : WindowContentView
{
    private readonly DockSpaceView _dockSpaceView = new();
    private readonly EmitterListPaneView _emitterListPaneView = viewFactory.CreateEmitterListPaneView();
    private readonly TextureListPaneView _textureListPaneView = viewFactory.CreateTextureListPaneView();

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
        _textureListPaneView.Draw();
        
        return true;
    }
}