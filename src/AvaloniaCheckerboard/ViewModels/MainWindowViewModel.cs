using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvaloniaCheckerboard.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public List<Color> AvailableColors { get; } = new();

        [ObservableProperty]
        private int _rows = 8;

        [ObservableProperty]
        private int _columns = 8;

        [ObservableProperty]
        private Color _firstColor = Colors.Black;

        [ObservableProperty]
        private Color _secondColor = Colors.White;

        [ObservableProperty]
        private int _firstColorSelectedIndex = 0;

        [ObservableProperty]
        private int _secondColorSelectedIndex = 0;

        public MainWindowViewModel()
        {
            var colorProperties = typeof(Colors).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            for (var i = 0; i < colorProperties.Length; i++)
            {
                var color = (Color?)colorProperties[i].GetValue(null);

                if (color == null)
                {
                    continue;
                }

                AvailableColors.Add(color.Value);

                if (color == FirstColor)
                {
                    _firstColorSelectedIndex = i;
                }
                else if (color == SecondColor)
                {
                    _secondColorSelectedIndex = i;
                }
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == nameof(FirstColorSelectedIndex))
            {
                FirstColor = AvailableColors[FirstColorSelectedIndex];
            }
            else if (e.PropertyName == nameof(SecondColorSelectedIndex))
            {
                SecondColor = AvailableColors[SecondColorSelectedIndex];
            }
        }
    }
}
