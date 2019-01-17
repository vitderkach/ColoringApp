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
using Android.Content.PM;
namespace ColoringApp.Android
{
	[Activity(Label = "SplashScreeenActivity", MainLauncher =true, NoHistory =true)]
	public class SplashScreeen : MvxSplashScreenActivity
	{
		public SplashScreeen()
			:base(Resource.Layout.SplashScreen)
		{

		}
	}
}