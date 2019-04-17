using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp17_2_
{
	class RandomDataEventArgs : EventArgs
	{
		public int bytesDone { get; set; }
		public int totalBytes { get; set; }
	}
}
