package md5a449c29a02e22951ca16a6588de57ec2;


public class BaseFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RaysHotDogs.Droid.Fragments.BaseFragment, RaysHotDogs.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseFragment.class, __md_methods);
	}


	public BaseFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BaseFragment.class)
			mono.android.TypeManager.Activate ("RaysHotDogs.Droid.Fragments.BaseFragment, RaysHotDogs.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
