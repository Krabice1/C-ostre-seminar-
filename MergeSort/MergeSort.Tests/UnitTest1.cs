using Microsoft.VisualStudio.TestPlatform.TestHost;
using MergeSort;

namespace MergeSort.Tests
{
    public class UnitTest1
    {

        [Fact]  

        public void Merge_test1()         // Omlouvam se moc dlouhe :] 
        {

            int[] array = { -1, -3, 5, 2, 3, -6 };
            int[] expectedArray = { -6, -3, -1, 2, 3, 5 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest2
    {

        [Fact]    

        public void Merge_test2()         
        {

            int[] array = { 1, 3, 5, 2, 3, 6 };
            int[] expectedArray = { 1, 2, 3, 3, 5, 6 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            MergeSortClass.Merge(array, left, middle, right);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest3
    {

        [Fact]  

        public void Merge_test3()         
        {
            int[] array = { 21, 3, -5, 2, 13, 6 };
            int[] expectedArray = { -5, 2, 3, 6, 13, 21 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            MergeSortClass.Merge(array, left, middle, right);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest4
    {

        [Fact]  

        public void Merge_test4()         
        {
            int[] array = { 0, -3, 5, 2, 0, 6 };
            int[] expectedArray = { -3, 0, 0, 2, 5, 6 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            MergeSortClass.Merge(array, left, middle, right);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest5
    {

        [Fact]  
        public void Merge_test5()        
        {

            int[] array = { 56, 6, 34, 4, 35, 62 };
            int[] expectedArray = { 4, 6, 34, 35, 56, 62 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            MergeSortClass.Merge(array, left, middle, right);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest6
    {
        [Fact]
        public void Sort_Test1()
        {
            int[] array = { 56, 6, 34, 4, 35, 62 };
            int[] expectedArray = { 4, 6, 34, 35, 56, 62 };

            MergeSortClass.Sort(array);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest7
    {
        [Fact]
        public void Sort_Test2()
        {
            int[] array = { 1, 3, -5, 2, 13, 6 };
            int[] expectedArray = { -5, 1, 2, 3, 6, 13 };

            MergeSortClass.Sort(array);

            Assert.Equal(expectedArray, array);
        }
    }
    public class UnitTest98    {
        [Fact]
        public void Sort_Test3()
        {
            int[] array = { -1, -3, 5, 2, 3, -6 };
            int[] expectedArray = { -6, -3, -1, 2, 3, 5 };

            MergeSortClass.Sort(array);

            Assert.Equal(expectedArray, array);
        }
    }



}