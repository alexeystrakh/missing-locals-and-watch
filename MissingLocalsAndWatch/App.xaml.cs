using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MissingLocalsAndWatch
{
    public partial class App : MyApplication
    {
        public App()
        {
            InitializeComponent();
            Init();
        }

        protected async override Task<Page> CreateMainPage()
        {
            // emulate async work
            await Task.Delay(500);

            return await CreateMasterDetailsPage();
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

    public abstract class MyApplication : ApplicationBase
    {
        public new void Init()
        {
            Page mainPage = null;
            Task.Run(async () => mainPage = await CreateMainPage()).Wait();
            MainPage = mainPage;
        }

        public async Task<Page> CreateMasterDetailsPage()
        {
            // emulate async work
            await Task.Delay(500);

            var mainPage = new MasterDetailPage()
            {
                Master = new Page() { Title = "Menu", BackgroundColor = Color.Green },
                Detail = new NavigationPage(new MainPage() { BackgroundColor = Color.Orange }),
            };

            return mainPage;
        }
    }

    public abstract class ApplicationBase : Application
    {
        protected abstract Task<Xamarin.Forms.Page> CreateMainPage();

        public virtual void Init()
        {
        }
    }
}
