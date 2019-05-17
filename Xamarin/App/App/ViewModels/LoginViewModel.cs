namespace App.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Services;
    using Xamarin.Forms;

    public class LoginViewModel:BaseViewModel
    {
        #region Attributes
        string email;
        string password;
        bool isrunning;
        bool isenabled;
        ApiService ApiService;
        #endregion

        #region Properties
        public string Email
        {
            get
            {
                return this.email;
            }
             set
            {
                SetValue(ref this.email, value);
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                SetValue(ref this.password, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isrunning;
            }
            set
            {
                SetValue(ref this.isrunning, value);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return this.isenabled;
            }
            set
            {
                SetValue(ref this.isenabled, value);
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(cmdLogin);
            }
        }

        private async void cmdLogin()
        {
            if(String.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Email Empty", 
                                                        "Please enter your email",
                                                        "Accept");
                return;
            }

            if(String.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Password Empty",
                                                        "Please enter your password",
                                                        "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            var conexion = await this.ApiService.CheckConnection();

            if (!conexion.IsSuccess)

            {

                this.IsRunning = false;

                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(

                   "ERROR",

                   conexion.Message,

                   "Accept");

                return;

            }
        }
        #endregion

        public LoginViewModel()
        {

        }
    }
}
