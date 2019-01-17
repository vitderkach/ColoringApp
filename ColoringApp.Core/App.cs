using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.ViewModels;
using ColoringApp.Core.ViewModels;
using MvvmCross.IoC;

namespace ColoringApp.Core
{
	public class App:MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
	.EndingWith("Service")
	.AsInterfaces()
	.RegisterAsLazySingleton();
			RegisterCustomAppStart<AppStart>();
			RegisterAppStart<CharacterListViewModel>();
		}
	}
}
