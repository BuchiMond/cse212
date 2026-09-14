using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities (A:1, B:2, C:3), then dequeue
    // all three.
    // Expected Result: Items should come out in priority order regardless of insertion order:
    // C (highest), then B, then A.
    // Defect(s) Found: FAILED. Dequeue returned "B" first instead of "C". The for-loop in Dequeue
    // uses "index < _queue.Count - 1", which skips checking the very last item in the queue, so
    // the true highest-priority item (at the last index) was never considered. Additionally, the
    // dequeued item was never removed from the internal list, so the queue never actually shrank.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items that all share the same priority (first, second, third all
    // priority 5), then dequeue them.
    // Expected Result: Since all priorities are tied, items should come out in FIFO order: first,
    // then second, then third.
    // Defect(s) Found: FAILED. Dequeue returned "second" first instead of "first". The comparison
    // "_queue[index].Priority >= _queue[highPriorityIndex].Priority" uses >= instead of >, so a
    // later item with an equal priority incorrectly overwrites the earlier tied item, breaking the
    // required FIFO tie-break rule.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 5);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Try to dequeue from a brand-new, empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: PASSED. No defects found - the exception is thrown correctly with the
    // expected message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}