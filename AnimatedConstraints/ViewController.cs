using System;

using UIKit;
using Foundation;

namespace AnimatedConstraints
{
	public partial class ViewController : UIViewController
	{
		public ViewController ()
		{
			
		}

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			bool isBlue = true;
			bool isRed = true;
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = UIColor.White;

			UIButton redView = new UIButton ();
			redView.BackgroundColor = UIColor.Red;
			redView.TranslatesAutoresizingMaskIntoConstraints = false;

			Add (redView);

			UIButton blueView = new UIButton ();
			blueView.BackgroundColor = UIColor.Green;
			blueView.TranslatesAutoresizingMaskIntoConstraints = false;
			Add (blueView);

			View.AddConstraint (NSLayoutConstraint.Create (redView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, blueView, NSLayoutAttribute.Width, 1, 0));
			View.AddConstraint (NSLayoutConstraint.Create (redView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1, -10));
			View.AddConstraint (NSLayoutConstraint.Create (redView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 10));
			View.AddConstraint (NSLayoutConstraint.Create (redView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, blueView, NSLayoutAttribute.Left, 1, -10));


			View.AddConstraint (NSLayoutConstraint.Create (blueView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1, -10));
			View.AddConstraint (NSLayoutConstraint.Create (blueView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 10));

			var redLeftConstraint = NSLayoutConstraint.Create (redView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 10);
			redLeftConstraint.Priority = 750;
			View.AddConstraint (redLeftConstraint);

			var marginConstraint = NSLayoutConstraint.Create (redView,NSLayoutAttribute.Right,NSLayoutRelation.Equal,View,NSLayoutAttribute.Right,1,-10);
			marginConstraint.Priority = 750;
			View.AddConstraint (marginConstraint);

			var constraint = NSLayoutConstraint.Create (blueView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -10);
			constraint.Priority = 750;
			View.AddConstraint (constraint);

			var blueLeftConstraint =NSLayoutConstraint.Create(blueView,NSLayoutAttribute.Left,NSLayoutRelation.Equal,View,NSLayoutAttribute.Left,1,10);
			blueLeftConstraint.Priority = 750;
			View.AddConstraint (blueLeftConstraint);
			redView.TouchDown += (o, s) => {
				if(isBlue)
				{
					constraint.Priority=749;
					blueLeftConstraint.Priority=749;
					isBlue=false;
					isRed=true;
					UIView.Animate(1,this.View.LayoutIfNeeded);
				}
				else
				{
					constraint.Priority=750;
					blueLeftConstraint.Priority=750;
					isBlue=true;
					isRed=false;
					UIView.Animate(1,this.View.LayoutIfNeeded);
				}
			};

			blueView.TouchDown+=(o,s)=>{
				if(!isRed)
				{
					redLeftConstraint.Priority=749;
					marginConstraint.Priority=749;
					isBlue=false;
					isRed=true;
					UIView.Animate(1,this.View.LayoutIfNeeded);
				}
				else
				{
					redLeftConstraint.Priority=750;
					marginConstraint.Priority=750;
					isBlue=true;
					isRed=false;
					UIView.Animate(1,this.View.LayoutIfNeeded);
				}
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

