using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System.Linq;

namespace Lab3Tests
{
    [TestClass]
    public class ListClassTestsEmployee
    {
        private Employee CreateEmployee(int id, string name)
        {
            return new Employee(id, name, "TestLastName", "TestBank", "LT1234567890");
        }

        [TestMethod]
        public void Add_SingleEmployee_ShouldContainEmployee()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Jonas");
            list.Add(employee);

            list.Start();
            Assert.IsTrue(list.Exists());
            Assert.AreEqual(employee, list.Get());
        }

        [TestMethod]
        public void Add_MultipleEmployees_ShouldContainEmployeesInOrder()
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
        public void Start_ShouldPointToFirstEmployee()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Romas");
            list.Add(employee);

            list.Start();
            Assert.AreEqual(employee, list.Get());
        }

        [TestMethod]
        public void Next_ShouldMoveToNextEmployee()
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
        public void Exists_ShouldReturnTrue_WhenEmployeeExists()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Jonas");
            list.Add(employee);

            list.Start();
            Assert.IsTrue(list.Exists());
        }

        [TestMethod]
        public void Exists_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new ListClass<Employee>();

            list.Start();
            Assert.IsFalse(list.Exists());
        }

        [TestMethod]
        public void Get_ShouldReturnCurrentEmployee()
        {
            var list = new ListClass<Employee>();
            var employee = CreateEmployee(1, "Jonas");
            list.Add(employee);

            list.Start();
            var value = list.Get();
            Assert.AreEqual(employee, value);
        }

        [TestMethod]
        public void Contains_ShouldReturnTrue_WhenEmployeeExists()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "Jonas");
            var employee2 = CreateEmployee(2, "Pranas");

            list.Add(employee1);
            list.Add(employee2);

            Assert.IsTrue(list.Contains(employee2));
        }

        [TestMethod]
        public void Contains_ShouldReturnFalse_WhenEmployeeDoesNotExist()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "Jonas");
            var employee2 = CreateEmployee(2, "Pranas");

            list.Add(employee1);

            Assert.IsFalse(list.Contains(employee2));
        }

        [TestMethod]
        public void Sort_ShouldSortEmployeesByIdAscending()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(3, "Bananas");
            var employee2 = CreateEmployee(1, "Jonas");
            var employee3 = CreateEmployee(2, "Pranas");

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
        public void Enumerator_ShouldReturnAllEmployees()
        {
            var list = new ListClass<Employee>();
            var employee1 = CreateEmployee(1, "Jonas");
            var employee2 = CreateEmployee(2, "Pranas");
            var employee3 = CreateEmployee(3, "Bananas");

            list.Add(employee1);
            list.Add(employee2);
            list.Add(employee3);

            var elements = list.ToList();
            CollectionAssert.AreEqual(new[] { employee1, employee2, employee3 }, elements);
        }
    }
}