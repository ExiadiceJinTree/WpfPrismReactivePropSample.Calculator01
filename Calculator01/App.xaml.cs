using Calculator01.ViewModels;
using Calculator01.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Calculator01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // MainWindowViewModelをSingletonインスタンスとしてDIコンテナに登録。
            containerRegistry.RegisterSingleton<MainWindowViewModel>();
        }
    }
}
