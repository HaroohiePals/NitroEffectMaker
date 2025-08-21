using System.Numerics;
using HaroohiePals.Graphics3d.OpenGL;
using HaroohiePals.Gui;
using HaroohiePals.Gui.View.Pane;
using HaroohiePals.Nitro.G3;
using HaroohiePals.Nitro.JNLib.Spl;
using HaroohiePals.NitroEffectMaker.Application;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;

namespace HaroohiePals.NitroEffectMaker.Gui.View.ParticleEditor;

public class TextureListPaneView(ParticleEditorContextService particleEditorContextService)
    : PaneView("Textures")
{
    private List<(IntermediateParticleArchive.ParticleTexture, GLTexture)> _textures = [];
    
    public override void DrawContent()
    {
        if (_textures.Count == 0)
            InitializeTextures();

        if (!ImGui.BeginListBox("##EmitterList", ImGui.GetContentRegionAvail())) 
            return;

        var imageSize = new Vector2(40, 40) * ImGuiEx.GetUiScale();
        
        foreach (var texture in _textures)
        {
            ImGui.Selectable($"##{texture.Item1.Name}", false, ImGuiSelectableFlags.AllowOverlap, new(0, imageSize.Y));
            ImGui.SameLine();
            ImGui.Image(texture.Item2.Handle, imageSize);
            ImGui.SameLine();
            ImGui.Text(texture.Item1.Name ?? "(No Name)");
        }

        ImGui.EndListBox();
    }

    private void InitializeTextures()
    {
        var context = particleEditorContextService.Context;
        if (context is null)
            return;
        
        foreach (var texture in context.ParticleArchive.Textures)
        {
            var nitroTga = new NitroTga(File.ReadAllBytes(Path.Combine(context.RootPath, texture.Path)));
            var glTexture = new GLTexture(PixelInternalFormat.Rgba8, nitroTga.Header.ImageWidth,
                nitroTga.Header.ImageHeight, PixelFormat.Rgba,
                PixelType.UnsignedByte, nitroTga.ImageData);
            glTexture.Use();
            glTexture.SetWrapMode(Graphics3d.TextureWrapMode.Clamp, Graphics3d.TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureLodBias, -2.0f);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            _textures.Add((texture, glTexture));
        }
    }
}