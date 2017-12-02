using System.Linq;
using NUnit.Framework;
using SinglyLinkedList;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestFixture]
    public class Add
    {
        [Test, TestCaseSource("AddSuccessCases")]
        public void AddRawValueSuccessCases(int[] testCase)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.Add(value);
            }

            Assert.AreEqual(testCase.Length, list.Count, 
                "There are an unexpected number of list items");

            Assert.AreEqual(testCase.Last(), list.Head.Value,
                "The first item value is not correct");

            Assert.AreEqual(testCase.First(), list.Tail.Value,
                "The last item value is not correct");

            int[] reversed = testCase.Reverse().ToArray();
            int current = 0;

            foreach (int v in list)
            {
                Assert.AreEqual(reversed[current], v,
                    "The list at index {0} is not correct", current);
                current++;
            }
        }

        [Test, TestCaseSource("AddSuccessCases")]
        public void AddFirstNodeValueSuccessCases(int[] testCase)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddFirst(new Node<int>(value));
            }

            Assert.AreEqual(testCase.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(testCase.Last(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(testCase.First(), list.Tail.Value,
                "The last item value was incorrect");

            int[] reversed = testCase.Reverse().ToArray();
            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, 
                    "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [Test, TestCaseSource("AddSuccessCases")]
        public void AddLastRawValueSuccessCases(int[] testCase)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(value);
            }

            Assert.AreEqual(testCase.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(testCase.First(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(testCase.Last(), list.Tail.Value,
                "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(testCase[current], value, 
                    "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [Test, TestCaseSource("AddSuccessCases")]
        public void AddLastNodeValueSuccessCases(int[] testCase)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(new Node<int>(value));
            }

            Assert.AreEqual(testCase.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(testCase.First(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(testCase.Last(), list.Tail.Value,
                "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(testCase[current], value, 
                    "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        static object[] AddSuccessCases =
        {
            new int[] { 0 },
            new int[] { 0, 1 },
            new int[] { 0, 1, 2 },
            new int[] { 0, 1, 2, 3 },
        };
    }
}
