using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using MusicStreaming.MVVM.View;

namespace MusicStreaming.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //Properties
        public string Username 
        { 
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password 
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        { 
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        { 
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            SignUpCommand = new RelayCommand(ExecuteSignUpCommand);
        }

        private void ExecuteSignUpCommand(object obj)
        {
            var signUpView = new SignUpView();
            signUpView.Show();
        }

        private bool CanExecuteLoginCommand(object arg) =>
            (string.IsNullOrWhiteSpace(Username) || Password == null) ? false : true;

        private void ExecuteLoginCommand(object obj)
        {
            var tempPassword = new System.Net.NetworkCredential(string.Empty, Password).Password;

            using (MusicStreamingDataContext context = new MusicStreamingDataContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == tempPassword);

                if (user != null)
                {
                    SessionManager.SetLoggedUserId(user.Id);
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    ErrorMessage = "User not found / Password incorrect";
                }
            }
        }
    }
}
