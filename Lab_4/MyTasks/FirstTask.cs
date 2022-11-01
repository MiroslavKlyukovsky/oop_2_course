using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks
{
    public class FirstTask
    {
        public delegate bool IsSymbols(string row);
        public IsSymbols CheckA = delegate (string row)
        {
            bool IsCharPresent = false;
            foreach (var a in row.ToCharArray())
            {
                if ((64 < a && a < 91) || (96 < a && a < 123)) { IsCharPresent = true; }
            }
            return IsCharPresent;
        };
        public IsSymbols CheckL = (row) =>
        {
            bool IsCharPresent = false;
            foreach (var a in row.ToCharArray())
            {
                if ((64 < a && a < 91) || (96 < a && a < 123)) { IsCharPresent = true; }
            }
            return IsCharPresent;
        };
    }
}
