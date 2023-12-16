using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaCheckerboard.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _rows = 8;

        [ObservableProperty]
        private int _columns = 8;

        [ObservableProperty]
        private Color _firstColor = Colors.Black;

        [ObservableProperty]
        private Color _secondColor = Colors.White;
    }
}
