using ReactiveUI;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class RegWindowViewModel : ViewModelBase
    {
        private bool _IsLoginOrReg = false;
        private int _PanelHight = 175;
        private int _WinHight = 250;
        private bool _closing = false;
        public bool IsLoginOrReg
        {
            get { return _IsLoginOrReg; }
            set { this.RaiseAndSetIfChanged(ref _IsLoginOrReg, value); }
        }
        public int PanelHight
        {
            get { return _PanelHight; }
            set { this.RaiseAndSetIfChanged(ref _PanelHight, value); }
        }
        public int WinHight
        {
            get { return _WinHight; }
            set { this.RaiseAndSetIfChanged(ref _WinHight, value); }
        }
        public bool Closing
        {
            get { return _closing; }
            set { this.RaiseAndSetIfChanged(ref _closing, value); }
        }
        public void LogOrReg()
        {
            IsLoginOrReg = !IsLoginOrReg;
            if (IsLoginOrReg)
            {
                WinHight = 400;
                PanelHight = 230;
            }
            else
            {
                WinHight = 250;
                PanelHight = 175;
            }
            Name = string.Empty;
            Email = string.Empty;
            Pass = string.Empty;
        }
        public void ButtonSignIn()
        {

        }
        public void ButtonSignUp()
        {
            Manager.AddUser(Name, Email, Pass);
            Manager.AddUser("aaa", "aaa", "aaa");
            Closing = true;
            Manager.Reg = true;
        }
        public bool NotRegistrated = true;
        public string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); }
        }
        public string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { this.RaiseAndSetIfChanged(ref _email, value); }
        }
        public string _pass = string.Empty;
        public string Pass
        {
            get { return _pass; }
            set { this.RaiseAndSetIfChanged(ref _pass, value); }
        }

    }
}
