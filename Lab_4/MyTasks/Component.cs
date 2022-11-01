using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks
{
    public delegate void StateHandler(object sender, ClassArgument e);
    public class Component
    {
        public event StateHandler Cleared;

        public void QueueInfo(int elementsCount)
        {
            if (elementsCount == 0)
            {
                if (Cleared != null)
                {
                    Cleared(this, new ClassArgument($"Queue was cleared."));
                }
            }
        }
    }
}
