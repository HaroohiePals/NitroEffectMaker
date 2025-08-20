using HaroohiePals.Gui.View.Modal;
using HaroohiePals.Gui.View.Pane;
using HaroohiePals.Gui.View.Tree;
using ImGuiNET;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticlesArchive;

class ParticlesArchivePaneView(IModalService modalService) : PaneView("ParticlesArchiveContentView")
{
    public override void DrawContent()
    {
        ImGui.Text("Hello world");
    }
}