using HaroohiePals.Gui;
using HaroohiePals.Gui.View.Modal;
using HaroohiePals.NitroEffectMaker.Gui.ViewModel.Main;
using OpenTK.Mathematics;

namespace HaroohiePals.NitroEffectMaker.Gui.View.Main;

class MainWindow : ImGuiViewWindow
{
    private const string WINDOW_TITLE = "Nitro Effect Maker";
    private static readonly Vector2i sWindowSize = new(1400, 900);

    private readonly MainWindowViewModel _viewModel;
    private readonly IModalService _modalService;
    public bool IsDirty { get; set; }

    public MainWindow(IModalService modalService, MainWindowViewModel viewModel) : base(
        ImGuiGameWindowSettings.Default with
        {
            Title = WINDOW_TITLE, Size = sWindowSize, UiScale = viewModel.GetUiScale()
        },
        modalService)
    {
        _viewModel = viewModel;
        _modalService = modalService;

        MainMenuItems =
        [
            new("File")
            {
                Items =
                [
                    new("New"),
                    new("Open", _viewModel.OpenParticleArchive)
                ]
            },
            new("Edit"),
            new("Tools")
            {
                Items =
                [
                    new("Preferences")
                ]
            },
            new("Window")
            {
                Items =
                [
                    new("Restore default layout")
                ]
            },
            new("About"),
        ];
    }
}