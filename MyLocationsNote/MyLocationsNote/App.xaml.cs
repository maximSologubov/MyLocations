using MyLocationsNote.Services.Settings;
using MyLocationsNote.Themes;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLocationsNote
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        #region --- Private fields

        private ISettinngsManager _settinngsManager;
       /* private IRepository repository;
        private IDbService dbService;
        private IRegistration registration;
        private IAuthorization authorizationService;*/

        #endregion

        #region --- Properties ---

        public ISettinngsManager SettingsManager => _settinngsManager ??= Container.Resolve<SettingsManager>();
        /*public IRepository Repository => repository ??= Container.Resolve<Repository>();
        public IDbService DbService => dbService ??= Container.Resolve<DbService>();
        public IRegistration Registration => registration ??= Container.Resolve<Registration>();
        public IAuthorization AuthorizationService => authorizationService ??= Container.Resolve<Authorization>();*/

        #endregion

        #region --- Overrides ---
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Services

            containerRegistry.RegisterInstance<ISettinngsManager>(Container.Resolve<SettingsManager>());
            /*containerRegistry.RegisterInstance<IRepository>(Container.Resolve<Repository>());
            containerRegistry.RegisterInstance<IDbService>(Container.Resolve<DbService>());
            containerRegistry.RegisterInstance<IRegistration>(Container.Resolve<Registration>());
            containerRegistry.RegisterInstance<IAuthorization>(Container.Resolve<Authorization>());*/

            //Navigation
            /*containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MainListView, MainListViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<AddEditProfilePage, AddEditProfileViewModel>();*/

            // dialogs
            //containerRegistry.RegisterDialog<ItemTappedDialog, ItemTappedDialogModel>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            ResourceLoader();
        }
        #endregion

        #region --- Private helpers ---
        private void ResourceLoader()
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            switch (SettingsManager.DarkTheme)
            {
                case false:
                    mergedDictionaries.Add(new LightTheme());
                    break;

                case true:
                    mergedDictionaries.Add(new DarkTheme());
                    break;
            }
        }

        #endregion
    }
}
