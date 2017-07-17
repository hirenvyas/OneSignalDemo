using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Com.OneSignal;
using Com.OneSignal.Abstractions;

namespace OneSignalDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            

            LoadApplication(new App());
           
            OneSignal.Current.StartInit("fb772e91-d712-4924-859f-23bc28bce6d6").HandleNotificationReceived(HandleNotificationReceived)
                  .EndInit();
            OneSignal.Current.RegisterForPushNotifications();
            OneSignal.Current.IdsAvailable(IdsAvailable);
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                UIApplication.SharedApplication.RegisterUserNotificationSettings(
                    UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.None | UIUserNotificationType.Sound,
                        null));
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(
                    UIRemoteNotificationType.Alert | UIRemoteNotificationType.None | UIRemoteNotificationType.Sound);
            }
            return base.FinishedLaunching(app, options);
        }
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            OneSignal.Current.IdsAvailable(IdsAvailable);
        }
        private void HandleNotificationReceived(OSNotification notification)
        {

        }
        

        private void IdsAvailable(string playerID, string pushToken)
        {
            var data = playerID;
        }
    }
}
