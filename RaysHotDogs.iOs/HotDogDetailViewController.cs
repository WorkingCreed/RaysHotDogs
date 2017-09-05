using Foundation;
using System;
using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Services;
using UIKit;

namespace RaysHotDogs.iOs
{
  public partial class HotDogDetailViewController : UIViewController
  {
    public HotDog SelectedHotDog { get; set; }

    public HotDogDetailViewController(IntPtr handle) : base(handle)
    {
//      HotDogDataService service = new HotDogDataService();
//      SelectedHotDog = service.GetHotDogById(1);
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      DataBindUi();
      CancelButton.TouchUpInside += CancelButtonOnTouchUpInside;
      AddToCartButton.TouchUpInside += AddToCartButtonOnTouchUpInside;
    }

    private void CancelButtonOnTouchUpInside(object sender, EventArgs eventArgs)
    {
    }

    partial void AddToCartButton_TouchUpInside(UIButton sender)
    {
      UIAlertController uiAlertController =
        UIAlertController.Create("Ray's Hot Dogs", "This hot dog is awesome", UIAlertControllerStyle.Alert);
      uiAlertController.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));
      PresentViewController(uiAlertController, true, null);
    }

    private void AddToCartButtonOnTouchUpInside(object senser, EventArgs eventArgs)
    {
      UIAlertController uiAlertController =
        UIAlertController.Create("Ray's Hot Dogs", "This hot dog is awesome", UIAlertControllerStyle.Alert);
      uiAlertController.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));
      PresentViewController(uiAlertController, true, null);

//            UIAlertView message = new UIAlertView("Ray's Hot Dogs", "That hot dog is awesome", null, "Okay", null);
//            message.Show();
    }

    private void DataBindUi()
    {
      UIImage image = UIImage.FromFile($"Images/{SelectedHotDog.ImagePath}.png");
      HotDogImageView.Image = image;
      NameLabel.Text = SelectedHotDog.Name;
      ShortDescriptionLabel.Text = SelectedHotDog.ShortDescription;
      DescriptionText.Text = SelectedHotDog.Description;
      PriceLabel.Text = $"${SelectedHotDog.Price}";
    }
  }
}