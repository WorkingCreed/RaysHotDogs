using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Services;
using RaysHotDogs.Droid.Utility;

namespace RaysHotDogs.Droid
{
  [Activity(Label = "Hot dog detail")]
  public class HotDogDetailActivity : Activity
  {
    private ImageView _hotDogImageView;
    private TextView _hotDogNameTextView;
    private TextView _shortDescriptionTextView;
    private TextView _descriptionTextView;
    private TextView _priceTextView;
    private EditText _amountEditText;
    private Button _cancelButton;
    private Button _orderButton;

    private HotDog _selectedHotDog;
    private HotDogDataService _dataService;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.HotDogDetailView);
      _dataService = new HotDogDataService();
      int hotDogId = Intent.Extras.GetInt("selectedHotDogId");
      _selectedHotDog = _dataService.GetHotDogById(hotDogId);
      FindViews();
      BindData();
      HandleEvents();
      // Create your application here
    }

    private void FindViews()
    {
      _hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
      _hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
      _shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
      _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
      _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
      _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
      _cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
      _orderButton = FindViewById<Button>(Resource.Id.orderButton);
    }

    private void BindData()
    {
      _hotDogNameTextView.Text = _selectedHotDog.Name;
      _shortDescriptionTextView.Text = _selectedHotDog.ShortDescription;
      _descriptionTextView.Text = _selectedHotDog.Description;
      _priceTextView.Text = "Price: " + _selectedHotDog.Price;

      Bitmap imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" +
                                                                 _selectedHotDog.ImagePath + ".jpg");
      _hotDogImageView.SetImageBitmap(imageBitmap);
    }

    private void HandleEvents()
    {
      _orderButton.Click += OrderButtonOnClick;
      _cancelButton.Click += CancelButtonOnClick;
    }

    private void CancelButtonOnClick(object sender, EventArgs eventArgs)
    {
      //TODO
    }

    private void OrderButtonOnClick(object sender, EventArgs e)
    {
      int amount = Int32.Parse(_amountEditText.Text);

      Intent intent = new Intent();
      intent.PutExtra("selectedHotDogId", _selectedHotDog.HotDogId);
      intent.PutExtra("amount", amount);
      SetResult(Result.Ok, intent);
      this.Finish();
    }
  }
}