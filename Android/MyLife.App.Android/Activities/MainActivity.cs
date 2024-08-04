using Android.App;
using Android.Content.PM;

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
}
