using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LabMileshko6.Views
{
    public partial class ToDoView : UserControl
    {
        public ToDoView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
