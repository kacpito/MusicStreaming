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
    /// <summary>
    /// Represents the view model for the login view.
    /// </summary>
    class LoginViewModel : ObservableObject
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the view is visible.
        /// </summary>
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public ICommand LoginCommand { get; }

        /// <summary>
        /// Gets the sign-up command.
        /// </summary>
        public ICommand SignUpCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
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
