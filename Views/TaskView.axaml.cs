using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LabMileshko6.Views
{
    public partial class TaskView : UserControl
    {
        public TaskView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
