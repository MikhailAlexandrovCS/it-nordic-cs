using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp17_2_
{
    class RandomDataGenerationDoneEventArgs : EventArgs
    {
        public byte[] RandomData { get; set; }
    }
}
