using MusicStreaming.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Represents the view model for the sign-up form.
    /// </summary>
    class SignUpFormViewModel : ObservableObject
    {
        private string _username;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private SecureString _password;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _errorMessage;

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
    }
}
