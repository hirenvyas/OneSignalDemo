using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Android.Support.V7.App;
using Android.Content;
using Android.Media;
using Android.Gms.Gcm;
using Android.Util;

namespace OneSignalDemo.Droid
{
    [Activity(Label = "OneSignalDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            OneSignal.Current.StartInit("fb772e91-d712-4924-859f-23bc28bce6d6").HandleNotificationReceived(HandleNotificationReceived)
                   .EndInit();
            OneSignal.Current.RegisterForPushNotifications();
            OneSignal.Current.IdsAvailable(IdsAvailable);           
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void HandleNotificationReceived(OSNotification notification)
        {
            OSNotificationPayload payload = notification.payload;
            string message = payload.body;

            notification.silentNotification = true;

            //notification.shown = false;
            payload.smallIcon = "c:/users/admin/documents/visual studio 2017/Projects/OneSignalDemo/OneSignalDemo/OneSignalDemo.Android/Resources/drawable/icon.png";

            notification.shown = false;

            //Context context = Application.Context;
            //var manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            //var intent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            //intent.AddFlags(ActivityFlags.ClearTop);

            //var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent);
            //var builder = new NotificationCompat.Builder(context)
            //    .SetSmallIcon(Resource.Drawable.icon)
            //    .SetContentTitle("Laundr")
            //    .SetStyle(new NotificationCompat.BigTextStyle().BigText(message))
            //    .SetContentText(message)
            //    .SetAutoCancel(true)
            //    .SetContentIntent(pendingIntent).SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));
            //manager.Notify(0, builder.Build());

            //print("GameControllerExample:HandleNotificationReceived: " + message);
            //print("displayType: " + notification.displayType);
            //extraMessage = "Notification received with text: " + message;
        }

        private void IdsAvailable(string playerID, string pushToken)
        {
            var data = playerID;
        }
       
    }


    //[Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
    //class MyGcmListenerService : GcmListenerService
    //{
    //    public void OnMessageReceived(OSNotification notification)
    //    {
    //        OSNotificationPayload payload = notification.payload;
    //        string message = payload.body;
    //        //  Log.Debug("MyGcmListenerService", "From:    " + from);
    //        // Log.Debug("MyGcmListenerService", "Message: " + message);
    //        SendNotification(message);
    //    }
    //    void SendNotification(string message)
    //    {
    //        Context context = Application.Context;
    //        var manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
    //        var intent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
    //        intent.AddFlags(ActivityFlags.ClearTop);

    //        var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent);


    //        var builder = new NotificationCompat.Builder(context)
    //             .SetSmallIcon(Resource.Drawable.icon)
    //             .SetContentTitle("Laundr")
    //             .SetStyle(new NotificationCompat.BigTextStyle().BigText(message))
    //             .SetContentText(message)
    //             .SetAutoCancel(true)
    //             .SetContentIntent(pendingIntent).SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));

    //        manager.Notify(0, builder.Build());

    //        //var intent = new Intent(this, typeof(MainActivity));
    //        //intent.AddFlags(ActivityFlags.ClearTop);
    //        //var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

    //        //var notificationBuilder = new Notification.Builder(this)
    //        //    .SetSmallIcon(Resource.Drawable.icon)
    //        //    .SetContentTitle("Laundr")
    //        //    .SetContentText(message)
    //        //    .SetAutoCancel(true)
    //        //    .SetContentIntent(pendingIntent).SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));

    //        //var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
    //        //notificationManager.Notify(0, notificationBuilder.Build());
    //    }
    //}
}

