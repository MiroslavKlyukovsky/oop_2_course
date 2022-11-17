using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace BLL.Tests
{
    [TestClass()]
    public class EntityServiceTests
    {
        [TestMethod()]
        public void add_clientTest()
        {
            //arange
            EntityService service = new EntityService();
                        //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.see_client_info(100100);

            //assert
            Assert.AreEqual($"\nClient ID: {100100};\n Name: {"Miroslav"};\n Surname: {"Klyukovsky"};\n " +
                   $"Bank account number: {10100}:\n  balance: {60000};\n " +
                   $"Preferings of client about apartment: \n" +
                   $"  Cost: {0}-{0}\n  " +
                   $"Bedroom number: {0}-{0}\n  " +
                   $"Furnitering level: {0}-{0}\n  " +
                   $"Proximity to the center: {0}-{0}\n  " +
                   $"Private plot: {0}-{0}\n " +
                   $"Additional info: {"Nice guy. Likes sport."}\n " +
                   $"Flat ID (-1 means none): {-1}\n" +
                   $"Offers: \nClient with ID 100100 has 0 offers. \n\n\n", str);
        }

        [TestMethod()]
        public void remove_clientest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            service.add_prefearings(100100, 3000, 10000, 1, 2, 3, 6, 2, 6, 0, 5);
            string str = service.remove_client(100100);

            //assert
            Assert.AreEqual($"Client with ID {100100} removed.", str);
        }

        [TestMethod()]
        public void add_prefearingsTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            service.add_prefearings(100100, 3000, 10000, 1, 2, 3, 6, 2, 6, 0, 5);
            string str = service.see_client_info(100100);

            //assert
            Assert.AreEqual($"\nClient ID: {100100};\n Name: {"Miroslav"};\n Surname: {"Klyukovsky"};\n " +
                   $"Bank account number: {10100}:\n  balance: {60000};\n " +
                   $"Preferings of client about apartment: \n" +
                   $"  Cost: {3000}-{10000}\n  " +
                   $"Bedroom number: {1}-{2}\n  " +
                   $"Furnitering level: {3}-{6}\n  " +
                   $"Proximity to the center: {2}-{6}\n  " +
                   $"Private plot: {0}-{5}\n " +
                   $"Additional info: {"Nice guy. Likes sport."}\n " +
                   $"Flat ID (-1 means none): {-1}\n" +
                   $"Offers: \nClient with ID 100100 has 0 offers. \n\n\n", str);
        }

        [TestMethod()]
        public void change_client_idTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_id(100100, 100101);

            //assert
            Assert.AreEqual($"Client with ID {100100} now has ID {100101}.", str);
        }

        [TestMethod()]
        public void change_client_rented_apartmentTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.change_client_rented_apartment(100100,100101);

            //assert
            Assert.AreEqual($"Client with ID {100100} now has apartment with ID {100101}.", str);
        }

        [TestMethod()]
        public void change_client_nameTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_name(103102, "Yaroslav");

            //assert
            Assert.AreEqual($"There is no client with ID {103102}.", str);
        }

        [TestMethod()]
        public void change_client_surnameTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_surname(100100, "Yar");

            //assert
            Assert.AreEqual($"Client with ID {100100} now has surname {"Yar"}.", str);
        }

        [TestMethod()]
        public void change_client_bank_accountTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_bank_account(100100, 10101);

            //assert
            Assert.AreEqual($"Client with ID {100100} now has bank account {10101}.", str);
        }

        [TestMethod()]
        public void change_client_bank_balanceTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_bank_balance(100100, 100000);

            //assert
            Assert.AreEqual($"Client with ID {100100} now has bank balance {100000}.", str);
        }

        [TestMethod()]
        public void change_client_add_infoTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.change_client_add_info(100100, "Dipka pipka");

            //assert
            Assert.AreEqual($"Client with ID {100100} now has add info: {"Dipka pipka"}.", str);
        }

        [TestMethod()]
        public void smash_or_pass_offersTest()
        {
             //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100104, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            string str = service.smash_or_pass_offers(100104);
            
            //assert
            Assert.AreEqual("No offers to reflect.", str);
        }

        [TestMethod()]
        public void add_appartmentTest()
        {
            //arange
            EntityService service = new EntityService();
                    //service.client_serv.name_of_file = "TEST";

            //act
            string str = service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");

            //assert
            Assert.AreEqual('\n' + 
                   $"Flat ID: {100101};\n" +
                   $"Cost: {4500};\n" +
                   $"Bedrooms: {1};\n" +
                   $"Furnituring level (1-10): {4};\n" +
                   $"Proximity to the center (km): {4};\n" +
                   $"Size of the private plot (square meters): {5};\n" +
                   $"Additional info: {"Flat."};\n", str);
        }

        [TestMethod()]
        public void remove_apartmentTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.remove_apartment(100101);
         
            //assert
            Assert.AreEqual($"Flat with ID {100101} removed.", str);
        }

        [TestMethod()]
        public void change_apartment_costTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.change_apartment_cost(100101,3450);

            //assert
            Assert.AreEqual($"Flat with ID {100101} now has cost {3450}.", str);
        }

        [TestMethod()]
        public void change_apartment_bedroom_nTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.change_apartment_bedroom_n(100101, 3);

            //assert
            Assert.AreEqual($"Flat with ID {100101} now has bedroom number {3}.", str);
        }

        [TestMethod()]
        public void change_furnitering_levelTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.change_furnitering_level(100101,6);

            //assert
            Assert.AreEqual($"Flat with ID {100101} now has furnituring level {6}.", str);
        }

        [TestMethod()]
        public void see_apartment_infoTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Flat.");
            string str = service.see_apartment_info(100101);
            //assert
            Assert.AreEqual('\n' +
                   $"Flat ID: {100101};\n" +
                   $"Cost: {4500};\n" +
                   $"Bedrooms: {1};\n" +
                   $"Furnituring level (1-10): {4};\n" +
                   $"Proximity to the center (km): {4};\n" +
                   $"Size of the private plot (square meters): {5};\n" +
                   $"Additional info: {"Flat."};\n", str);
        }

        [TestMethod()]
        public void add_offer_to_cliTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            service.add_appartment(100101, 4500, 1, 4, 4, 4, "Flat.");
            string str = service.add_offer_to_cli(100100, 100101);

            //assert
            Assert.AreEqual($"Client with ID {100100} now has apartment with ID {100101} as offer.", str);
        }

        [TestMethod()]
        public void does_takesTest()
        {
            //arange
            EntityService service = new EntityService();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100, 60000, "Nice guy. Likes sport.");
            service.add_prefearings(100100, 3000, 10000, 1, 2, 3, 6, 2, 6, 0, 5);
            service.add_appartment(100101, 4500, 1, 4, 4, 4, "Flat.");
            bool flag = service.does_takes(100100,100101);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void find_by_wordsTest()
        {
            //arange
            EntityService service = new EntityService();
            List<string> list = new List<string>();
            //service.client_serv.name_of_file = "TEST";

            //act
            service.add_appartment(100101, 4500, 1, 4, 4, 5, "Grass.");
            list.Add("Grass.");
            string str = service.find_by_words(list);

            //assert
            Assert.AreEqual($"With there words was found apartment with ID: {100101}", str);
        }
    }
}