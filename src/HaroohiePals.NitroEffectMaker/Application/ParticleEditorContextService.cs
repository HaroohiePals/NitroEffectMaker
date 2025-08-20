namespace HaroohiePals.NitroEffectMaker.Application;

public class ParticleEditorContextService
{
    public ParticleEditorContext? Context { get; private set; }
    public bool IsContextInitialized => Context is not null;

    public void InitializeContext(string filePath)
    {
        Context = new ParticleEditorContext(filePath);
    }
}