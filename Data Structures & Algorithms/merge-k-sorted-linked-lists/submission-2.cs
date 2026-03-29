/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class NodeWrapper : IComparable<NodeWrapper> {
    public ListNode node;

    public NodeWrapper(ListNode node) {
        this.node = node;
    }

    public int CompareTo(NodeWrapper other) {
        return this.node.val.CompareTo(other.node.val);
    }
}

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) {
            return null;
        }

        ListNode res = new ListNode(0);
        ListNode cur = res;
        PriorityQueue<NodeWrapper, int> minHeap = new PriorityQueue<NodeWrapper, int>();

        foreach (ListNode lst in lists) {
            if (lst != null) {
                minHeap.Enqueue(new NodeWrapper(lst), lst.val);
            }
        }

        while (minHeap.Count > 0) {
            NodeWrapper nodeWrapper = minHeap.Dequeue();
            cur.next = nodeWrapper.node;
            cur = cur.next;

            if (nodeWrapper.node.next != null) {
                minHeap.Enqueue(new NodeWrapper(nodeWrapper.node.next), nodeWrapper.node.next.val);
            }
        }

        return res.next;
    }
}