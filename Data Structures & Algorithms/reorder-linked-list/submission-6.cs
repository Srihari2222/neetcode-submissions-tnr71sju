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
    public void ReorderList(ListNode head) {
        if (head == null) return;

        List<ListNode> nodes = new List<ListNode>();
        ListNode cur = head;
        while (cur != null) {
            nodes.Add(cur);
            cur = cur.next;
        }

        int i = 0, j = nodes.Count - 1;
        while (i < j) {
            nodes[i].next = nodes[j];
            i++;
            if (i >= j) break;
            nodes[j].next = nodes[i];
            j--;
        }

        nodes[i].next = null;
    }
}