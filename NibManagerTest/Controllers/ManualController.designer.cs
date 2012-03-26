// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace NibManagerTest
{
	[Register ("ManualController")]
	partial class ManualController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMessage != null) {
				lblMessage.Dispose ();
				lblMessage = null;
			}
		}
	}
}
