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
        private bool showemailerror = false;
        private bool showpassworderror = false;
        public bool ShowEmailError
        {
            get => this.showemailerror;
            set => this.RaiseAndSetIfChanged(ref this.showemailerror, value);
        }
        public bool ShowPasswordError
        {
            get => this.showpassworderror;
            set => this.RaiseAndSetIfChanged(ref this.showpassworderror, value);
        }
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
            var isInputValid = this.WhenAnyValue(x => x.Email, x => x.Password,
                (email, password) => (!string.IsNullOrWhiteSpace(password)
                && !string.IsNullOrWhiteSpace(email)));
                
            LoginCommand = ReactiveCommand.CreateFromTask(loginCommand , isInputValid);
        }
        private async Task loginCommand()
        {
            //see if it exists in db
            using (var dbcontext = new DatabaseContext())
            {
                var user = await dbcontext.Credentials.FirstOrDefaultAsync(u => u.Email == this.Email);
                if (user == null)
                {
                    //email not found
                    await ShowErrorEmail();
                    return;
                }
                if (user.Password != this.Password)
                {
                    //inccorect password    
                    await ShowErrorPassword();
                    return;
                }
                //good to go
            }
        }
        private async Task ShowErrorEmail()
        {
            ShowEmailError = true;
            await Task.Delay(3000);
            ShowEmailError = false;
        }
        private async Task ShowErrorPassword()
        {
            ShowPasswordError = true;
            await Task.Delay(3000);
            ShowPasswordError = false;
        }
      
                
           


        
    }
}
