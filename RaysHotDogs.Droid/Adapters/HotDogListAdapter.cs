using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Droid.Utility;

namespace RaysHotDogs.Droid.Adapters
{
  public class HotDogListAdapter : BaseAdapter<HotDog>
  {
    IList<HotDog> _items;
    Activity _context;

    public HotDogListAdapter(Activity context, IList<HotDog> items) : base()
    {
      _context = context;
      _items = items;
    }

    public override long GetItemId(int position)
    {
      return position;
      
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      HotDog hotDog = _items[position];


      Bitmap bitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + hotDog.ImagePath +
                                                                 ".jpg");

      if (convertView == null)
      {
        convertView = _context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
      }

      convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = hotDog.Name;
      convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = hotDog.ShortDescription;
      convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$" + hotDog.Price;
      convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(bitmap);
      
//      Demo 2
//      if (convertView == null)
//      {
//        convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
//      }
//      convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = hotDog.Name;
//      convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(bitmap);

//      Demo 1 
//      if (convertView == null)
//      {
//        convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
//      }
//      convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = hotDog.Name;
      return convertView;
    }

    public override int Count => _items.Count;

    public override HotDog this[int position] => _items[position];
  }
}