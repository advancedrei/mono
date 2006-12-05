//
// ToolStripRenderer.cs
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) Jonathan Pobst
//
// Authors:
//	Jonathan Pobst (monkey@jpobst.com)
//
#if NET_2_0

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace System.Windows.Forms
{
	public abstract class ToolStripRenderer
	{
		private static ColorMatrix grayscale_matrix = new ColorMatrix (new float[][] {
						//new float[]{0.3f,0.3f,0.3f,0,0},
						//new float[]{0.59f,0.59f,0.59f,0,0},
						//new float[]{0.11f,0.11f,0.11f,0,0},
						//new float[]{0,0,0,1,0,0},
						//new float[]{0,0,0,0,1,0},
						//new float[]{0,0,0,0,0,1}
					  new float[]{0.2f,0.2f,0.2f,0,0},
					  new float[]{0.41f,0.41f,0.41f,0,0},
					  new float[]{0.11f,0.11f,0.11f,0,0},
					  new float[]{0.15f,0.15f,0.15f,1,0,0},
					  new float[]{0.15f,0.15f,0.15f,0,1,0},
					  new float[]{0.15f,0.15f,0.15f,0,0,1}
				  });

		protected ToolStripRenderer () 
		{
		}

		#region Public Methods
		public static Image CreateDisabledImage(Image normalImage)
		{
			if (normalImage == null)
				return null;
				
			// Code adapted from ThemeWin32Classic.cs
			ImageAttributes ia = new ImageAttributes();
			ia.SetColorMatrix (grayscale_matrix);
			
			Bitmap b = new Bitmap(normalImage);
			Graphics.FromImage(b).DrawImage(normalImage, new Rectangle (0, 0, normalImage.Width, normalImage.Height), 0, 0, normalImage.Width, normalImage.Height, GraphicsUnit.Pixel, ia);
			
			return b;
		}

		public void DrawArrow (ToolStripArrowRenderEventArgs e)
		{ this.OnRenderArrow (e); }
		
		public void DrawButtonBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderButtonBackground (e); }

		public void DrawDropDownButtonBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderDropDownButtonBackground (e); }

		public void DrawGrip (ToolStripGripRenderEventArgs e)
		{ this.OnRenderGrip (e); }

		public void DrawImageMargin (ToolStripRenderEventArgs e)
		{ this.OnRenderImageMargin (e); }

		public void DrawItemBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderItemBackground (e); }

		public void DrawItemCheck (ToolStripItemImageRenderEventArgs e)
		{ this.OnRenderItemCheck (e); }

		public void DrawItemImage (ToolStripItemImageRenderEventArgs e)
		{ this.OnRenderItemImage (e); }

		public void DrawItemText (ToolStripItemTextRenderEventArgs e)
		{ this.OnRenderItemText (e); }

		public void DrawLabelBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderLabelBackground (e); }

		public void DrawMenuItemBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderMenuItemBackground (e); }

		public void DrawOverflowButtonBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderOverflowButtonBackground (e); }

		public void DrawSeparator (ToolStripSeparatorRenderEventArgs e)
		{ this.OnRenderSeparator (e); }

		public void DrawSplitButton (ToolStripItemRenderEventArgs e)
		{ this.OnRenderSplitButtonBackground (e); }

		public void DrawStatusStripSizingGrip (ToolStripRenderEventArgs e)
		{ this.OnRenderStatusStripSizingGrip (e); }

		public void DrawToolStripBackground (ToolStripRenderEventArgs e)
		{ this.OnRenderToolStripBackground (e); }

		public void DrawToolStripBorder (ToolStripRenderEventArgs e)
		{ this.OnRenderToolStripBorder (e); }

		public void DrawToolStripContentPanelBackground (ToolStripContentPanelRenderEventArgs e)
		{ this.OnRenderToolStripContentPanelBackground (e); }

		public void DrawToolStripPanelBackground (ToolStripPanelRenderEventArgs e)
		{ this.OnRenderToolStripPanelBackground (e); }

		public void DrawToolStripStatusLabelBackground (ToolStripItemRenderEventArgs e)
		{ this.OnRenderToolStripStatusLabelBackground (e); }
		#endregion

		#region Protected Methods
		protected internal virtual void Initialize (ToolStrip toolStrip) {}
		protected internal virtual void InitializeContentPanel (ToolStripContentPanel contentPanel) {}
		protected internal virtual void InitializeItem (ToolStripItem item) {}
		protected internal virtual void InitializePanel (ToolStripPanel toolStripPanel) {}

		protected virtual void OnRenderArrow (ToolStripArrowRenderEventArgs e)
		{
			ToolStripArrowRenderEventHandler eh = (ToolStripArrowRenderEventHandler)Events [RenderArrowEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderButtonBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderButtonBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderDropDownButtonBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderDropDownButtonBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}
		
		protected virtual void OnRenderGrip (ToolStripGripRenderEventArgs e)
		{
			ToolStripGripRenderEventHandler eh = (ToolStripGripRenderEventHandler)Events [RenderGripEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderImageMargin (ToolStripRenderEventArgs e)
		{
			ToolStripRenderEventHandler eh = (ToolStripRenderEventHandler)Events [RenderImageMarginEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderItemBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderItemBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderItemCheck (ToolStripItemImageRenderEventArgs e)
		{
			ToolStripItemImageRenderEventHandler eh = (ToolStripItemImageRenderEventHandler)Events [RenderItemCheckEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderItemImage (ToolStripItemImageRenderEventArgs e)
		{
			ToolStripItemImageRenderEventHandler eh = (ToolStripItemImageRenderEventHandler)Events [RenderItemImageEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderItemText (ToolStripItemTextRenderEventArgs e)
		{
			ToolStripItemTextRenderEventHandler eh = (ToolStripItemTextRenderEventHandler)Events [RenderItemTextEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderLabelBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderLabelBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderMenuItemBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderMenuItemBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderOverflowButtonBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderOverflowButtonBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderSeparator (ToolStripSeparatorRenderEventArgs e)
		{
			ToolStripSeparatorRenderEventHandler eh = (ToolStripSeparatorRenderEventHandler)Events [RenderSeparatorEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderSplitButtonBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderSplitButtonBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderStatusStripSizingGrip (ToolStripRenderEventArgs e)
		{
			ToolStripRenderEventHandler eh = (ToolStripRenderEventHandler)Events [RenderStatusStripSizingGripEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderToolStripBackground (ToolStripRenderEventArgs e)
		{
			ToolStripRenderEventHandler eh = (ToolStripRenderEventHandler)Events [RenderToolStripBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderToolStripBorder (ToolStripRenderEventArgs e)
		{
			ToolStripRenderEventHandler eh = (ToolStripRenderEventHandler)Events [RenderToolStripBorderEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderToolStripContentPanelBackground (ToolStripContentPanelRenderEventArgs e)
		{
			ToolStripContentPanelRenderEventHandler eh = (ToolStripContentPanelRenderEventHandler)Events [RenderToolStripContentPanelBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderToolStripPanelBackground (ToolStripPanelRenderEventArgs e)
		{
			ToolStripPanelRenderEventHandler eh = (ToolStripPanelRenderEventHandler)Events [RenderToolStripPanelBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}

		protected virtual void OnRenderToolStripStatusLabelBackground (ToolStripItemRenderEventArgs e)
		{
			ToolStripItemRenderEventHandler eh = (ToolStripItemRenderEventHandler)Events [RenderToolStripStatusLabelBackgroundEvent];
			if (eh != null)
				eh (this, e);
		}
		#endregion

		#region Public Events
		EventHandlerList events;

		EventHandlerList Events {
			get {
				if (events == null)
					events = new EventHandlerList ();
				return events;
			}
		}

		static object RenderArrowEvent = new object ();
		static object RenderButtonBackgroundEvent = new object ();
		static object RenderDropDownButtonBackgroundEvent = new object ();
		static object RenderGripEvent = new object ();
		static object RenderImageMarginEvent = new object ();
		static object RenderItemBackgroundEvent = new object ();
		static object RenderItemCheckEvent = new object ();
		static object RenderItemImageEvent = new object ();
		static object RenderItemTextEvent = new object ();
		static object RenderLabelBackgroundEvent = new object ();
		static object RenderMenuItemBackgroundEvent = new object ();
		static object RenderOverflowButtonBackgroundEvent = new object ();
		static object RenderSeparatorEvent = new object ();
		static object RenderSplitButtonBackgroundEvent = new object ();
		static object RenderStatusStripSizingGripEvent = new object ();
		static object RenderToolStripBackgroundEvent = new object ();
		static object RenderToolStripBorderEvent = new object ();
		static object RenderToolStripContentPanelBackgroundEvent = new object ();
		static object RenderToolStripPanelBackgroundEvent = new object ();
		static object RenderToolStripStatusLabelBackgroundEvent = new object ();

		public event ToolStripArrowRenderEventHandler RenderArrow {
			add { Events.AddHandler (RenderArrowEvent, value); }
			remove {Events.RemoveHandler (RenderArrowEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderButtonBackground {
			add { Events.AddHandler (RenderButtonBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderButtonBackgroundEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderDropDownButtonBackground {
			add { Events.AddHandler (RenderDropDownButtonBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderDropDownButtonBackgroundEvent, value); }
		}
		public event ToolStripGripRenderEventHandler RenderGrip {
			add { Events.AddHandler (RenderGripEvent, value); }
			remove {Events.RemoveHandler (RenderGripEvent, value); }
		}
		public event ToolStripRenderEventHandler RenderImageMargin {
			add { Events.AddHandler (RenderImageMarginEvent, value); }
			remove {Events.RemoveHandler (RenderImageMarginEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderItemBackground {
			add { Events.AddHandler (RenderItemBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderItemBackgroundEvent, value); }
		}
		public event ToolStripItemImageRenderEventHandler RenderItemCheck {
			add { Events.AddHandler (RenderItemCheckEvent, value); }
			remove {Events.RemoveHandler (RenderItemCheckEvent, value); }
		}
		public event ToolStripItemImageRenderEventHandler RenderItemImage {
			add { Events.AddHandler (RenderItemImageEvent, value); }
			remove {Events.RemoveHandler (RenderItemImageEvent, value); }
		}
		public event ToolStripItemTextRenderEventHandler RenderItemText {
			add { Events.AddHandler (RenderItemTextEvent, value); }
			remove {Events.RemoveHandler (RenderItemTextEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderLabelBackground {
			add { Events.AddHandler (RenderLabelBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderLabelBackgroundEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderMenuItemBackground {
			add { Events.AddHandler (RenderMenuItemBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderMenuItemBackgroundEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderOverflowButtonBackground {
			add { Events.AddHandler (RenderOverflowButtonBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderOverflowButtonBackgroundEvent, value); }
		}
		public event ToolStripSeparatorRenderEventHandler RenderSeparator {
			add { Events.AddHandler (RenderSeparatorEvent, value); }
			remove {Events.RemoveHandler (RenderSeparatorEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderSplitButtonBackground {
			add { Events.AddHandler (RenderSplitButtonBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderSplitButtonBackgroundEvent, value); }
		}
		public event ToolStripRenderEventHandler RenderStatusStripSizingGrip {
			add { Events.AddHandler (RenderStatusStripSizingGripEvent, value); }
			remove {Events.RemoveHandler (RenderStatusStripSizingGripEvent, value); }
		}
		public event ToolStripRenderEventHandler RenderToolStripBackground {
			add { Events.AddHandler (RenderToolStripBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderToolStripBackgroundEvent, value); }
		}
		public event ToolStripRenderEventHandler RenderToolStripBorder {
			add { Events.AddHandler (RenderToolStripBorderEvent, value); }
			remove {Events.RemoveHandler (RenderToolStripBorderEvent, value); }
		}
		public event ToolStripContentPanelRenderEventHandler RenderToolStripContentPanelBackground {
			add { Events.AddHandler (RenderToolStripContentPanelBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderToolStripContentPanelBackgroundEvent, value); }
		}
		public event ToolStripPanelRenderEventHandler RenderToolStripPanelBackground {
			add { Events.AddHandler (RenderToolStripPanelBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderToolStripPanelBackgroundEvent, value); }
		}
		public event ToolStripItemRenderEventHandler RenderToolStripStatusLabelBackground {
			add { Events.AddHandler (RenderToolStripStatusLabelBackgroundEvent, value); }
			remove {Events.RemoveHandler (RenderToolStripStatusLabelBackgroundEvent, value); }
		}
		#endregion
	}
}
#endif
