//NibManagerTest - a test project for the JTNibManager library.
//© 2012, Dimitris Tavlikos - dimitris ( at ) tavlikos.com, http://software.tavlikos.com
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using JTNibManager;

namespace NibManagerTest
{
	public partial class MainController : NibManagedController
	{
		public MainController () : base ("MainController", AppDelegate.NibManager, NSBundle.MainBundle)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.btnLoadAuto.TouchUpInside += BtnLoadAuto_TouchUpInside;
			this.btnLoadDerived.TouchUpInside += BtnLoadDerived_TouchUpInside;
			this.btnLoadManually.TouchUpInside += BtnLoadManually_TouchUpInside;
			this.btnLoadTable.TouchUpInside += BtnLoadTable_TouchUpInside;
			this.btnLoadView.TouchUpInside += BtnLoadView_TouchUpInside;
			
			this.NavigationItem.Title = "Nib Manager Tests";
		}
		
		
		
		
		
		void BtnLoadView_TouchUpInside (object sender, EventArgs e)
		{
			
			// Initialize the view owner
			CustomView customView = AppDelegate.NibManager.LoadUIObject<CustomView>(this, "CustomView", NSBundle.MainBundle);
			customView.CloseButton.TouchUpInside += (s, args) => customView.RemoveFromSuperview();
			
			// Just some simple fade-in for fun
			customView.Alpha = 0f;
			
			// Show it
			this.View.AddSubview(customView);
			
			UIView.Animate(1d, () => customView.Alpha = 1f);
		}
		
		
		
		
		ListController listController;
		void BtnLoadTable_TouchUpInside (object sender, EventArgs e)
		{
			if (this.listController == null)
			{
				this.listController = new ListController();
			}//end if
			
			this.NavigationController.PushViewController(this.listController, true);
		}
		
		
		
		
		ManualController mController;
		void BtnLoadManually_TouchUpInside (object sender, EventArgs e)
		{
			
			if (this.mController == null)
			{
				
				// Initialize the controller
				mController = new ManualController();
				
				// Load its interface from NIB
				AppDelegate.NibManager.LoadController<ManualController>(mController, "ManualController", NSBundle.MainBundle);
				
				// Call ViewDidLoad
				mController.ViewDidLoad();
				
			}//end if
			
			this.NavigationController.PushViewController(this.mController, true);
		}
		
		
		
		
		XIBLessController xibLess;
		void BtnLoadDerived_TouchUpInside (object sender, EventArgs e)
		{
			
			if (this.xibLess == null)
			{
				
				// Initialize the controller
				this.xibLess = new XIBLessController("BaseController", AppDelegate.NibManager, NSBundle.MainBundle);
				
			}//end if
			
			this.NavigationController.PushViewController(this.xibLess, true);
		}
		
		
		
		
		AutoLoadedController autoController;
		void BtnLoadAuto_TouchUpInside (object sender, EventArgs e)
		{
			
			if (this.autoController == null)
			{
				
				// Initialize the controller
				this.autoController = new AutoLoadedController();
				
			}//end if
			
			this.NavigationController.PushViewController(this.autoController, true);
		}
		
		
		
		
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			this.btnLoadAuto.TouchUpInside -= BtnLoadAuto_TouchUpInside;
			this.btnLoadDerived.TouchUpInside -= BtnLoadDerived_TouchUpInside;
			this.btnLoadManually.TouchUpInside -= BtnLoadManually_TouchUpInside;
			this.btnLoadTable.TouchUpInside -= BtnLoadTable_TouchUpInside;
			this.btnLoadView.TouchUpInside -= BtnLoadView_TouchUpInside;
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

