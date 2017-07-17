using Com.OneSignal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OneSignalDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OneSignalDemo.MainPage();
            OneSignal.Current.StartInit("26f99155-3a2b-46f9-9ddc-a402a2a504a1")
                  .EndInit();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
