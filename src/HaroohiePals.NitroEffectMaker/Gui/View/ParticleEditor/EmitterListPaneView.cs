using HaroohiePals.Gui.View.Modal;
using HaroohiePals.Gui.View.Pane;
using HaroohiePals.NitroEffectMaker.Application;
using ImGuiNET;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

class EmitterListPaneView(ParticleEditorContextService particleEditorContextService)
    : PaneView("Emitters")
{
    private int _currentItem = 0;
    
    public override void DrawContent()
    {
        var particleArchive = particleEditorContextService.Context?.ParticleArchive;

        if (particleArchive is null)
            return;

        if (!ImGui.BeginListBox("##EmitterList", ImGui.GetContentRegionAvail())) 
            return;
        
        foreach (var emitter in particleArchive.Emitters)
        {
            ImGui.Selectable(emitter ?? "(No Name)");
        }

        ImGui.EndListBox();
    }
}