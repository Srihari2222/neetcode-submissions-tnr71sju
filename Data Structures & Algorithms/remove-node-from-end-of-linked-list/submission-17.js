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
     * @param {number} n
     * @return {ListNode}
     */
    removeNthFromEnd(head, n) {
        const nodes = [];
        let cur = head;
        while (cur) {
            nodes.push(cur);
            cur = cur.next;
        }

        const removeIndex = nodes.length - n;
        if (removeIndex === 0) {
            return head.next;
        }

        nodes[removeIndex - 1].next = nodes[removeIndex].next;
        return head;
    }
}