using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Offers_list
    {
        public List<Flat> offers = new List<Flat>();
        public int number_of_elements = 0;
        public void take_offer(Flat flat) {
            if (number_of_elements != 4)
            {
                offers.Add(flat);
                number_of_elements++;
            }
        }
        public void remove_offer(Flat flat) {
            offers.Remove(flat);
            number_of_elements--;
        }
    }
}
