using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ColoringApp.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Views;
using System.Threading.Tasks;
using System.Drawing;
using ColoringApp.Core.Services;
using System.IO;

namespace ColoringApp.Core.ViewModels
{
	public class CharacterListViewModel : MvxViewModel
	{
		private (byte[], string) _characterphoto;
		private CharactersService _charactersService;
		public (byte[], string) CharacterPhoto {
			get {
				_characteritems[0].CharacterName = _characterphoto.Item2;
				_charactersService.SavePhoto(_characterphoto.Item1, _characterphoto.Item2);
				return _characterphoto; }
			set {
				_characterphoto = value;
				_characteritems[0].CharacterName = _characterphoto.Item2;
				_charactersService.SavePhoto(_characterphoto.Item1, _characterphoto.Item2);
			}
		}
		private MvxObservableCollection<Character> _characteritems;
		public MvxObservableCollection<Character> CharacterItems
		{
			get
			{
				return _characteritems;
			}
			private set
			{
				/*_characteritems = value;
				RaisePropertyChanged(() => CharacterItems);*/
			}
		}

		public void ShowCharacterCommand(Character item)
		{
			if (!item.CharacterEnabled)
			{
				return;
			}
			_navigationService.Navigate<CharacterViewModel>();

		}


		private readonly IMvxNavigationService _navigationService;
		public CharacterListViewModel(IMvxNavigationService navigationService)
		{

			_navigationService = navigationService;
			_charactersService = new CharactersService();
			_characteritems = new MvxObservableCollection<Character>();
			
			LoadCharacters();
		}


		public MvxNotifyTask LoadCharactersTask { get; private set; }
		private async void LoadCharacters()
		{
			var result = await _charactersService.GetCharactersAsync();
			for (int i = 0; i < result.Count; i++)
			{
				_characteritems.Add(new Character {CharacterName = result[i].CharacterName, CharacterEnabled = result[i].CharacterEnabled, DrawName = result[i].DrawName});
			}
		}
		

	}
}
