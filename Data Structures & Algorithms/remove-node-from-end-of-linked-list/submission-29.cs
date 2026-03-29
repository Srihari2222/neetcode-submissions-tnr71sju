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
    public ListNode rec(ListNode head, ref int n) {
        if (head == null) {
            return null;
        }

        head.next = rec(head.next, ref n);
        n--;
        if (n == 0) {
            return head.next;
        }
        return head;
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        return rec(head, ref n);
    }
}