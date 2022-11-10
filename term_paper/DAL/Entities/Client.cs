using System;
using System.Linq;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Сlient
    {
        public int ID { set; get; }
        public string name { set; get; }
        public string surname { set; get; }
        public int bank_account { set; get; }
        public int bank_account_balance { set; get; }
        public Preferences prefearings { set; get; }
        public string add_info { set; get; }
        public Flat rented_apartment { set; get; }
        public Offers_list offers { get; set; }
        public Сlient(int ID, string name, string surname, int bank_account, int bank_account_balance, string add_info)
        {
            this.ID = ID;
            this.name = name;
            this.surname = surname;
            this.bank_account = bank_account;
            this.bank_account_balance = bank_account_balance;
            this.prefearings = new Preferences();
            this.add_info = add_info;
            this.rented_apartment = new Flat();
            this.offers = new Offers_list();
        }
        public Сlient()
        {
            this.ID = -1;
            this.name = "";
            this.surname = "";
            this.bank_account = -1;
            this.bank_account_balance = -1;
            this.prefearings = new Preferences();
            this.add_info = "";
            this.rented_apartment = new Flat();
            this.offers = new Offers_list();
        }
        public bool is_likes_suits(Flat flat)
        {
            bool is_suits = prefearings.cost.isWithin(flat.cost) && prefearings.bedroom_n.isWithin(flat.bedroom_n) &&
                prefearings.furnitering_level.isWithin(flat.furnitering_level) && prefearings.proxim_to_center.isWithin(flat.proxim_to_center) &&
                prefearings.private_plot.isWithin(flat.private_plot);
            if (is_suits)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Client ID: {ID};\n Name: {name};\n Surname: {surname};\n " +
                   $"Bank account number: {bank_account}:\n  balance: {bank_account_balance};\n " +
                   $"Preferings of client about apartment: \n" +
                   $"  Cost: {prefearings.cost.min}-{prefearings.cost.max}\n  " +
                   $"Bedroom number: {prefearings.bedroom_n.min}-{prefearings.bedroom_n.max}\n  " +
                   $"Furnitering level: {prefearings.furnitering_level.min}-{prefearings.furnitering_level.max}\n  " +
                   $"Proximity to the center: {prefearings.proxim_to_center.min}-{prefearings.proxim_to_center.max}\n  " +
                   $"Private plot: {prefearings.private_plot.min}-{prefearings.private_plot.max}\n " +
                   $"Additional info: {add_info}\n " +
                   $"Flat ID (-1 means none): {rented_apartment.ID}\n";
        }
    }
}
