using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System.Threading.Tasks;
using ColoringApp.Core.ViewModels;
namespace ColoringApp.Core
{
	class AppStart:MvxAppStart
	{
		public AppStart(IMvxApplication app, IMvxNavigationService mvxNavigationService)
			:base(app, mvxNavigationService)
		{
		}

		protected override Task NavigateToFirstViewModel(object hint = null)
		{
			return NavigationService.Navigate<CharacterListViewModel>();
		}
	}
}
