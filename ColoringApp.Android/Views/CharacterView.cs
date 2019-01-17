using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using ColoringApp.Core.ViewModels;
using Android.Provider;
using Android.Graphics;
using System.IO;

namespace ColoringApp.Android.Views
{
	[Activity(Label = "CharacterView")]
	public class CharacterView : MvxActivity<CharacterViewModel>
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.CharacterView);

			// Create your application here
		}

		

	}
}