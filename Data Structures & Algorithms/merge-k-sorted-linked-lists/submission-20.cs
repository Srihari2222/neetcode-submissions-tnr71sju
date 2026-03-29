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
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode res = new ListNode(0);
        ListNode cur = res;

        while (true) {
            int minNode = -1;
            for (int i = 0; i < lists.Length; i++) {
                if (lists[i] == null) continue;
                if (minNode == -1 || lists[minNode].val > lists[i].val) {
                    minNode = i;
                }
            }

            if (minNode == -1) break;
            cur.next = lists[minNode];
            lists[minNode] = lists[minNode].next;
            cur = cur.next;
        }
        return res.next;
    }
}