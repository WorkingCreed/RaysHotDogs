using System.Net;
using Android.Graphics;

namespace RaysHotDogs.Droid.Utility
{
  public static class ImageHelper
  {
    public static Bitmap GetImageBitmapFromUrl(string url)
    {
      Bitmap imageBitmap = null;

      using (WebClient webClient = new WebClient())
      {
        byte[] bytes = webClient.DownloadData(url);
        if (bytes != null && bytes.Length > 0)
        {
          imageBitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
        }
      }

      return imageBitmap;
    }

    public static Bitmap GetImageBitmapFromFilePath(string fileName, int width, int height)
    {
      // First we get the the dimensions of the file on disk
      BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
      BitmapFactory.DecodeFile(fileName, options);

      // Next we calculate the ratio that we need to resize the image by
      // in order to fit the requested dimensions.
      int outHeight = options.OutHeight;
      int outWidth = options.OutWidth;
      int inSampleSize = 1;

      if (outHeight > height || outWidth > width)
      {
        inSampleSize = outWidth > outHeight
                           ? outHeight / height
                           : outWidth / width;
      }

      // Now we will load the image and have BitmapFactory resize it for us.
      options.InSampleSize = inSampleSize;
      options.InJustDecodeBounds = false;
      Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

      return resizedBitmap;
    }
  }
}