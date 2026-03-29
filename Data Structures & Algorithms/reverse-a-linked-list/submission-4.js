class Solution {
    /**
     * @param {ListNode} head
     * @return {ListNode}
     */
    reverseList(head) {
        if (!head) {
            return null;
        }

        let newHead = head;
        if (head.next) {
            newHead = this.reverseList(head.next);
            head.next.next = head;
        }
        head.next = null;

        return newHead;
    }
}