using Avalonia.Controls;

using Microsoft.Maui.Devices;

using MyLife.App.Shared;
using MyLife.App.Android.UI.Watch.Views;
using MyLife.App.Android.UI.Mobile.Views;
using MyLife.App.Android.UI.Mobile.ViewModels;
using MyLife.App.Android.UI.Watch.ViewModels;
using MyLife.App.Shared.Services.Features;
using Android.Content.Res;
using System.IO;
using Microsoft.Maui.Storage;


namespace MyLife.App.Android;


public class MyLifeAndroidApp: MyLifeApp
{
	protected static AssetManager AssetManager { get; private set; }
	protected bool IsWatchDevice { get; private set; }

	public static void SetAssetManager(AssetManager assetManager) => AssetManager = assetManager;

	protected override void InitPlatform()
	{
		base.InitPlatform();

		var pluginsStorageRootPath = Path.Combine(FileSystem.AppDataDirectory, "plugins");
		if (!Directory.Exists(pluginsStorageRootPath))
		{
			Directory.CreateDirectory(pluginsStorageRootPath);
		}

		foreach (var pluginDirName in AssetManager.List("plugins") ?? [])
		{
			var pluginDirPath = Path.Combine("plugins", pluginDirName);
			var pluginDirStoragePath = Path.Combine(pluginsStorageRootPath, pluginDirName);
			if (!Directory.Exists(pluginDirStoragePath))
			{
				Directory.CreateDirectory(pluginDirStoragePath);

				foreach (var pluginFile in AssetManager.List(pluginDirPath) ?? [])
				{
					var pluginFilePath = Path.Combine(pluginDirPath, pluginFile);
					var pluginFileStoragePath = Path.Combine(pluginDirStoragePath, pluginFile);

					if (!File.Exists(pluginFileStoragePath))
					{
						var file = AssetManager.Open(pluginFilePath);

						using var storageStream = File.OpenWrite(pluginFileStoragePath);
						file.CopyTo(storageStream);
						storageStream.Flush();
						storageStream.Close();
						file.Close();
					}
				}
			}
		}

		PluginManager = new BaseFeaturePluginManager();

		this.IsWatchDevice = DeviceInfo.Idiom == DeviceIdiom.Watch;
	}

	protected Control GetInitialWatchView() => new WatchMainView
	{
		DataContext = new WatchMainViewModel()
		{
			Buttons =
			{
				new() { IconId = "FormatListChecks", Id = "todo", Label = "TODO" },
				new() { IconId = "Note", Id = "notes", Label = "Notes" },
				new() { IconId = "ViewGridPlus", Id = "services", Label = "Services" },
				new() { IconId = "Cog", Id = "settings", Label = "Settings" },
			}
		}
	};
	protected Control GetInitialMobileView() => new MobileMainView
	{
		DataContext = new MobileMainViewModel(PluginManager)
	};

	protected override Control GetInitialView()
		=> this.IsWatchDevice
			? this.GetInitialWatchView()
			: this.GetInitialMobileView();
}
