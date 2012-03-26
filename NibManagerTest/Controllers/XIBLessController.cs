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
using JTNibManager;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace NibManagerTest
{
	public class XIBLessController : BaseController, INibManaged
	{
		
		#region Constructors
		
		public XIBLessController (string nibName, NibManager nibManager, NSBundle mainBundle) : base()
		{
			this.Manager = nibManager;
			this.LoadFromNib(nibName, mainBundle);
			this.ViewDidLoad();
		}
		
		#endregion Constructors
		
		
		
		#region Outlets in BaseController
		
		[Outlet("lblMessage")]
		public UILabel LblMessage
		{
			get;
			set;
		}//end UILabel LblMessage
		
		#endregion Outlets in BaseController
		
		
		
		#region Overrides
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			this.LblMessage.Text = string.Format("This controller is {0}\n(but its interface is loaded from BaseController.xib)", this.GetType().Name);
		}
		
		
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			if (this.LblMessage != null)
			{
				this.LblMessage.Dispose();
				this.LblMessage = null;
			}//end if
		}
		
		#endregion Overrides
		
		
		
		
		#region INibManaged implementation
		public void LoadFromNib (string nibName, NSBundle bundle)
		{
			this.Manager.LoadController<XIBLessController>(this, nibName, bundle);
		}

		public NibManager Manager 
		{
			get;
			private set;
		}
		#endregion
	}
}

