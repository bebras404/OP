using Xunit;
namespace Lab3.Tests
{
    public class ListClassTests
    {
        [Fact]
        public void TestAddAndGet()
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Start();
            list.Get();
            var value = list.Get();
            Assert.Equal(10, list.Get());
        }

        [Fact]
        public void TestNext()
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Add(12);
            list.Start();
            list.Next();
            var value = list.Get();
            Assert.Equal(12, value);

        }

        [Fact]
        public void TestExists() 
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Add(12);
            list.Start();
            list.Next();
            list.Next();
            Assert.False(list.Exists());
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenItemExists()
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            bool result = list.Contains(20);
            Assert.True(result);
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            bool result = list.Contains(40);
            Assert.False(result);
        }

        [Fact]
        public void Sort_ShouldSortItemsInAscendingOrder()
        {
            var list = new ListClass<int>();
            list.Add(30);
            list.Add(10);
            list.Add(20);
            list.Sort();
            list.Start();
            Assert.Equal(10, list.Get());
            list.Next();
            Assert.Equal(20, list.Get());
            list.Next();
            Assert.Equal(30, list.Get());
        }

        [Fact]
        public void Sort_ShouldNotChangeAlreadySortedList()
        {
            var list = new ListClass<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Sort();
            list.Start();
            Assert.Equal(10, list.Get());
            list.Next();
            Assert.Equal(20, list.Get());
            list.Next();
            Assert.Equal(30, list.Get());
        }

    }
}
