using MusicStreaming.Core;
using MusicStreaming.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using static System.Net.Mime.MediaTypeNames;

namespace MusicStreaming.MVVM.ViewModel
{
    /// <summary>
    /// Represents the view model for the sign-up process.
    /// </summary>
    class SignUpViewModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets the view model for the sign-up form.
        /// </summary>
        public SignUpFormViewModel FormVM { get; set; }

        /// <summary>
        /// Gets or sets the view model for the sign-up success page.
        /// </summary>
        public SignUpSuccessViewModel SuccessVM { get; set; }

        private object _currentView;

        /// <summary>
        /// Gets or sets the current view.
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the sign-up command.
        /// </summary>
        public ICommand SignUpCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpViewModel"/> class.
        /// </summary>
        public SignUpViewModel()
        {
            SignUpCommand = new RelayCommand(ExecuteSignUpCommand, CanExecuteSignUpCommand);

            FormVM = new SignUpFormViewModel();
            SuccessVM = new SignUpSuccessViewModel();
            CurrentView = FormVM;
        }

        private void ExecuteSignUpCommand(object obj)
        {

            using (MusicStreamingDataContext context = new MusicStreamingDataContext())
            {
                var user = new User
                {
                    Username = FormVM.Username,
                    Password = SecureStringToString(FormVM.Password)

                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            CurrentView = SuccessVM;
        }

        private bool CanExecuteSignUpCommand(object arg)
        {
            var tempPassword = new System.Net.NetworkCredential(string.Empty, FormVM.Password).Password;
            return (string.IsNullOrWhiteSpace(FormVM.Username) || tempPassword == null) ? false : true;
        }

        private String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }


    }
}
