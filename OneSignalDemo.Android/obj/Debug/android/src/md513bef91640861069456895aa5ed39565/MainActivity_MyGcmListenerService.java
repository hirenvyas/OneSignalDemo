package md513bef91640861069456895aa5ed39565;


public class MainActivity_MyGcmListenerService
	extends com.google.android.gms.gcm.GcmListenerService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("OneSignalDemo.Droid.MainActivity+MyGcmListenerService, OneSignalDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_MyGcmListenerService.class, __md_methods);
	}


	public MainActivity_MyGcmListenerService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_MyGcmListenerService.class)
			mono.android.TypeManager.Activate ("OneSignalDemo.Droid.MainActivity+MyGcmListenerService, OneSignalDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
