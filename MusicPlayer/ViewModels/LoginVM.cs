using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;

namespace MusicPlayer.ViewModels
{
    public class LoginVM : ViewModelBase
    {

        private string? email;
        private string? password;
        public string Email
        {
            
            get => email!;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }
        public string Password
        {
            get => password!;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; set; }
        public LoginVM(NavigationVM nav)
        {
            LoginCommand = ReactiveCommand.Create(loginCommand);
        }

        private async void loginCommand()
        {
          //see if it exists in db
          using (var dbcontext = new DatabaseContext())
            {
                var user = await dbcontext.Credentials.FirstOrDefaultAsync(u => u.Email == this.Email);
                if (user == null)
                {
                    //email not fund
                    return;
                }
                if (user.Password != this.Password)
                {
                    //inccorect password    
                    return;
                }
                //good to go


                

            }


        }
    }
}
