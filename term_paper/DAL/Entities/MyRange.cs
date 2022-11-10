using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class MyRange
    {
        public int min;
        public int max;
        public MyRange(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public MyRange()
        {
            this.min = 0;
            this.max = 0;
        }
        public bool isWithin(int value) {
            if (min <= value && max >= value)
            {
                return true;
            }
            return false;
        }
    }
}
