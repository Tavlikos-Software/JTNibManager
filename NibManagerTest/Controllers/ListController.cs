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
using System.Collections.Generic;

namespace NibManagerTest
{
	public partial class ListController : NibManagedController
	{
		public ListController () : base ("ListController", AppDelegate.NibManager, NSBundle.MainBundle)
		{
		}
		
		
		public List<TableRow> TableData
		{
			get;
			set;
		}//end List<TableRow> TableData
		
		
		
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
			this.TableData = new List<TableRow>() {
				
				new TableRow() { RowTitle = "BasicCell", RowSubtitle = string.Empty },
				new TableRow() { RowTitle = "SubtitleCell", RowSubtitle = "Some subtitle" },
				new TableRow() { RowTitle = "CustomCell", RowSubtitle = string.Empty }
				
			};
			
			this.tableView.Source = new TableSource(this);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		
		
		private class TableSource : UITableViewSource
		{
			
			public TableSource(ListController parentController)
			{
				this.parentController = parentController;
			}//end ctor
			private ListController parentController;
			
			
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				return this.parentController.TableData.Count;
			}
			
			
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				int rowIndex = indexPath.Row;
				
				TableRow selectedRow = this.parentController.TableData[rowIndex];
				UITableViewCell cell = tableView.DequeueReusableCell(selectedRow.RowTitle); // the row title is also used for the cell identifier, for convenience
				
				if (null == cell)
				{
					
					// Create a table cell instance and cache its NIB.
					cell = AppDelegate.NibManager.LoadUIObject<UITableViewCell>(tableView, selectedRow.RowTitle, NSBundle.MainBundle);
					
				}//end if
				
				((ICellPopulator)cell).PopulateCell(selectedRow.RowTitle, selectedRow.RowSubtitle);
				
				return cell;
			}
			
			
		}//end class TableSource
	}
	
	
	
	public class TableRow
	{
		public string RowTitle { get; set; }
		public string RowSubtitle { get; set; }
	}//end class TableRow

}

