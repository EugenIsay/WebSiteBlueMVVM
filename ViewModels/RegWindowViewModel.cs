using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBlueMVVM;
using Avalonia;
using ReactiveUI;
using Avalonia.Controls;

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
            if (IsLoginOrReg) {
                WinHight = 400;
                PanelHight = 230;
            }
            else
            {
                WinHight = 250;
                PanelHight = 175;
            }
        }
        public void ButtonSignIn()
        {

        }
        public void ButtonSignUp()
        {
            Manager.AddUser(Name, Email, Pass);
            Closing = true;

        }
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
