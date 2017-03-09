﻿using System;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms
{
	public sealed class PinchGestureRecognizer : GestureRecognizer, IPinchGestureController
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsPinching { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SendPinch(Element sender, double delta, Point currentScalePoint)
		{
			EventHandler<PinchGestureUpdatedEventArgs> handler = PinchUpdated;
			if (handler != null)
			{
				handler(sender, new PinchGestureUpdatedEventArgs(GestureStatus.Running, delta, currentScalePoint));
			}
			((IPinchGestureController)this).IsPinching = true;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SendPinchCanceled(Element sender)
		{
			EventHandler<PinchGestureUpdatedEventArgs> handler = PinchUpdated;
			if (handler != null)
			{
				handler(sender, new PinchGestureUpdatedEventArgs(GestureStatus.Canceled));
			}
			((IPinchGestureController)this).IsPinching = false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SendPinchEnded(Element sender)
		{
			EventHandler<PinchGestureUpdatedEventArgs> handler = PinchUpdated;
			if (handler != null)
			{
				handler(sender, new PinchGestureUpdatedEventArgs(GestureStatus.Completed));
			}
			((IPinchGestureController)this).IsPinching = false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SendPinchStarted(Element sender, Point initialScalePoint)
		{
			EventHandler<PinchGestureUpdatedEventArgs> handler = PinchUpdated;
			if (handler != null)
			{
				handler(sender, new PinchGestureUpdatedEventArgs(GestureStatus.Started, 1, initialScalePoint));
			}
			((IPinchGestureController)this).IsPinching = true;
		}

		public event EventHandler<PinchGestureUpdatedEventArgs> PinchUpdated;
	}
}