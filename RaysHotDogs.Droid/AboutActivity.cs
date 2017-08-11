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

namespace RaysHotDogs.Droid
{
  [Activity(Label = "About Ray's Hot Dogs")]
  public class AboutActivity : Activity
  {
    private TextView _phoneNumberTextView;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.AboutView);
      FindViews();
      HandleEvents();
      // Create your application here
    }

    private void FindViews()
    {
      _phoneNumberTextView = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
    }

    private void HandleEvents()
    {
      _phoneNumberTextView.Click += PhoneNumberTextViewOnClick;
    }

    private void PhoneNumberTextViewOnClick(object sender, EventArgs eventArgs)
    {
      Intent intent = new Intent(Intent.ActionCall);
      intent.SetData(Android.Net.Uri.Parse("tel:" + _phoneNumberTextView.Text));
      StartActivity(intent);
    }
  }
}