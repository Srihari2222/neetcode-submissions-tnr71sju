/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) return null;
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;
        while (cur != null) {
            if (!oldToCopy.ContainsKey(cur)) {
                oldToCopy[cur] = new Node(cur.val);
            } else {
                oldToCopy[cur].val = cur.val;
            }

            if (cur.next != null) {
                if (!oldToCopy.ContainsKey(cur.next)) {
                    oldToCopy[cur.next] = new Node(0);
                }
                oldToCopy[cur].next = oldToCopy[cur.next];
            } else {
                oldToCopy[cur].next = null;
            }

            if (cur.random != null) {
                if (!oldToCopy.ContainsKey(cur.random)) {
                    oldToCopy[cur.random] = new Node(0);
                }
                oldToCopy[cur].random = oldToCopy[cur.random];
            } else {
                oldToCopy[cur].random = null;
            }
            cur = cur.next;
        }
        return oldToCopy[head];
    }
}