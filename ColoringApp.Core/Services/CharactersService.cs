using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ColoringApp.Core.Models;
using MvvmCross.Plugin.PictureChooser;
using MvvmCross;
using MvvmCross.Plugin.File;
namespace ColoringApp.Core.Services
{
	public class CharactersService : ICharactersService
	{
		private List<Character> _characteritems;
		private int imageCounter;
		public CharactersService()
			: base()
		{
			imageCounter = 0;
			_characteritems = new List<Character>();
			AddExampleCharacters();
		}



		public void SavePhoto(byte[] bytes, string name)
		{
			if (string.IsNullOrWhiteSpace(bytes.ToString()))
			{
				return;
			}

			var filestore = Mvx.IoCProvider.Resolve<IMvxFileStore>();
			string file = bytes.ToString();
			string path = Path.Combine("Pictures/", (name + ".jpg"));
			filestore.WriteFile(path, file);
			if (filestore.Exists(path))
			{
				imageCounter++;
			}
		}
		public async Task<List<Character>> GetCharactersAsync()
		{
			 return  _characteritems;
		}



		void AddExampleCharacters()
		{
			for (int i = 0; i < 24; i++)
			{
				if (i == 0)
				{
					_characteritems.Add(new Character { CharacterName = (i + 1).ToString(), DrawName = "vector_green_rect", CharacterEnabled = false });
					continue;
				}
				_characteritems.Add(new Character { CharacterName = (i + 1).ToString(), DrawName = "vector_green_rect", CharacterEnabled = true });
			}
		}
	}
}
