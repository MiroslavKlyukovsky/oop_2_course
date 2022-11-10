using System;
using System.Collections.Generic;
using System.Text;
using BLL;

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
            string str = "";
            while (str != "S")
            {
                Console.WriteLine("Menu:\n" +
                                  " Add client: AC\n" +
                                  " Add offer to client: AO\n" +
                                  " Change rented apartment of the client: C\n" +
                                  " Change name of the client: CN\n" +
                                  " Cnahge bank account balance of client: CBB\n" +
                                  " Remove client: RC\n" +
                                  " Add apartment: AA\n" +
                                  " Remove apartment: RA\n" +
                                  " Watch all apartments: WA\n" +
                                  " Watch all clients: WC\n" +
                                  " Sort clients by name: SCN\n" +
                                  " Sort apartments by bedrooms: SAB\n" +
                                  " Find by words: FW\n" +
                                  " Check does client want the apartment: D\n" +
                                  "Save and end working: S\n");
                str = Console.ReadLine();
                switch (str[0])
                {//when inputed not correct nhmber of chars could be huge problem, so will be fixed!
                    case 'A':                                                   //Adding client or apartment
                        if (str[1] == 'C')
                        {
                            Console.WriteLine("So, we creating a new client)");
                            Console.WriteLine("Give his ID: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Give his name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Give his surname: ");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Give his bank account: ");
                            int bank_accout = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Give his bank account balance: ");
                            int bank_accout_balance = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("You can give any additional info: ");
                            string add_info = Console.ReadLine();
                            server.add_client(ID,name,surname,bank_accout,bank_accout_balance,add_info);
                            Console.WriteLine("Now give more information about client preferings: ");
                            Console.WriteLine("Minimal cost of apartment for the client: ");
                            int min_cost = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Maximal cost of apartment for the client: ");
                            int max_cost = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Minimal number of bedrooms in the flat: ");
                            int min_bed = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Maximal number of bedrooms in the flat: ");
                            int max_bed = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Minimal nicity of the futrniture in the flat (can be 1-10): ");
                            int min_furnt = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Maximal nicity of the futrniture in the flat (can be 1-10): ");
                            int max_furnt = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Minimal proximity to the center from the flat: ");
                            int min_proxim_to_cente = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Maximal proximity to the center from the flat: ");
                            int max_proxim_to_cente = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Minimal size of a private plot of the flat (square meters): ");
                            int min_private_plot = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Maximal size of a private plot of the flat (square meters): ");
                            int max_private_plot = Int32.Parse(Console.ReadLine());
                            server.add_prefearings(ID,min_cost,max_cost,min_bed,max_bed,min_furnt,max_furnt,min_proxim_to_cente,max_proxim_to_cente,min_private_plot,max_private_plot);
                        }
                        if (str[1] == 'A') 
                        {
                            Console.WriteLine("So we`re goning to add an apartment)");
                            Console.WriteLine("Enter the apartment ID: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the apartment cost: ");
                            int cost = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the number of bedrooms in the apartment: ");
                            int bedroom_n = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the furnituring level of the apartment (1-10): ");
                            int furnitering_level = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the proximity to the center of the apartment: ");
                            int proxim_to_center = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the size of the private plot of the apartment (square meters): ");
                            int private_plot = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("You can add any additional info about the flat: ");
                            string add_info = Console.ReadLine();
                            server.add_appartment(ID,cost,bedroom_n,furnitering_level,proxim_to_center,private_plot,add_info);
                        }
                        if (str[1] == 'O')
                        {
                            Console.WriteLine("Give ID of client: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Give ID of apartment: ");
                            int aID = Int32.Parse(Console.ReadLine());
                            server.add_offer_to_cli(ID,aID);
                        }
                        break;
                    case 'R':                                                   //Removing client or apartment
                        if (str[1] == 'C')
                        {
                            Console.WriteLine("Enter the ID of the client to be deleted: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            server.remove_client(ID);
                        }
                        if (str[1] == 'A')
                        {
                            Console.WriteLine("Enter the ID of the appartment to be deleted: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            server.remove_apartment(ID);
                        }
                        break;
                    case 'C':                                                   //Setting apartment to client
                        if (str.Length == 1)
                        {
                            Console.WriteLine("Enter ID of the client: ");
                            int CD = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter ID of the apartment of the apartment to be set: ");
                            int AD = Int32.Parse(Console.ReadLine());
                            server.change_client_rented_apartment(CD, AD);
                            break;
                        }
                        if (str[1] == 'N')
                        {
                            Console.WriteLine("So, we`re trying to rename a client.");
                            Console.WriteLine("Enter ID of client you want to change name: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Give new name: ");
                            string new_name = Console.ReadLine();
                            server.change_client_name(ID,new_name);
                            break;
                        }
                        if (str[1] == 'B' && str[2] == 'B')
                        {
                            Console.WriteLine("Give ID of client: ");
                            int ID = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Give his new balance");
                            int new_balance = Int32.Parse(Console.ReadLine());
                            server.change_client_bank_balance(ID,new_balance);
                            break;
                        }
                        break;
                    case 'W':                                                   //Watch all apartments or clients
                        if (str[1] == 'A')                                      
                        {
                            Console.WriteLine(server.see_all_apartments());
                        }
                        if (str[1] == 'C')
                        {
                            Console.WriteLine(server.see_all_clients());
                        }
                        break;
                    case 'S':
                        if ( str.Length == 3 && str[1] == 'C' && str[2] =='N')
                        {
                            server.sort_cli_by_name();
                        }
                        if (str.Length == 3 && str[1] == 'A' && str[2] == 'B')
                        {
                            server.sort_apa_by_bed_r();
                        }
                        break;
                    case 'F':
                        if (str[1] == 'W')
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
                        break;
                    case 'D':
                        Console.WriteLine("Give ID of client: ");
                        int ID1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Give ID of apartment: ");
                        int aID1 = Int32.Parse(Console.ReadLine());
                        bool flag = server.does_takes(ID1,aID1);
                        if (flag)
                        {
                            Console.WriteLine($"Apartment with ID {aID1} suit client.");
                        }
                        else { 
                            Console.WriteLine($"Apartment with ID {aID1} doesn`t suit client.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please try again:");
                        break;
                }
            }
            server.End_of_work();
        }
    }
}
