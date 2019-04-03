using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp13
{
	interface IFlyingObject
	{
		int MaxHeight { get; set; }
		int CurrentHeight { get; set; }
		void TakeUpper(int delta);
		void TakeLower(int delta);
	}
}
