using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cellular_automaton
{
    class GGNode
    {
        public int state;
        
        public int[] rgb = new int[3];

        public GGNode()
        {
            state = 0;
            
            rgb[0] = 255;
            rgb[1] = 255;
            rgb[2] = 255;
        }

        public void setState(int s)
        {
            this.state = s;
        }
        
    }
}
