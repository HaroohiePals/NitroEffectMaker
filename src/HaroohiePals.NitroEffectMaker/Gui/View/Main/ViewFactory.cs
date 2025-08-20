using HaroohiePals.Gui.View.Modal;
using HaroohiePals.NitroEffectMaker.Gui.View.ParticlesArchive;

namespace HaroohiePals.NitroEffectMaker.Gui.View.Main;

class ViewFactory(IModalService modalService)
{
    public ParticlesArchiveContentView CreateParticlesArchiveContentView()
        =>  new ParticlesArchiveContentView(this);

    public ParticlesArchivePaneView CreateParticlesArchivePaneView()
        => new ParticlesArchivePaneView(modalService);
}