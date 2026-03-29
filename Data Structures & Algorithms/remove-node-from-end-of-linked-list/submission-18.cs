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

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var nodes = new List<ListNode>();
        var cur = head;
        while (cur != null) {
            nodes.Add(cur);
            cur = cur.next;
        }

        int removeIndex = nodes.Count - n;
        if (removeIndex == 0) {
            return head.next;
        }

        nodes[removeIndex - 1].next = nodes[removeIndex].next;
        return head;
    }
}