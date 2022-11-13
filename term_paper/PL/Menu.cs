using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using System.Text.RegularExpressions;

namespace PL
{
    public class Menu
    {
        EntityService server;
        public Menu()
        {
            server = new EntityService();
        }
        public void MainMenu()
        {
            string str = "H";
            while (str != "S")
            {
                if (str.Length > 0 && str[0] == 'H')
                {
                    Console.WriteLine("Menu:\n" +
                    " Client:\n" +
                    "   Add client: AC\n" +
                    "   Add offer to client: AO\n" +
                    "   Check all client offers: CO\n" +
                    "   Change client ID : CI\n" +
                    "   Change rented apartment of the client: C\n" +
                    "   Change name of the client: CN\n" +
                    "   Change surname: CS\n" +
                    "   Change bank account: CBA\n" +
                    "   Change bank account balance of client: CBB\n" +
                    "   Change additional info: CA\n" +
                    "   Remove client: RC\n" +
                    "   Watch all clients: WC\n" +
                    "   Watch single client: WSC\n" +
                    "   Watch all offers of client: WO\n" +
                    "   Sort clients by name: TCN\n" +
                    "   Sort clients by surname: TCS\n" +
                    "   Sort clients by 1st number of bank account: TCB\n" +
                    "   Check does client want the apartment: D\n" +
                    "   Find client by surname and min bedroom number: F\n" +
                    "   Find by words in additional info: FWC\n" +
                    " Apartment:\n" +
                    "   Add apartment: AA\n" +
                    "   Remove apartment: RA\n" +
                    "   Change cost: CC\n" +
                    "   Change bedroom number: CB\n" +
                    "   Change furnituring level: CF\n" +
                    "   Change proximity to the center: CP\n" +
                    "   Change private plot: CT\n" +
                    "   Change additional info: CD\n" +
                    "   Watch all apartments: WA\n" +
                    "   Watch single apartment: WSA\n" +
                    "   Sort apartments by bedrooms: TAB\n" +
                    "   Sort by cost: TAC\n" +
                    "   Find apartment by words in additional info: FWA\n" +
                    " For both:\n" +
                    "   Find by words: FW\n" +
                    "Save and end working: S\n" +
                    "Type H to see Menu again.");
                }
                str = Console.ReadLine();                              //Check command
                if (!is_correct_command(str)) { continue; }
                switch (str[0])
                {
                    case 'A':                                                  
                        if (str[1] == 'C')
                        {
                            Console.WriteLine("So, we creating a new client)");
                            
                            Console.WriteLine("Give his ID (******, where * is a number(0-9)): ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID,"ID");
                            
                            Console.WriteLine("Give his name: ");
                            string name = Console.ReadLine();
                            
                            Console.WriteLine("Give his surname: ");
                            string surname = Console.ReadLine();
                            
                            Console.WriteLine("Give his bank account (*****, where * is a number(0-9)): ");
                            int bank_accout = 0;
                            is_Valid("^[1-9][0-9]{4}$", Console.ReadLine(), ref bank_accout, "bank account");
                            
                            Console.WriteLine("Give his bank account balance (not bigger than 7 numbers, not less then 1 number): ");
                            int bank_accout_balance = 0;
                            is_Valid("^[1-9][0-9]{0,6}$",Console.ReadLine(), ref bank_accout_balance,"bank account balance");
                            
                            Console.WriteLine("You can give any additional info: ");
                            
                            string add_info = Console.ReadLine();
                            
                            server.add_client(ID,name,surname,bank_accout,bank_accout_balance,add_info);
                            

                            Console.WriteLine("Now give more information about client preferings: ");
                            
                            Console.WriteLine("Minimal cost of apartment for the client (not more 5 number digit): ");
                            int min_cost = 0;
                            is_Valid("^[1-9][0-9]{1,4}$", Console.ReadLine(), ref min_cost, "minimal cost");

                            Console.WriteLine("Maximal cost of apartment for the client (not more 6 number digit): ");
                            int max_cost = 0;
                            is_Valid("^[1-9][0-9]{1,5}$", Console.ReadLine(), ref max_cost, "maximal cost");

                            Console.WriteLine("Minimal number of bedrooms in the flat (not more than 99): ");
                            int min_bed = 0;
                            is_Valid("^[1-9][0-9]{0,1}$", Console.ReadLine(), ref min_bed, "min number of beds");

                            Console.WriteLine("Maximal number of bedrooms in the flat (not more than 999): ");
                            int max_bed = 0;
                            is_Valid("^[1-9][0-9]{0,2}$", Console.ReadLine(), ref max_bed, "max number of beds");

                            Console.WriteLine("Minimal nicity of the futrniture in the flat (can be 1-10): ");
                            int min_furnt = 0;
                            is_Valid("^[1-9]|[10]$", Console.ReadLine(), ref min_furnt, "min furnituring");

                            Console.WriteLine("Maximal nicity of the futrniture in the flat (can be 1-10): ");
                            int max_furnt = 0;
                            is_Valid("^[1-9]|[10]$", Console.ReadLine(), ref max_furnt, "max furnituring");

                            Console.WriteLine("Minimal proximity to the center from the flat (0-15): ");
                            int min_proxim_to_cente = 0;
                            is_Valid("^[0-9]$|^1[0-5]$", Console.ReadLine(), ref min_proxim_to_cente, "min proxim to the center");

                            Console.WriteLine("Maximal proximity to the center from the flat (5-35): ");
                            int max_proxim_to_cente = 0;
                            is_Valid("^[5-9]$|^[1-2][0-9]$|^3[0-5]$", Console.ReadLine(), ref min_proxim_to_cente, "max proxim to the center");

                            Console.WriteLine("Minimal size of a private plot of the flat (square meters)(0-10): ");
                            int min_private_plot = 0;
                            is_Valid("^[0-9]$|^10$", Console.ReadLine(), ref min_private_plot, "minimal size of a private plot");

                            Console.WriteLine("Maximal size of a private plot of the flat (square meters)(up to 200): ");
                            int max_private_plot = 0;
                            is_Valid("^0$|^[1-9][0-9]$|^1[0-9][0-9]$|^200$", Console.ReadLine(), ref max_private_plot, "maximal size of a private plot");

                            server.add_prefearings(ID,min_cost,max_cost,min_bed,max_bed,min_furnt,max_furnt,min_proxim_to_cente,max_proxim_to_cente,min_private_plot,max_private_plot);
                        }
                        if (str[1] == 'A') 
                        {
                            Console.WriteLine("So we`re goning to add an apartment)");
                            
                            Console.WriteLine("Enter the apartment ID ([1-9][0-9]{5}): ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");

                            Console.WriteLine("Enter the apartment cost (2-6 digits): ");
                            int cost = 0;
                            is_Valid("^[1-9][0-9]{1,5}$", Console.ReadLine(), ref cost, "cost");

                            Console.WriteLine("Enter the number of bedrooms in the apartment (up to 199): ");
                            int bedroom_n = 0;
                            is_Valid("^[1-9][0-9]{0,2}$", Console.ReadLine(), ref bedroom_n, "bedrooms");

                            Console.WriteLine("Enter the furnituring level of the apartment (1-10): ");
                            int furnitering_level = 0;
                            is_Valid("^[0-9]$|^10$", Console.ReadLine(), ref furnitering_level, "furniture");

                            Console.WriteLine("Enter the proximity to the center of the apartment (0-35): ");
                            int proxim_to_center = 0;
                            is_Valid("^[0-9]$|^[1-2][0-9]$|^3[0-5]$", Console.ReadLine(), ref proxim_to_center, "proximity");

                            Console.WriteLine("Enter the size of the private plot of the apartment (square meters)(0-200): ");
                            int private_plot = 0;
                            is_Valid("^[0-9]$|^[1-9][0-9]$|1[0-9]{2}|^200$", Console.ReadLine(), ref private_plot, "private plot");

                            Console.WriteLine("You can add any additional info about the flat: ");
                            string add_info = Console.ReadLine();
                            
                            server.add_appartment(ID,cost,bedroom_n,furnitering_level,proxim_to_center,private_plot,add_info);
                        }
                        if (str[1] == 'O')
                        {
                            Console.WriteLine("Give ID of client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give ID of apartment: ");
                            int aID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref aID, "aID");
                            server.add_offer_to_cli(ID,aID);
                        }                                  
                        break;
                    case 'R':                                                  
                        if (str[1] == 'C')
                        {
                            Console.WriteLine("Enter the ID of the client to be deleted: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            server.remove_client(ID);
                        }
                        if (str[1] == 'A')
                        {
                            Console.WriteLine("Enter the ID of the appartment to be deleted: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            server.remove_apartment(ID);
                        }
                        break;
                    case 'C':                                                   
                        if (str.Length == 1)
                        {
                            Console.WriteLine("Enter ID of the client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");

                            Console.WriteLine("Enter ID of the apartment of the apartment to be set: ");
                            int aID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref aID, "aID");
                            
                            server.change_client_rented_apartment(ID, aID);
                            break;
                        }                                
                        if (str[1] == 'N')
                        {
                            Console.WriteLine("So, we`re trying to rename a client.");
                            Console.WriteLine("Enter ID of client you want to change name: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new name: ");
                            string new_name = Console.ReadLine();
                            server.change_client_name(ID,new_name);
                            break;
                        }
                        if (str[1] == 'O') {
                            Console.WriteLine("Enter the ID of the client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine(server.smash_or_pass_offers(ID));
                        }
                        if (str[1] == 'I')
                        {
                            Console.WriteLine("Give ID (******, where * is a number(0-9)): ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$|^-1$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give his new ID (******, where * is a number(0-9)): ");
                            int nID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref nID, "ID");
                            server.change_client_id(ID,nID);
                        }
                        if (str[1] == 'A')
                        {
                            Console.WriteLine("Enter ID of client you want to change additional info: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new add info: ");
                            string new_add_info = Console.ReadLine();
                            server.change_client_add_info(ID, new_add_info);
                            break;
                        }                                  
                        if (str[1] == 'S')
                        {
                            Console.WriteLine("Enter the ID of the client to change surname: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new surname: ");
                            string new_surname = Console.ReadLine();
                            server.change_client_surname(ID, new_surname);
                        }                                   
                        if (str[1] == 'C')
                        {
                            Console.WriteLine("Enter the ID of the apartment to change cost: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new cost: ");
                            int new_cost = 0;
                            is_Valid("^[1-9][0-9]{1,5}$", Console.ReadLine(), ref new_cost, "ID");
                            server.change_apartment_cost(ID, new_cost);
                        }
                        if (str[1] == 'B')
                        {
                            Console.WriteLine("Enter the ID of the apartment to bedroom number: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new bedrooms number: ");
                            int new_bed_n = 0;
                            is_Valid("^[1-9][0-9]{0,2}$", Console.ReadLine(), ref new_bed_n, "bedrooms");
                            server.change_apartment_bedroom_n(ID, new_bed_n);
                        }
                        if (str[1] == 'F')
                        {
                            Console.WriteLine("Enter the ID of the apartment to change furnituring level: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new new level: ");
                            int new_furnitering_level = 0;
                            is_Valid("^[0-9]$|^10$", Console.ReadLine(), ref new_furnitering_level, "furniture");
                            server.change_furnitering_level(ID, new_furnitering_level);
                        }
                        if (str[1] == 'P')
                        {
                            Console.WriteLine("Enter the ID of the apartment to change proximity to the center: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new proximity: ");
                            int new_proxim = 0;
                            is_Valid("^[0-9]$|^[1-2][0-9]$|^3[0-5]$", Console.ReadLine(), ref new_proxim, "proximity");
                            server.change_proxim_to_center(ID, new_proxim);
                        }
                        if (str[1] == 'T')
                        {
                            Console.WriteLine("Enter the ID of the apartment to change private plot: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new private plot: ");
                            int new_private_plot = 0;
                            is_Valid("^[0-9]$|^[1-9][0-9]$|1[0-9]{2}|^200$", Console.ReadLine(), ref new_private_plot, "private plot");

                            server.change_private_plot(ID, new_private_plot);
                        }
                        if (str[1] == 'D')
                        {
                            Console.WriteLine("Enter the ID of the apartment to change additional info: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give new additional info: ");
                            string add_info = Console.ReadLine();
                            server.change_add_info(ID, add_info);
                        }
                        if (str.Length == 3 && str[1] == 'B' && str[2] == 'B')
                        {
                            Console.WriteLine("Give ID of client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give his new balance");
                            int new_balance = 0;
                            is_Valid("^[1-9][0-9]{0,6}$", Console.ReadLine(), ref new_balance, "bank account balance");
                            server.change_client_bank_balance(ID,new_balance);
                            break;
                        }                  
                        if (str.Length == 3 && str[1] == 'B' && str[2] == 'A')
                        {
                            Console.WriteLine("Give ID of client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine("Give his new bank account: ");
                            int new_bank_accout = 0;
                            is_Valid("^[1-9][0-9]{4}$", Console.ReadLine(), ref new_bank_accout, "bank account");
                            server.change_client_bank_account(ID, new_bank_accout);
                            break;
                        }                   
                        break;
                    case 'W':                                                     
                        if (str.Length == 3 && str[1] == 'S' && str[2] == 'A')
                        {
                            Console.WriteLine("Enter ID of the apartment: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine(server.see_apartment_info(ID));
                        }
                        if (str.Length == 3 && str[1] == 'S' && str[2] == 'C')
                        {
                            Console.WriteLine("Enter ID of the client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine(server.see_client_info(ID));
                        }
                        if (str[1] == 'A')                                      
                        {
                            Console.WriteLine(server.see_all_apartments());
                        }                                    
                        if (str[1] == 'C')
                        {
                            Console.WriteLine(server.see_all_clients());
                        }
                        if (str[1] == 'O')
                        {
                            Console.WriteLine("Enter ID of the client: ");
                            int ID = 0;
                            is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref ID, "ID");
                            Console.WriteLine(server.see_all_offers(ID));
                        }
                        break;
                    case 'T':
                        if (str.Length == 3 && str[1] == 'C' && str[2] =='N')
                        {
                            server.sort_cli_by_name();
                        }
                        if (str.Length == 3 && str[1] == 'C' && str[2] == 'S')
                        {
                            server.sort_cli_by_surname();
                        }
                        if (str.Length == 3 && str[1] == 'C' && str[2] == 'B')
                        {
                            server.sort_cli_by_bank();
                        }
                        if (str.Length == 3 && str[1] == 'A' && str[2] == 'B')
                        {
                            server.sort_apa_by_bed_r();
                        }
                        if (str.Length == 3 && str[1] == 'A' && str[2] == 'C')
                        {
                            server.sort_apa_by_cost();
                        }
                        break;
                    case 'F':
                        if (str.Length == 1)
                        {
                            Console.WriteLine("Surname: ");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Bedrooms: ");
                            int bedroom_n = 0;
                            is_Valid("^[1-9][0-9]{0,2}$", Console.ReadLine(), ref bedroom_n, "bedrooms");
                            Console.WriteLine(server.find_by_surname_bedr(surname,bedroom_n));
                        }
                        if (str.Length == 2 && str[1] == 'W')
                        {
                            Console.WriteLine("Give list of key words separated by ' ': ");
                            string words = Console.ReadLine();
                            string[] swords = words.Split(' ');
                            List<string> lis = new List<string>();
                            foreach (var item in swords)
                            {
                                lis.Add(item);
                            }
                            Console.WriteLine(server.find_by_words(lis));
                        }
                        if (str.Length == 3 && str[1] == 'W' && str[2] == 'C')
                        {
                            Console.WriteLine("Give list of key words separated by ' ': ");
                            string words = Console.ReadLine();
                            string[] swords = words.Split(' ');
                            List<string> lis = new List<string>();
                            foreach (var item in swords)
                            {
                                lis.Add(item);
                            }
                            Console.WriteLine("Client with ID: " + server.find_cli_by_words(lis));
                        }
                        if (str.Length == 3 && str[1] == 'W' && str[2] == 'A')
                        {
                            Console.WriteLine("Give list of key words separated by ' ': ");
                            string words = Console.ReadLine();
                            string[] swords = words.Split(' ');
                            List<string> lis = new List<string>();
                            foreach (var item in swords)
                            {
                                lis.Add(item);
                            }
                            Console.WriteLine(server.find_apa_by_words(lis));
                        }
                        break;
                    case 'D':
                        Console.WriteLine("Give ID of client: ");
                        int сID = 0;
                        is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref сID, "ID");
                        Console.WriteLine("Give ID of apartment: ");
                        int AID = 0;
                        is_Valid("^[1-9][0-9]{5}$", Console.ReadLine(), ref AID, "aID");
                        bool flag = server.does_takes(сID,AID);
                        if (flag)
                        {
                            Console.WriteLine($"Apartment with ID {AID} suit client.");
                        }
                        else { 
                            Console.WriteLine($"Apartment with ID {AID} doesn`t suit client.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please try again:");
                        break;
                }
            }
            server.End_of_work();
        }
        private bool is_correct_command(string command)
        {
            string strRegex = @"^H$|^S$|^A[CAO]$|^R[CA]$|^C[NASCOTDIBFP]$|^CB[BA]$|^W[ACO]$|^WS[AC]$|^TC[NSB]$|^TA[BC]$|^F$|^FW$|^FW[CA]$|^D$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(command);
        }
        private void is_Valid(string regx, string input, ref int value, string name_of_value) {
            string strRegex = @"";
            strRegex = strRegex.Insert(0,regx);
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input)) 
            {
                value = Int32.Parse(input);
            }
            else
            {
                Console.WriteLine($"Due to wrong format of {name_of_value}, it setted to -1. You must to change it later.");
                value = -1;
            }
        }
    }
}
