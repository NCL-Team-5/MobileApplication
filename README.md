# MobileApplication

<h3>Enable Multi-Dex</h3>

<b>Windows:</b> https://riptutorial.com/xamarin-android/example/29859/enabling-multidex-in-your-xamarin-android-apk

<b>Mac:</b> Select SaggezzaApp.Android folder, click Project tab in the menu bar -> SaggezzaApp.Android Options -> Android Build -> Check Enable Multi-Dex

**If you get this error "INSTALL_FAILED_INVALID_APK: Package couldn't be installed base.apk code is missing" then un-enable Multi-Dex and change the Dex compiler to d8 (on the same settings page), Visual Studio update broke the app**

<h3>Install Packages</h3>

Right Click on SaggezzaApp (master) folder -> Manage NuGet packages and install the following packages:

[Plugin.CloudFirestore](https://www.nuget.org/packages/Plugin.CloudFirestore/) [![NuGet](https://img.shields.io/nuget/vpre/Plugin.CloudFirestore.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.CloudFirestore/) (Add to all 3 solutions when prompted)

[FirebaseStorage.net](https://nuget.org/packages/FirebaseStorage.net/) [![NuGet](https://img.shields.io/nuget/vpre/FirebaseStorage.net.svg?label=NuGet)](https://www.nuget.org/packages/FirebaseStorage.net/) (Add to all 3 solutions when prompted)

[Xam.Plugin.Media](https://nuget.org/packages/Xam.Plugin.Media/) [![NuGet](https://img.shields.io/nuget/vpre/Xam.Plugin.Media.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Media/) (Add to all 3 solutions when prompted)

[Xam.Plugins.Notifier](https://nuget.org/packages/Xam.Plugin.Media/) [![NuGet](https://img.shields.io/nuget/vpre/Xam.Plugins.Notifier.svg?label=NuGet)](https://www.nuget.org/package/Xam.Plugins.Notifier/) (Add to all 3 solutions when prompted)

[Plugin.FirebaseAuth](https://nuget.org/packages/Plugin.FirebaseAuth) [![NuGet](https://img.shields.io/nuget/vpre/Plugin.FirebaseAuth.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.FirebaseAuth/) (Add to all 3 solutions when prompted)

[Plugin.GoogleClient](https://nuget.org/packages/Plugin.GoogleClient) [![NuGet](https://img.shields.io/nuget/vpre/Plugin.GoogleClient.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.GoogleClient/) (Add to all 3 solutions when prompted)

[Xamarin.GooglePlayServices.Auth](https://nuget.org/packages/Xamarin.GooglePlayServices.Auth) [![NuGet](https://img.shields.io/nuget/vpre/Xamarin.GooglePlayServices.Auth.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.GooglePlayServices.Auth/) **(Add only to .Android solution)**
<h3>Permissions</h3>

Make sure you give the app permissions to access storage (so it can access camera gallery) this may need to be done in settings if you're not prompted in app

**Also find the Google-Services.json file in the SaggezzaApp.Android project, right click on it, go to Build Action and make sure GoogleServicesJson is selected.**

The iOS version builds with errors but the Android version is fine
