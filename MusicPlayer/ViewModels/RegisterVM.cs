using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using DialogHostAvalonia;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.Resources;
using ReactiveUI;

namespace MusicPlayer.ViewModels
{
    public class RegisterVM : ViewModelBase
    {
        private const ushort EMAIL_ERROR_TIME = 3000;
        private const ushort REGISTERED_SUCCES_TIME = 400;
        private const ushort TIME_BEFORE_CLOSING_DIALOG = 800;
        private string username;
        private string password;
        private string email;
        private bool emailerror = false;
        private bool successvisible = false;
        public bool EmailErrorVisible
        {
            get => emailerror;
            set => this.RaiseAndSetIfChanged(ref emailerror, value);
        }
        public bool SuccessVisible
        {
            get => successvisible;
            set => this.RaiseAndSetIfChanged(ref successvisible, value);
        }
        public string Username
        {
            get => username;
            set => this.RaiseAndSetIfChanged(ref username, value);
        }
        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }
        public string Email
        {
            get => email;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public ReactiveCommand<DialogHost , Unit> CloseDialogCommand { get; }

        public RegisterVM()
        {
            
            var isInputValid = this.WhenAnyValue(x => x.Username, x => x.Password, x => x.Email,
                (username, password, email) => (!string.IsNullOrWhiteSpace(username)
                && !string.IsNullOrWhiteSpace(password)
                && !string.IsNullOrWhiteSpace(email)));
            RegisterCommand = ReactiveCommand.Create(AddAccountToDB, isInputValid);
            CloseDialogCommand = ReactiveCommand.Create<DialogHost>(CloseDialog);

        }
        private void CloseDialog(DialogHost dialog)
        {
            dialog.CurrentSession!.Close();
        }
        private async void AddAccountToDB()
        {
            //add
            using (var context = new DatabaseContext())
            {
                var user = new User(Utilities.GenerateUserId(), Username!, Password!, Email!);

                var exists = await context.Credentials
                    .FirstOrDefaultAsync(user => user.Email == this.Email).ConfigureAwait(false);

                if (exists != null)
                {
                    EmailErrorVisible = true;
                    CloseEmailError();
                }
                else
                {
                    SuccessVisible = true;
                    CloseSuccessRegistration();
                    await context.Credentials.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }
       
    
             

        }
        private async void CloseEmailError()
        {
            await Task.Delay(EMAIL_ERROR_TIME);
            EmailErrorVisible = false;
        }
        private async void CloseSuccessRegistration()
        {
            await Task.Delay(REGISTERED_SUCCES_TIME);
            SuccessVisible = false;

        }
    }
}
