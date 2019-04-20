using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp17_2_
{
	class RandomDataEventArgs : EventArgs
	{
		public int BytesDone { get; set; }
		public int TotalBytes { get; set; }
	}
}
