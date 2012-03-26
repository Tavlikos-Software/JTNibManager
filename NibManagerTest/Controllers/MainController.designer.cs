// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace NibManagerTest
{
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadManually { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadAuto { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadDerived { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLoadManually != null) {
				btnLoadManually.Dispose ();
				btnLoadManually = null;
			}

			if (btnLoadAuto != null) {
				btnLoadAuto.Dispose ();
				btnLoadAuto = null;
			}

			if (btnLoadDerived != null) {
				btnLoadDerived.Dispose ();
				btnLoadDerived = null;
			}

			if (btnLoadTable != null) {
				btnLoadTable.Dispose ();
				btnLoadTable = null;
			}

			if (btnLoadView != null) {
				btnLoadView.Dispose ();
				btnLoadView = null;
			}
		}
	}
}
