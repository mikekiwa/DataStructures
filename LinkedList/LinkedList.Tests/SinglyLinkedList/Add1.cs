using SinglyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestClass]
    public class Add1
    {
        [TestMethod]
        public void AddRawValueSuccessCases()
        {
            int[] testCase = new int[] { 0, 1, 2, 3 };
            
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.Add(value);
            }

            Assert.AreEqual(testCase.Length, list.Count,
                "There are an unexpected number of list items");

            Assert.AreEqual(testCase[testCase.Length - 1], list.Head.Value,
                "The first item value is not correct");

            Assert.AreEqual(testCase[0], list.Tail.Value,
                "The last item value is not correct");
            
            int current = testCase.Length - 1;

            foreach (int v in list)
            {
                Assert.AreEqual(testCase[current], v,
                    "The list at index {0} is not correct", current);
                current--;
            }
        }
    }
}
