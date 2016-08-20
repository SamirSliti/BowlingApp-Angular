using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    public class FramesModel
    {
        public IList<Frame> Frames { get; set; }
    }

    public class Frame
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Third { get; set; }
    }
}
