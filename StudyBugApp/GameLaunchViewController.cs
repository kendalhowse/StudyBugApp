using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class GameLaunchViewController : UIViewController
    {
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		public GameLaunchViewController (IntPtr handle) : base (handle)
        {
        }
    }
}