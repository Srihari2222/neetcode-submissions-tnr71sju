// class Node {
//   constructor(val, next = null, random = null) {
//       this.val = val;
//       this.next = next;
//       this.random = random;
//   }
// }

class Solution {
    /**
     * @param {Node} head
     * @return {Node}
     */
    copyRandomList(head) {
        if (head === null) {
            return null;
        }

        let l1 = head;
        while (l1 !== null) {
            let l2 = new Node(l1.val);
            l2.next = l1.next;
            l1.next = l2;
            l1 = l2.next;
        }

        let newHead = head.next;

        l1 = head;
        while (l1 !== null) {
            if (l1.random !== null) {
                l1.next.random = l1.random.next;
            }
            l1 = l1.next.next;
        }

        l1 = head;
        while (l1 !== null) {
            let l2 = l1.next;
            l1.next = l2.next;
            if (l2.next !== null) {
                l2.next = l2.next.next;
            }
            l1 = l1.next;
        }

        return newHead;
    }
}