using lab12.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab12
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TaskView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
