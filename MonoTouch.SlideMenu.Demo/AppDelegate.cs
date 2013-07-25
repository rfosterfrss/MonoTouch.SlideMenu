
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;

namespace MonoTouch.SlideMenu.Demo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			MenuViewController menuViewController = new MenuViewController(UITableViewStyle.Grouped);
			DetailsViewController detailsViewController = new DetailsViewController();

			SlideMenuController slideMenuViewController = new SlideMenuController(menuViewController, new MenuViewController(UITableViewStyle.Plain), detailsViewController);

			slideMenuViewController.SetLeftBarButtonForController (new UIBarButtonItem (UIBarButtonSystemItem.Bookmarks));
			slideMenuViewController.SetRightBarButtonForController (new UIBarButtonItem (UIBarButtonSystemItem.Bookmarks));

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				slideMenuViewController.WidthofContentViewVisible = 300f;
			else
				slideMenuViewController.WidthofContentViewVisible = 44f;

			UINavigationController cont = new UINavigationController (slideMenuViewController);
			window.RootViewController = cont;

			window.BackgroundColor = UIColor.White;
			window.MakeKeyAndVisible ();			
			return true;
		}
	}
}

