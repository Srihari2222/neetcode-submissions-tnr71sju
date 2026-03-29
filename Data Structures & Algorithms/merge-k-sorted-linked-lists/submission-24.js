/**
 * Definition for singly-linked list.
 * class ListNode {
 *     constructor(val = 0, next = null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

class Solution {
    /**
     * @param {ListNode[]} lists
     * @return {ListNode}
     */
    mergeKLists(lists) {
        if (lists.length === 0) return null;

        for (let i = 0; i < lists.length; i++) {
            lists[i] = this.mergeList(lists[i], lists[i - 1]);
        }
        return lists[lists.length - 1];
    }

    /**
     * @param {ListNode} l1
     * @param  {ListNode} l2
     * @return {ListNode}
     */
    mergeList(l1, l2) {
        const dummy = new ListNode();
        let tail = dummy;

        while (l1 && l2) {
            if (l1.val < l2.val) {
                tail.next = l1;
                l1 = l1.next;
            } else {
                tail.next = l2;
                l2 = l2.next;
            }
            tail = tail.next;
        }
        if (l1) {
            tail.next = l1;
        }
        if (l2) {
            tail.next = l2;
        }
        return dummy.next;
    }
}