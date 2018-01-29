﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorian.Models.Monitor
{
	internal abstract class MonitorItem : IMonitor, IDisposable
	{
		public string Description { get; }
		public string DeviceInstanceId { get; }
		public byte DisplayIndex { get; }
		public byte MonitorIndex { get; }
		public bool IsAccessible { get; }

		public int Brightness { get; protected set; } = -1;
		public int BrightnessAdjusted { get; protected set; } = -1;

		public MonitorItem(
			string description,
			string deviceInstanceId,
			byte displayIndex,
			byte monitorIndex,
			bool isAccessible)
		{
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentNullException(nameof(description));
			if (string.IsNullOrWhiteSpace(deviceInstanceId))
				throw new ArgumentNullException(nameof(deviceInstanceId));

			this.Description = description;
			this.DeviceInstanceId = deviceInstanceId;
			this.DisplayIndex = displayIndex;
			this.MonitorIndex = monitorIndex;
			this.IsAccessible = isAccessible;
		}

		public abstract bool UpdateBrightness(int brightness = -1);
		public abstract bool SetBrightness(int brightness);

		#region IDisposable

		private bool _isDisposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed)
				return;

			if (disposing)
			{
				// Free any other managed objects here.
			}

			// Free any unmanaged objects here.
			_isDisposed = true;
		}

		#endregion
	}
}