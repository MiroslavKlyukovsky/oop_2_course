using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Trapeze : IComparable
    {
        public string fill_color { get; set;}
        public string outline_color { get; set;}
        public int length_of_top_base { get;}
        public int length_of_dow_base { get;}
        public int height { get;}
        public int left_side { get;}
        public int right_side { get;}
        public Trapeze(int length_of_dow_base, int length_of_top_base, int height, int left_side, int right_side, string fill_color = "White", string outline_color = "Black")
        {
            this.fill_color = fill_color;
            this.outline_color = outline_color;
            this.length_of_top_base = length_of_top_base;
            this.length_of_dow_base = length_of_dow_base;
            this.height = height;
            this.left_side = left_side;
            this.right_side = right_side;
        }
        public float area_calculation(){
            return ((length_of_dow_base+length_of_top_base)/2) * height;
        }
        public int perimeter_calculation(){
            return left_side+right_side+length_of_dow_base+length_of_top_base;
        }
        public string info(){ 
            return String.Format("Lenght of the top base is {0}\n" +
                                "Lenght of the down base is {1}\n" +
                                "Lenght of the left side is {2}\n" +
                                "Lenght of the right side is {3}\n" +
                                "The height is {4}\n" +
                                "The fill color and outline color are {5} and {6}", length_of_top_base,length_of_dow_base,left_side,right_side,height,fill_color,outline_color);
        }
        public int CompareTo(object obj)
        {
            Trapeze trap = obj as Trapeze;
            if (trap != null)
                return this.length_of_dow_base.CompareTo(trap.length_of_dow_base);
            else
                throw new Exception("Error");
        }
        public override string ToString()//XXX
        {
            return $" {this.length_of_dow_base} ";
        }
    }
}
