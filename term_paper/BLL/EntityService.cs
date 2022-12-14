using System;
using System.Collections.Generic;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class EntityService
    {
        public EntityContext<Flat> flat_serv = new EntityContext<Flat>();
        public EntityContext<Сlient> client_serv = new EntityContext<Сlient>();

        private List<Flat> flats;
        private List<Сlient> clients;

        public EntityService()
        {
            flats = flat_serv.Read();
            clients = client_serv.Read();
        }
        public void End_of_work()
        {
            flat_serv.Write(flats);
            client_serv.Write(clients);
        }
        //CLIENT
        public void add_client(int ID, string name, string surname, int bank_account, int bank_account_balance, string add_info)
        {
            Сlient client = new Сlient(ID, name, surname, bank_account, bank_account_balance, add_info);
            clients.Add(client);
        }
        public string remove_client(int ID)
        {
            if (clients.Remove(clients.Find(x => x.ID == ID))) { return $"Client with ID {ID} removed."; }
            else
            {
                return $"No client with ID {ID}";
            }
            
        }
        //changing
        //*
        public void add_prefearings(int ClientID, int min_cost, int max_cost, int min_bed, int max_bed, int min_furnt, int max_furnt, int min_proxim_to_cente, int max_proxim_to_cente, int min_private_plot, int max_private_plot) {
            clients.Find(x => x.ID == ClientID).prefearings = new Preferences(min_cost, max_cost, min_bed, max_bed, min_furnt, max_furnt, min_proxim_to_cente, max_proxim_to_cente, min_private_plot, max_private_plot);
        }
        public string change_client_id(int ClientID, int newID) {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).ID = newID;
                return $"Client with ID {ClientID} now has ID {newID}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_rented_apartment(int ClientID, int AppartmentID)
        {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).rented_apartment = flats.Find(x => x.ID == AppartmentID);
                return $"Client with ID {ClientID} now has apartment with ID {AppartmentID}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_name(int ClientID, string new_name) {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).name = new_name;
                return $"Client with ID {ClientID} now has name {new_name}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_surname(int ClientID, string new_surname)
        {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).surname = new_surname;
                return $"Client with ID {ClientID} now has surname {new_surname}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_bank_account(int ClientID, int new_bank_acc)
        {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).bank_account = new_bank_acc;
                return $"Client with ID {ClientID} now has bank account {clients.Find(x => x.ID == ClientID).bank_account}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_bank_balance(int ClientID, int new_bank_bal)
        {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).bank_account_balance = new_bank_bal;
                return $"Client with ID {ClientID} now has bank balance {clients.Find(x => x.ID == ClientID).bank_account_balance}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string change_client_add_info(int ClientID, string new_add_info) {
            if (clients.Exists(x => x.ID == ClientID))
            {
                clients.Find(x => x.ID == ClientID).add_info = new_add_info;
                return $"Client with ID {ClientID} now has add info: {clients.Find(x => x.ID == ClientID).add_info}.";
            }
            else
            {
                return $"There is no client with ID {ClientID}.";
            }
        }
        public string smash_or_pass_offers(int ClientID) {
            Offers_list of = clients.Find(x => x.ID == ClientID).offers;
            List<Flat> matrix = new List<Flat>();
            if (of == null || of.number_of_elements == 0) 
            { 
                return "No offers to reflect.";
            }
            else
            {
                foreach (var item in of.offers)
                {
                    if (!does_takes(ClientID, item.ID))
                    {
                        matrix.Add(item);   
                    }
                }
                foreach (var item in matrix)
                {
                    of.remove_offer(item);
                }
                return "Client watched offers.";
            }
        }
        //info
        public string see_client_info(int ClientID) {
            return '\n' + clients.Find(x => x.ID == ClientID).ToString() + $"Offers: {see_all_offers(ClientID)}\n";
        }
        public string see_all_clients() {
            string output = $"\nWe have {clients.Count} clients and here they are: \n\n";
            foreach (var item in clients)
            {
                output = output + item.ToString() + $"Offers: {see_all_offers(item.ID)}" + "\n";
            }
            return output;
        }
        //sorting
        public void sort_cli_by_name()
        {
            clients.Sort((x, y) => x.name.CompareTo(y.name));
        }
        public void sort_cli_by_surname()
        {
            clients.Sort((x, y) => x.surname.CompareTo(y.surname));
        }
        public void sort_cli_by_bank()
        {
            clients.Sort((x, y) => Int32.Parse(x.bank_account.ToString().Substring(0, 1)).CompareTo(Int32.Parse(y.bank_account.ToString().Substring(0, 1))));
        }
        //APPARTMENT
        public string add_appartment(int ID, int cost, int bedroom_n, int furnitering_level, int proxim_to_center, int private_plot, string add_info) {
            flats.Add(new Flat(ID, cost, bedroom_n, furnitering_level, proxim_to_center, private_plot, add_info));
            return see_apartment_info(ID);
        }
        public string remove_apartment(int id) {
            if (flats.Remove(flats.Find(x => x.ID == id))) { return $"Flat with ID {id} removed."; }
            else
            {
                return $"No flat with ID {id}.";
            }
        }
        //changing
        public string change_apartment_cost(int id, int new_cost){
            if (flats.Exists(x => x.ID == id))
            {
                flats.Find(x => x.ID == id).cost = new_cost;
                return $"Flat with ID {id} now has cost {new_cost}.";
            }
            else
            {
                return $"There is no flats with ID {id}.";
            }
        }
        public string change_apartment_bedroom_n(int id, int new_bedroom_n)
        {
            if (flats.Exists(x => x.ID == id))
            {
                flats.Find(x => x.ID == id).bedroom_n = new_bedroom_n;
                return $"Flat with ID {id} now has bedroom number {new_bedroom_n}.";
            }
            else
            {
                return $"There is no flats with ID {id}.";
            }
        }
        public string change_furnitering_level(int id,int new_furnitering_level) 
        {
            if (flats.Exists(x => x.ID == id))
            {
                flats.Find(x => x.ID == id).furnitering_level = new_furnitering_level;
                return $"Flat with ID {id} now has furnituring level {new_furnitering_level}.";
            }
            else
            {
                return $"There is no flats with ID {id}.";
            }
        }
        public void change_proxim_to_center(int id, int new_proxim_to_center) {
            flats.Find(x => x.ID == id).proxim_to_center = new_proxim_to_center;
        }
        public void change_private_plot(int id, int new_private_plot)
        {
            flats.Find(x => x.ID == id).private_plot = new_private_plot;
        }
        public void change_add_info(int id, string new_add_info)
        {
            flats.Find(x => x.ID == id).add_info = new_add_info;
        }
        //info
        public string see_apartment_info(int AppartmentID)
        {
            return '\n' + flats.Find(x => x.ID == AppartmentID).ToString();
        }
        public string see_all_apartments()
        {
            string output = $"\nWe have {flats.Count} apartments and here they are. \n\n";
            foreach (var item in flats)
            {
                output = output + item.ToString() + '\n';
            }
            return output;
        }
        //sorting
        public void sort_apa_by_bed_r() { 
            flats.Sort((x, y) => x.bedroom_n.CompareTo(y.bedroom_n));
        }
        public void sort_apa_by_cost()
        {
            flats.Sort((x, y) => x.cost.CompareTo(y.cost));
        }
        //ADDITIONAL FUNCTIONALITY
        //1
        public string add_offer_to_cli(int ID, int aID) {
            if (clients.Exists(x => x.ID == ID))
            {
                clients.Find(x => x.ID == ID).offers.take_offer(flats.Find(x => x.ID == aID));
                return $"Client with ID {ID} now has apartment with ID {aID} as offer.";
            }
            else
            {
                return $"There is no clients with ID {ID}.";
            }
        }
        public string see_all_offers(int ID) {
            Offers_list offers = new Offers_list();
            offers = clients.Find(x => x.ID == ID).offers;
            string output = "";
            if (offers != null)
            {
                output = $"\nClient with ID {ID} has {offers.number_of_elements} offers. \n\n";
                for (int i = 0; i < offers.number_of_elements; i++)
                {
                    output = output + offers.offers[i].ToString() + '\n';
                }
            }
            else { 
                output = $"\nClient with ID {ID} has 0 offers. \n\n";
            }
            return output;
        }
        public bool does_takes(int ID, int aID) {
            return clients.Find(x => x.ID == ID).is_likes_suits(flats.Find(x => x.ID == aID));
        }
        //2
        public int find_cli_by_words(List<string> words) {
            foreach (var client in clients)
            {
                foreach (var word in words)
                {
                    if (client.add_info.ToLower().Contains(word.ToLower())) { return client.ID; }
                }            
            }
            return -1;
        }
        public int find_apa_by_words(List<string> words) {
            foreach (var flat in flats)
            {
                foreach (var word in words)
                {
                    if (flat.add_info.ToLower().Contains(word.ToLower())) { return flat.ID; }
                }
            }
            return -1;
        }
        public string find_by_words(List<string> words) {
            int if_apa = find_apa_by_words(words);
            int if_cli = find_cli_by_words(words);
            if (if_apa != -1) { return $"With there words was found apartment with ID: {if_apa}"; }
            if (if_cli != -1) { return $"With these words was found client with ID: {if_cli}"; }
            return "There`re no words like that.";
        }
        public int find_by_surname_bedr(string surname, int bedrooms_n) {
            foreach (var client in clients)
            {
                if (client.surname == surname && client.prefearings.bedroom_n.min == bedrooms_n)
                {                                                       //could be inconvinient because bedroom_n is a range, so it equate
                                                                       //bedrooms_n to min value of preferings.bedroom_n
                    return client.ID;
                }
            }
            return -1;
        }
    }
}
