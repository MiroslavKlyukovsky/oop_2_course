using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests
{
    [TestClass()]
    public class EntityService_studTests
    {
        [TestMethod()]
        public void take_dataTest_with_1()
        {
            //arange
            var server = new EntityService_stud();

            //act
            bool flag = server.take_data(1);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void take_dataTest_with_3()
        {
            //arange
            var server = new EntityService_stud();

            //act
            bool flag = server.take_data(3);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void take_dataTest_with_111()
        {
            //arange
            var server = new EntityService_stud();

            //act
            bool flag = server.take_data(111);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void give_dataTest_with_2()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 2, 1, 10, 5);

            //act
            bool flag = server.give_data(2);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void give_dataTest_with_4()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 2, 2, 3, 5);

            //act
            bool flag = server.give_data(4);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void give_dataTest_with_24()
        {
            //arange
            var server = new EntityService_stud();

            //act
            bool flag = server.give_data(24);

            //assert
            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void add_studentTest()
        {
            //arange
            var server = new EntityService_stud();

            //act
            bool flag = server.add_student("Miroslav", "Klyukovsky", 2, 1000, 1, 5);

            //assert
            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void remove_studentTest_with_1111111()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 2, 1001, 1, 5);


            //act
            string flag = server.remove_student(1111111);

            //assert
            Assert.AreEqual($"There are no students with ID {1111111}", flag);
        }

        [TestMethod()]
        public void remove_studentTest_with_1000_no_students()
        {
            //arange
            var server = new EntityService_stud();

            //act
            string flag = server.remove_student(1000);

            //assert
            Assert.AreEqual("There are no students at all!", flag);
        }

        [TestMethod()]
        public void remove_studentTest_with_1001()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 2, 1001, 1, 5);

            //act
            string flag = server.remove_student(1001);

            //assert
            Assert.AreEqual($"Student with ID {1001} was successfully removed.", flag);
        }

        [TestMethod()]
        public void course_2_sportTest_2()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 2, 100, 1, 5);
            server.add_student("Miroslav", "Klyukovsky", 2, 101, 2, 5);

            //act
            int flag = server.course_2_sport();

            //assert
            Assert.AreEqual(2, flag);
        }

        [TestMethod()]
        public void course_2_sportTest1()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 1, 100, 4, 5);
            server.add_student("Miroslav", "Klyukovsky", 2, 101, 3, 5);

            //act
            int flag = server.course_2_sport();

            //assert
            Assert.AreEqual(1, flag);
        }

        [TestMethod()]
        public void about_studTest()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 1, 1000, 1, 5);

            //act
            string flag = server.about_stud(1000);

            //assert
            Assert.AreEqual($"First name: {"Miroslav"}\nLast name: {"Klyukovsky"}\nStudent ID: {1000}\nStudent course: {1}\nStudent hobby: {"sport"}\nStudent hobby id: {1}\nLevel in sport: {5}", flag);
        }

        [TestMethod()]
        public void get_allTest()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 1, 1000, 1, 5);
            server.add_student("Miroslav", "Klyukovsky", 1, 1001, 1, 5);

            //act
            string flag = server.get_all();

            //assert
            Assert.AreEqual($"First name: {"Miroslav"}\nLast name: {"Klyukovsky"}\nStudent ID: {1000}\nStudent course: {1}\nStudent hobby: {"sport"}\nStudent hobby id: {1}\nLevel in sport: {5}\n" +
                            $"First name: {"Miroslav"}\nLast name: {"Klyukovsky"}\nStudent ID: {1001}\nStudent course: {1}\nStudent hobby: {"sport"}\nStudent hobby id: {1}\nLevel in sport: {5}\n", flag);
        }

        [TestMethod()]
        public void enroll_teamTest_agree()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 1, 100, 1, 5);
            server.add_student("Miroslav", "Klyukovsky", 2, 101, 2, 10);

            //act
            string flag = server.enroll_team(2);

            //assert
            Assert.AreEqual($"Student with sport ID: {2} can enroll in the sport team!", flag);
        }

        [TestMethod()]
        public void enroll_teamTest_disagree()
        {
            //arange
            var server = new EntityService_stud();
            server.add_student("Miroslav", "Klyukovsky", 1, 100, 1, 5);
            server.add_student("Miroslav", "Klyukovsky", 2, 101, 2, 10);

            //act
            string flag = server.enroll_team(1);

            //assert
            Assert.AreEqual($"Student with sport ID: {1} can't enroll in the sport team!", flag);
        }

        [TestMethod()]
        public void guitar_comming_1() {
            //arange
            var server = new EntityService_stud();
            
            //act
            string str = server.guitar_comming(1);
            
            //assert
            if (str == "Fireman Viktor Tyshila hasn't arrived in time. My name is Viktor and I'm extinguishing fire!" || str == "Fireman Viktor Tyshila has arrived in time. My name is Viktor. I`m fireman. Watch me playing the guitar!. My name is Viktor and I'm extinguishing fire!")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void guitar_comming_2()
        {
            //arange
            var server = new EntityService_stud();
            
            //act
            string str = server.guitar_comming(2);
            
            //assert
            if (str == "Courier Viktor Dostavko hasn't arrived in time. My name is Viktor and I'm delivering!" || str == "Courier Viktor Dostavko has arrived in time. My name is Viktor. I`m courier. Watch me playing the guitar!. My name is Viktor and I'm delivering!")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void guitar_comming_1111()
        {
            //arange
            var server = new EntityService_stud();
            
            //act
            string str = server.guitar_comming(1111);
            
            //assert
            if (str == "Wrong number!")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}