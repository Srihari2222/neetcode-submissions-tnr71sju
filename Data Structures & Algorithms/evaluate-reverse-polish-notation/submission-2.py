class DoublyLinkedList:
    def __init__(self, val, next=None, prev=None):
        self.val = val
        self.next = next
        self.prev = prev


class Solution:
    def evalRPN(self, tokens: List[str]) -> int:
        head = DoublyLinkedList(tokens[0])
        curr = head

        for i in range(1, len(tokens)):
            curr.next = DoublyLinkedList(tokens[i], prev=curr)
            curr = curr.next

        op = {'+', '-', '*', '/'}
        while head is not None:
            if head.val in op:
                l = int(head.prev.prev.val)
                r = int(head.prev.val)
                if head.val == '+':
                    res = l + r
                elif head.val == '-':
                    res = l - r
                elif head.val == '*':
                    res = l * r
                else:
                    res = abs(l) // abs(r)
                    if l * r < 0:
                        res = -res

                head.val = str(res)
                head.prev = head.prev.prev.prev
                if head.prev is not None:
                    head.prev.next = head

            tmp = head
            while tmp.prev is not None:
                tmp = tmp.prev

            ans = int(head.val)
            head = head.next

        return ans
