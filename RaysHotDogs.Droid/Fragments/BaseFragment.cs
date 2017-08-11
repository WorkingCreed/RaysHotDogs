using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Services;

namespace RaysHotDogs.Droid.Fragments
{
  public class BaseFragment : Fragment
  {
    protected ListView ListView;
    protected HotDogDataService HotDogDataService;
    protected IList<HotDog> HotDogs;

    public BaseFragment()
    {
      HotDogDataService = new HotDogDataService();
    }

    protected void HandleEvents()
    {
      ListView.ItemClick += ListViewOnItemClick;
    }

    protected void FindViews()
    {
      ListView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
    }

    private void ListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
    {
      HotDog hotDog = HotDogs[itemClickEventArgs.Position];

      Intent intent = new Intent();
      intent.SetClass(Activity, typeof(HotDogDetailActivity));
      intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

      StartActivityForResult(intent, 100);
    }
  }
}