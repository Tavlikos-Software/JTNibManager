//JTNibManager - a library for caching NIBs in MonoTouch
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
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace JTNibManager
{
	public class NibManager : NSObject
	{
		
		#region Constructors
		
		public NibManager ()
		{
			this.nibCache = new Dictionary<string, UINib>();
			this.emptyDict = new NSDictionary();
		}
		
		#endregion Constructors
		
		
		
		#region Fields
		
		private Dictionary<string, UINib> nibCache;
		private NSDictionary emptyDict;
		private NSObject mwReceivedObserver;
		
		#endregion Fields
		
		
		
		#region Public methods
		
		public TUIObject LoadUIObject<TUIObject>(NSObject owner, string nibName, NSBundle bundle)
			where TUIObject : NSObject
		{
			
			try
			{
				
				UINib nib = this.GetNib(nibName, bundle);
				
				NSObject[] topLevelObjects = nib.InstantiateWithOwneroptions(owner ?? this, this.emptyDict);
				TUIObject uiObject = topLevelObjects[0] as TUIObject;
				
				topLevelObjects = null;
				nib = null;
				
				return uiObject;
				
			} catch (Exception ex)
			{
				throw new NibLoadException(nibName, ex);
			}//end try catch
			
		}//end TUIObject LoadUIObject
		
		
		
		
		public void LoadController<TController>(TController owner, string nibName, NSBundle bundle)
			where TController : UIViewController
		{
			
			try
			{
				
				UINib nib = this.GetNib(nibName, bundle);
				nib.InstantiateWithOwneroptions(owner, this.emptyDict);
				
				nib = null;
				
			} catch (Exception ex)
			{
				throw new NibLoadException(nibName, ex);
			}//end try catch
			
		}//end void LoadController
		
		#endregion Public methods
		
		
		
		
		#region Private methods
		
		private UINib GetNib(string nibName, NSBundle fromBundle)
		{
			
			UINib nib = null;
			if (!this.nibCache.TryGetValue(nibName, out nib))
			{
				nib = UINib.FromName(nibName, fromBundle ?? NSBundle.MainBundle);
				this.nibCache[nibName] = nib;
			}//end if
		
			return nib;
			
		}//end UINib GetNib
		
				
		
		
		private void CleanUpNibs()
		{
			
			foreach (KeyValuePair<string, UINib> eachItem in this.nibCache)
			{
				eachItem.Value.Dispose();
			}//end foreach
			
			this.nibCache.Clear();
			
		}//end void CleanUpNibs
		
		#endregion Private methods
		
		
		
		#region Disposable implementation
				
		protected override void Dispose (bool disposing)
		{			
			this.CleanUpNibs();
			this.emptyDict.Dispose();
			
			base.Dispose (disposing);
		}
		
		
		
		~NibManager()
		{
			this.Dispose(false);
		}//end dtor
		
		#endregion Disposable implementation
	}
}

