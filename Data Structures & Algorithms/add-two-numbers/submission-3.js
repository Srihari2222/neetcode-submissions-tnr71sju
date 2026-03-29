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
     * @param {ListNode} l1
     * @param {ListNode} l2
     * @param {number} carry
     * @return {ListNode}
     */
    add(l1, l2, carry) {
        if (!l1 && !l2 && carry === 0) {
            return null;
        }
        
        let v1 = 0;
        let v2 = 0;
        if (l1) {
            v1 = l1.val;
        }
        if (l2) {
            v2 = l2.val;
        }
        
        let sum = v1 + v2 + carry;
        let newCarry = Math.floor(sum / 10);
        let nodeValue = sum % 10;

        let nextNode = this.add(
            (l1 ? l1.next : null), 
            (l2 ? l2.next : null), 
            newCarry
        );

        return new ListNode(nodeValue, nextNode);
    }

    /**
     * @param {ListNode} l1
     * @param {ListNode} l2
     * @return {ListNode}
     */
    addTwoNumbers(l1, l2) {
        return this.add(l1, l2, 0);
    }
}