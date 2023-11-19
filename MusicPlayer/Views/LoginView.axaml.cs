using Avalonia.Controls;
using DialogHostAvalonia;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void NoAccountPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {

            await DialogHost.Show(new RegisterVM(), "NoAccountDialogHost");
            
        }
    }
}
