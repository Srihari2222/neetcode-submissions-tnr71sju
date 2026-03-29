public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }

        ListNode newHead = head;
        if (head.next != null) {
            newHead = ReverseList(head.next);
            head.next.next = head;
        }
        head.next = null;

        return newHead;
    }
}