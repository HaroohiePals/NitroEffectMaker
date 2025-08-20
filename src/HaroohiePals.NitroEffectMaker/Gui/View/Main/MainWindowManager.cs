using HaroohiePals.Gui.View;

namespace HaroohiePals.NitroEffectMaker.Gui.View.Main;

class MainWindowManager
{
    private MainWindow? _mainWindow;

    public void SetMainWindow(MainWindow mainWindow)
        => _mainWindow = mainWindow;

    public void SetContentView(WindowContentView contentView)
    {
        if (_mainWindow is null)
            return;

        _mainWindow.Content = contentView;
    }

    public void SetDirty()
    {
        if (_mainWindow is null)
            return;
        
        _mainWindow.IsDirty = true;
    }

    public void ClearDirty()
    {
        if (_mainWindow is null)
            return;

        _mainWindow.IsDirty = false;
    }
}