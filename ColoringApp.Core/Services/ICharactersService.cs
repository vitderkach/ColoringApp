using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ColoringApp.Core.Models;
namespace ColoringApp.Core.Services
{
	public interface ICharactersService
	{

		void SavePhoto(byte[] bytes, string name);
		Task<List<Character>> GetCharactersAsync();
	}
}
