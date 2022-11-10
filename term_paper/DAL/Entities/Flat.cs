using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Flat
    {
        public int ID { set; get; }
        public int cost { set; get; }
        public int bedroom_n { set; get; }
        public int furnitering_level { set; get; }
        public int proxim_to_center { set; get; }
        public int private_plot { set; get; }
        public string add_info { set;  get; }
        public Flat(int ID, int cost, int bedroom_n, int furnitering_level, int proxim_to_center, int private_plot, string add_info)
        {
            this.ID = ID;
            this.cost = cost;
            this.bedroom_n = bedroom_n;
            this.furnitering_level = furnitering_level;
            this.proxim_to_center = proxim_to_center;
            this.private_plot = private_plot;
            this.add_info = add_info;
        }
        public Flat()
        {
            this.ID = -1;
            this.cost = -1;
            this.bedroom_n = -1;
            this.furnitering_level = -1;
            this.proxim_to_center = -1;
            this.private_plot = -1;
            this.add_info = "";
        }
        public override string ToString()
        {
            return $"Flat ID: {ID};\n" +
                   $"Cost: {cost};\n" +
                   $"Bedrooms: {bedroom_n};\n" +
                   $"Furnituring level (1-10): {furnitering_level};\n" +
                   $"Proximity to the center (km): {proxim_to_center};\n" +
                   $"Size of the private plot (square meters): {private_plot};\n" +
                   $"Additional info: {add_info};\n";
        }
    }
}
