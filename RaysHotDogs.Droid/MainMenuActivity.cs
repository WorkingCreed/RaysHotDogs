using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Ray's Hot Dogs", MainLauncher = true, Icon="@drawable/smallIcon")]
  public class MainMenuActivity : Activity
  {
    private Button _orderButton;
    private Button _cartButton;
    private Button _aboutButton;
    private Button _mapButton;
    private Button _takePictureButton;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.MainMenu);
      FindViews();
      HandleEvents();
    }

    private void FindViews()
    {
      _orderButton = FindViewById<Button>(Resource.Id.orderButton);
      _cartButton = FindViewById<Button>(Resource.Id.cartButton);
      _aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
      _mapButton = FindViewById<Button>(Resource.Id.mapButton);
      _takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
    }

    private void HandleEvents()
    {
      _orderButton.Click += OrderButtonOnClick;
      _cartButton.Click += CartButtonOnClick;
      _aboutButton.Click += AboutButtonOnClick;
      _mapButton.Click += MapButtonOnClick;
      _takePictureButton.Click += TakePictureButtonOnClick;
    }

    private void TakePictureButtonOnClick(object sender, EventArgs eventArgs)
    {
      Intent intent = new Intent(this, typeof(TakePictureActivity));
      StartActivity(intent);
    }

    private void MapButtonOnClick(object sender, EventArgs eventArgs)
    {
      Intent intent = new Intent(this, typeof(RayMapActivity));
      StartActivity(intent);
    }

    private void AboutButtonOnClick(object sender, EventArgs eventArgs)
    {
      Intent intent = new Intent(this, typeof(AboutActivity));
      StartActivity(intent);
    }

    private void CartButtonOnClick(object sender, EventArgs eventArgs)
    {
      throw new NotImplementedException();
    }

    private void OrderButtonOnClick(object sender, EventArgs eventArgs)
    {
      Intent intent = new Intent(this, typeof(HotDogMenuActivity));
      StartActivity(intent);
    }
  }
}