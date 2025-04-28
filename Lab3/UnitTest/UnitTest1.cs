using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System.Linq;

namespace Lab3Tests
{
    [TestClass]
    public class ListClassTests
    {
        private Employee CreateEmployee(int id, string name)
        {            
            return new Employee
            {
                Id = id,
                Name = name,
                LastName = "TestLastName",
                BankName = "TestBank",
                AccountNumber = "LT1234567890"
            };
        }

        [TestMethod]
        public void AddTestSingle()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Jonas");
            list.Add(employee);

            list.Start();
            Assert.IsTrue(list.Exists());
            Assert.AreEqual(employee, list.Get());
        }

        [TestMethod]
        public void AddTestMultiple()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "Jonas");
            var employee2 = CreateEmployee(2, "Pranas");
            var employee3 = CreateEmployee(3, "Bomba");

            list.Add(employee1);
            list.Add(employee2);
            list.Add(employee3);

            list.Start();
            Assert.AreEqual(employee1, list.Get());
            list.Next();
            Assert.AreEqual(employee2, list.Get());
            list.Next();
            Assert.AreEqual(employee3, list.Get());
        }

        [TestMethod]
        public void StartTest()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Romas");
            list.Add(employee);

            list.Start();
            Assert.AreEqual(employee, list.Get());
        }

        [TestMethod]
        public void NextTest()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "Tomas");
            var employee2 = CreateEmployee(2, "Andrius");

            list.Add(employee1);
            list.Add(employee2);

            list.Start();
            list.Next();
            Assert.AreEqual(employee2, list.Get());
        }

        [TestMethod]
        public void ExistsTest()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "John");
            list.Add(employee);

            list.Start();
            Assert.IsTrue(list.Exists());
        }

        [TestMethod]
        public void ExistsTestNull()
        {
            var list = new ListClass<Employee>();

            list.Start();
            Assert.IsFalse(list.Exists());
        }

        [TestMethod]
        public void GetTest()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "John");
            list.Add(employee);

            list.Start();
            var value = list.Get();
            Assert.AreEqual(employee, value);
        }

        [TestMethod]
        public void ContainsTestExists()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "John");
            var employee2 = CreateEmployee(2, "Jane");

            list.Add(employee1);
            list.Add(employee2);

            Assert.IsTrue(list.Contains(employee2));
        }

        [TestMethod]
        public void ContainsTestNonexistant()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "John");
            var employee2 = CreateEmployee(2, "Jane");

            list.Add(employee1);

            Assert.IsFalse(list.Contains(employee2));
        }

        [TestMethod]
        public void SortTest()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(3, "Doe");
            var employee2 = CreateEmployee(1, "John");
            var employee3 = CreateEmployee(2, "Jane");

            list.Add(employee1);
            list.Add(employee2);
            list.Add(employee3);

            list.Sort();
            list.Start();

            Assert.AreEqual(employee2, list.Get());
            list.Next();
            Assert.AreEqual(employee3, list.Get());
            list.Next();
            Assert.AreEqual(employee1, list.Get());
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "John");
            var employee2 = CreateEmployee(2, "Jane");
            var employee3 = CreateEmployee(3, "Doe");

            list.Add(employee1);
            list.Add(employee2);
            list.Add(employee3);

            var elements = list.ToList();
            CollectionAssert.AreEqual(new[] { employee1, employee2, employee3 }, elements);
        }
    }
}