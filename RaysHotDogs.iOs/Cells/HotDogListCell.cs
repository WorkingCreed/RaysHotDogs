using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace RaysHotDogs.iOs.Cells
{
  public class HotDogListCell : UITableViewCell
  {
    private UILabel _nameLabel;
    private UILabel _priceLabel;
    private UIImageView _imageView;


    public HotDogListCell()
    {
      
    }

    public HotDogListCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
    {
      SelectionStyle =  UITableViewCellSelectionStyle.Gray;
      ContentView.BackgroundColor = UIColor.FromRGB(254, 199, 101);
      _imageView = new UIImageView();
      
      _nameLabel = new UILabel()
      {
        Font = UIFont.FromName("AmericanTypewriter", 18f),
        TextColor = UIColor.FromRGB(255,255,255),
        BackgroundColor = UIColor.Clear
      };
      
      _priceLabel = new UILabel()
      {
        Font = UIFont.FromName("AmericanTypewriter", 12f),
        TextColor = UIColor.FromRGB(228, 79, 61),
        BackgroundColor = UIColor.Clear
      };

      ContentView.Add(_nameLabel);
      ContentView.Add(_priceLabel);
      ContentView.Add(_imageView);
    }


    public override void LayoutSubviews()
    {
      base.LayoutSubviews();
      _imageView.Frame = new RectangleF((float) ContentView.Bounds.Width - 63, 5, 33, 33);
      _nameLabel.Frame = new RectangleF(5, 4, (float) ContentView.Bounds.Width - 63, 25);
      _priceLabel.Frame = new RectangleF(200, 10, 100, 20);
    }

    public void UpdateCell(string caption, string subtitle, UIImage image)
    {
      _imageView.Image = image;
      _nameLabel.Text = caption;
      _priceLabel.Text = subtitle;
    }
  }
}
