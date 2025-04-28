using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System.Linq;

namespace Lab3Tests
{
    [TestClass]
    public class ListClassTestsInt
    {
        [TestMethod]
        public void Add_SingleInt_ShouldContainInt()
        {
            var list = new ListClass<int>();
            list.Add(1);

            list.Start();
            Assert.IsTrue(list.Exists());
            Assert.AreEqual(1, list.Get());
        }

        [TestMethod]
        public void Add_MultipleInts_ShouldContainIntsInOrder()
        {
            var list = new ListClass<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Start();
            Assert.AreEqual(1, list.Get());
            list.Next();
            Assert.AreEqual(2, list.Get());
            list.Next();
            Assert.AreEqual(3, list.Get());
        }

        [TestMethod]
        public void Start_ShouldPointToFirstInt()
        {
            var list = new ListClass<int>();
            list.Add(5);

            list.Start();
            Assert.AreEqual(5, list.Get());
        }

        [TestMethod]
        public void Next_ShouldMoveToNextInt()
        {
            var list = new ListClass<int>();
            list.Add(5);
            list.Add(10);

            list.Start();
            list.Next();
            Assert.AreEqual(10, list.Get());
        }

        [TestMethod]
        public void Exists_ShouldReturnTrue_WhenIntExists()
        {
            var list = new ListClass<int>();
            list.Add(1);

            list.Start();
            Assert.IsTrue(list.Exists());
        }

        [TestMethod]
        public void Exists_ShouldReturnFalse_WhenListIsEmpty()
        {
            var list = new ListClass<int>();

            list.Start();
            Assert.IsFalse(list.Exists());
        }

        [TestMethod]
        public void Get_ShouldReturnCurrentInt()
        {
            var list = new ListClass<int>();
            list.Add(99);

            list.Start();
            var value = list.Get();
            Assert.AreEqual(99, value);
        }

        [TestMethod]
        public void Contains_ShouldReturnTrue_WhenIntExists()
        {
            var list = new ListClass<int>();
            list.Add(1);
            list.Add(2);

            Assert.IsTrue(list.Contains(2));
        }

        [TestMethod]
        public void Contains_ShouldReturnFalse_WhenIntDoesNotExist()
        {
            var list = new ListClass<int>();
            list.Add(1);

            Assert.IsFalse(list.Contains(2));
        }

        [TestMethod]
        public void Sort_ShouldSortIntsByAscending()
        {
            var list = new ListClass<int>();
            list.Add(30);
            list.Add(10);
            list.Add(20);

            list.Sort();
            list.Start();

            Assert.AreEqual(10, list.Get());
            list.Next();
            Assert.AreEqual(20, list.Get());
            list.Next();
            Assert.AreEqual(30, list.Get());
        }

        [TestMethod]
        public void Enumerator_ShouldReturnAllInts()
        {
            var list = new ListClass<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var elements = list.ToList();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, elements);
        }
    }
}