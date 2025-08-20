using HaroohiePals.Actions;
using HaroohiePals.Nitro.JNLib.Spl;

namespace HaroohiePals.NitroEffectMaker.Application;

public class ParticleEditorContext
{
    private static readonly string sTemporaryIspaPath = Path.Combine("temp", "ispa");
    public string ParticleArchivePath { get; private set; }
    public IntermediateParticleArchive ParticleArchive { get; private set; }
    public ActionStack ActionStack { get; } = new();
    
    public ParticleEditorContext(string particleArchivePath)
    {
        if (!File.Exists(particleArchivePath))
            throw new FileNotFoundException(particleArchivePath);

        ParticleArchivePath = particleArchivePath;

        var fileInfo = new FileInfo(particleArchivePath);

        string fileExt = fileInfo.Extension?.ToLower() ?? "";

        switch (fileExt)
        {
            case ".ispa":
                ParticleArchive = IntermediateParticleArchive.FromXml(File.ReadAllBytes(particleArchivePath));
                break;
            default:
                if (Directory.Exists(sTemporaryIspaPath))
                    Directory.Delete(sTemporaryIspaPath, true);
                
                Directory.CreateDirectory(sTemporaryIspaPath);

                var splArchive = new SplArchive(File.ReadAllBytes(particleArchivePath));
                var factory = new IntermediateParticleArchiveFactory();
                
                ParticleArchive = factory.CreateAsync(splArchive, sTemporaryIspaPath).GetAwaiter().GetResult();
                break;
        }
    }
}