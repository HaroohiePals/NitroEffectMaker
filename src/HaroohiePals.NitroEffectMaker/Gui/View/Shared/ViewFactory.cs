using HaroohiePals.Gui.View.Modal;
using HaroohiePals.NitroEffectMaker.Application;
using HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

namespace HaroohiePals.NitroEffectMaker.Gui.View.Shared;

class ViewFactory(IModalService modalService, ParticleEditorContextService particleEditorContextService)
{
    public ParticleEditorContentView CreateParticleEditorContentView()
        =>  new ParticleEditorContentView(this, particleEditorContextService);

    public EmitterListPaneView CreateEmitterListPaneView()
        => new EmitterListPaneView(modalService, particleEditorContextService);
}