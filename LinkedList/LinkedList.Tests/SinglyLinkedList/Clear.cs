using NUnit.Framework;
using SinglyLinkedList;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void ClearEmpty()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        [Test, TestCaseSource("ClearSuccessCases")]
        public void ClearVariousItems(int[] testCase)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            foreach (int value in testCase)
            {
                list.AddLast(new Node<int>(value));
            }

            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);
            Assert.AreEqual(testCase.Length, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        static object[] ClearSuccessCases =
        {
            new int[] { 0 },
            new int[] { 0, 1 },
            new int[] { 0, 1, 2 },
            new int[] { 0, 1, 2, 3 },
        };
    }
}
