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
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Services;
using RaysHotDogs.Droid.Adapters;
using RaysHotDogs.Droid.Fragments;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Hot Dog Menu")]
  public class HotDogMenuActivity : Activity
  {
    private ListView _hotDogListView;
    private IList<HotDog> _allHotDogs;
    private HotDogDataService _hotDogDataService;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.HotDogMenuView);
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

      AddTab("Favorites", Resource.Drawable.FavoritesIcon, new FavoriteHotDogFragment());
      AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
      AddTab("Veggie Lovers", Resource.Drawable.veggieloversicon, new VeggieLoversFragment());

//      _hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);
//      _hotDogDataService = new HotDogDataService();
//      _allHotDogs = _hotDogDataService.GetAllHotDogs();
//      _hotDogListView.Adapter = new HotDogListAdapter(this, _allHotDogs);
//      _hotDogListView.FastScrollEnabled = true;
//      _hotDogListView.ItemClick += HotDogListViewOnItemClick;
      // Create your application here
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
      base.OnActivityResult(requestCode, resultCode, data);

      if (resultCode == Result.Ok && requestCode == 100)
      {
        HotDog hotDog = _hotDogDataService.GetHotDogById(data.GetIntExtra("selectedHotDogId", 0));

        AlertDialog.Builder dialog = new AlertDialog.Builder(this);
        dialog.SetTitle("Confirmation");
        dialog.SetMessage($"You've added {data.GetIntExtra("amount", 0)} time(s) the {hotDog.Name}");
        dialog.Show();
      }
    }

    private void AddTab(string tabText, int iconResourceId, Fragment view)
    {
      ActionBar.Tab tab = ActionBar.NewTab();
      tab.SetText(tabText);
      tab.SetIcon(iconResourceId);

    tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
    {
      Fragment fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
      if (fragment != null)
      {
        e.FragmentTransaction.Remove(fragment);
      }
      e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
    };

      tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs args)
      {
        args.FragmentTransaction.Remove(view);
      };

      ActionBar.AddTab(tab);
    }

    private void HotDogListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
    {
      HotDog hotDog = _allHotDogs[itemClickEventArgs.Position];

      Intent intent = new Intent();
      intent.SetClass(this, typeof(HotDogDetailActivity));
      intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

      StartActivityForResult(intent, 100);
    }
  }
}