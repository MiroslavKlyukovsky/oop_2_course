using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Preferences
    {
        public MyRange cost { set; get; }
        public MyRange bedroom_n { set; get; }
        public MyRange furnitering_level { set; get; }
        public MyRange proxim_to_center { set; get; }
        public MyRange private_plot { set; get; }
        public Preferences(int min_cost, int max_cost, int min_bed, int max_bed, int min_furnt, int max_furnt, int min_proxim_to_cente, int max_proxim_to_cente, int min_private_plot, int max_private_plot)
        {
            this.cost = new MyRange(min_cost, max_cost);
            this.bedroom_n = new MyRange(min_bed,max_bed);
            this.furnitering_level = new MyRange(min_furnt, max_furnt);
            this.proxim_to_center = new MyRange(min_proxim_to_cente, max_proxim_to_cente);
            this.private_plot = new MyRange(min_private_plot, max_private_plot);
        }
        public Preferences()
        {
            this.cost = new MyRange(0, 0);
            this.bedroom_n = new MyRange(0, 0);
            this.furnitering_level = new MyRange(0, 0);
            this.proxim_to_center = new MyRange(0, 0);
            this.private_plot = new MyRange(0, 0);
        }
    }
}
