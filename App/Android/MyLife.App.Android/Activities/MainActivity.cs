using Android.App;
using Android.Content.PM;
using Android.OS;

using Avalonia;
using Avalonia.Android;
using Avalonia.Maui;


namespace MyLife.App.Android.Activities;


[Activity(
    Label = "My Life",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/logo_masterman",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MobileMainActivity : AvaloniaMainActivity<MyLifeAndroidApp>
{
	protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
	    => base.CustomizeAppBuilder(builder)
		    .WithInterFont()
		    .UseMaui<MyLifeAndroidMauiApp>(this);

	protected override void OnCreate(Bundle? bundle)
	{
		var assets = this.Assets;
		if (assets == null)
			throw new System.Exception("Unable to retrieve AssetManager.");

		MyLifeAndroidApp.SetAssetManager(assets);

		base.OnCreate(bundle);
	}
}
