using CaseSmartDoc.List;

namespace CaseSmartDoc.Tests
{
    public class RecentlyUsedListTests
    {
        [Fact]
        public void InvalidListLengthError()
        {
            //Assert
            //Sjekker om en error vil bli kalt på en ugyldig listelengde
            Assert.Throws<ArgumentOutOfRangeException>(() => new RecentlyUsedList(0));
        }

        [Fact]
        public void AddEmptyResourceString()
        {    
            //Arrange
            //Lager en testliste
            RecentlyUsedList testList = new RecentlyUsedList(1);

            //Assert
            Assert.Throws<ArgumentException>(() => testList.AddItemToList(""));
        }

        [Fact]
        public void AddNullResourceString()
        {
            //Arrange
            //Lager en testliste
            RecentlyUsedList testList = new RecentlyUsedList(1);

            //Assert
            //Sjekker om det kalles på en error om den nye ressursen er null.
            Assert.Throws<ArgumentException>(() => testList.AddItemToList(null));
        }

        [Fact]
        public void AddItemToNewList()
        {
            //Arrange
            RecentlyUsedList testList = new RecentlyUsedList(10);

            //Act
            testList.AddItemToList("testStreng.com");

            //Assert
            Assert.Equal(new[] { "testStreng.com" }, testList.Items.ToArray());
        }

        [Fact]
        public void AddItemToFullList()
        {
            //Arrange
            RecentlyUsedList testList = new RecentlyUsedList(1);

            //Act
            testList.AddItemToList("testStreng.com");
            testList.AddItemToList("endaEnTestStreng.com");

            //Assert
            Assert.Equal(new[] {"endaEnTestStreng.com"}, testList.Items.ToArray());
        }

        [Fact]
        public void AddDuplicateItem()
        {
            //Arrange
            RecentlyUsedList testList = new RecentlyUsedList(1);

            //Act
            testList.AddItemToList("testStreng.com");
            testList.AddItemToList("testStreng.com");

            //Assert
            Assert.Equal(new[] {"testStreng.com"}, testList.Items.ToArray());
        }

        [Fact]
        public void NewItemAddedFirstToList()
        {
            //Arrange
            RecentlyUsedList testList = new RecentlyUsedList(2);

            //Act
            testList.AddItemToList("test.com");
            testList.AddItemToList("case.com");

            //Assert
            Assert.Equal(new[] {"case.com", "test.com"}  , testList.Items.ToArray());
        }
    }
}