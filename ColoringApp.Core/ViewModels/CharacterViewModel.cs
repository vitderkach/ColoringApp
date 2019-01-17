using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Threading.Tasks;

namespace ColoringApp.Core.ViewModels
{
	public class CharacterViewModel : MvxViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public CharacterViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
			//DestroyCharacterCommand = new MvxAsyncCommand(DestroyCharacter);
		}

		public IMvxCommand DestroyCharacterCommand { get
			{ return new MvxAsyncCommand(DestroyCharacter); }
			 } 

		public async Task DestroyCharacter()
		{
			await _navigationService.Close(this);
		}
	}
}
