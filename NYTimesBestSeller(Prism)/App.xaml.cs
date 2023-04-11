using DryIoc;
using Example;
using NYTimesBestSeller_Prism_.Interfaces;
using NYTimesBestSeller_Prism_.Services;
using NYTimesBestSeller_Prism_.ViewModels;
using NYTimesBestSeller_Prism_.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace NYTimesBestSeller_Prism_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IBookServices, BookServices>();
        }
    }
}
