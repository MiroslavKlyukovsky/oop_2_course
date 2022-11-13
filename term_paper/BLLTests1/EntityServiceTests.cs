using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Text;

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
            service.client_serv.name_of_file = "TEST";

            //act
            service.add_client(100100, "Miroslav", "Klyukovsky", 10100,60000, "Nice guy. Likes sport.");
            service.add_prefearings(100100, 3000, 10000, 1, 2, 3, 6, 2, 6, 0, 5);
            string str = service.see_client_info(100100);

            //assert
            Assert.Fail();
            //Assert.AreEqual(, '\n' + clients.Find(x => x.ID == ClientID).ToString() + $"Offers: {see_all_offers(ClientID)}\n";);
        }

        [TestMethod()]
        public void remove_clientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void add_prefearingsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_idTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_rented_apartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_nameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_surnameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_bank_accountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_bank_balanceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_client_add_infoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void smash_or_pass_offersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void see_client_infoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void see_all_clientsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sort_cli_by_nameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sort_cli_by_surnameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sort_cli_by_bankTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void add_appartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void remove_apartmentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_apartment_costTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_apartment_bedroom_nTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_furnitering_levelTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_proxim_to_centerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_private_plotTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void change_add_infoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void see_apartment_infoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void see_all_apartmentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sort_apa_by_bed_rTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sort_apa_by_costTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void add_offer_to_cliTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void see_all_offersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void does_takesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void find_cli_by_wordsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void find_apa_by_wordsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void find_by_wordsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void find_by_surname_bedrTest()
        {
            Assert.Fail();
        }
    }
}