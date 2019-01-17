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
using Android.Graphics.Drawables;
using Java.Lang;
using Android.Graphics;
using System.IO;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target;
using System.Reflection;
using MvvmCross.Plugin.Color;
using MvvmCross.UI;
using System.Globalization;
using MvvmCross.Converters;
using MvvmCross.Binding.BindingContext;
using Android.Provider;
using Java.Text;
using Java.Util;
using Android.Support.Design.Widget;

namespace ColoringApp.Android.Views
{
	[Activity(Label = "CharacterListView")]

	public class CharacterListView : MvxActivity<CharacterListViewModel>
	{
		private (byte[], string) _characterphoto;
		private int REQUEST_IMAGE_CAPTURE = 1;
		public (byte[], string) CharacterPhoto {
			get {
				return _characterphoto;
			}
			set {
				_characterphoto = value;
			} }
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			
			

			var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.Click += BtnCamera_Click;

		}
		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			SetContentView(Resource.Layout.CharacterListView);
			var set = this.CreateBindingSet<CharacterListView, CharacterListViewModel>();
			set.Bind(this).For(view => view.CharacterPhoto).To(viewModel => viewModel.CharacterPhoto).OneWayToSource();
			set.Apply();
		}
		protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			Bitmap bitmap = (Bitmap)data.Extras.Get("data");
			MemoryStream stream = new MemoryStream();
			bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
			byte[] bytes = stream.ToArray();
			CharacterPhoto = (bytes, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
		}

		private void BtnCamera_Click(object sender, System.EventArgs e)
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			StartActivityForResult(intent, REQUEST_IMAGE_CAPTURE);
		}

	}

	public class ItemBackgroundValueConverter : MvxValueConverter<bool, ColorDrawable>
	{
		protected override ColorDrawable Convert(bool value, System.Type targetType, object parameter, CultureInfo culture)
		{
			return value ? new ColorDrawable(new Color(0, 255, 0)) : new ColorDrawable(new Color(169, 169, 169));
		}
	}
}