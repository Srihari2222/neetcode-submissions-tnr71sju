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
     * @param {ListNode} head
     * @param {number[]} n
     * @return {ListNode}
     */
    rec(head, n) {
        if (!head) {
            return null;
        }

        head.next = this.rec(head.next, n);
        n[0]--;
        if (n[0] === 0) {
            return head.next;
        }
        return head;
    }

    /**
     * @param {ListNode} head
     * @param {number} n
     * @return {ListNode}
     */
    removeNthFromEnd(head, n) {
        return this.rec(head, [n]);
    }
}