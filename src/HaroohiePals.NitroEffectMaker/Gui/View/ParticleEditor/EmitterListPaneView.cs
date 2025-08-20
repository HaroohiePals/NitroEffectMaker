using HaroohiePals.Gui.View.Modal;
using HaroohiePals.Gui.View.Pane;
using HaroohiePals.NitroEffectMaker.Application;
using ImGuiNET;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

class EmitterListPaneView(IModalService modalService, ParticleEditorContextService particleEditorContextService)
    : PaneView("Emitters")
{
    private int _currentItem = 0;
    
    public override void DrawContent()
    {
        var particleArchive = particleEditorContextService.Context?.ParticleArchive;

        if (particleArchive is null)
            return;
        
        string[] emitters = particleArchive.Emitters.ToArray();
        ImGui.ListBox("##Emitters", ref _currentItem, emitters, emitters.Length);
    }
}