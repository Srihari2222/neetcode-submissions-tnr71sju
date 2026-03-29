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
        Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

        Node cur = head;
        while (cur != null) {
            Node copy = new Node(cur.val);
            oldToCopy[cur] = copy;
            cur = cur.next;
        }

        cur = head;
        while (cur != null) {
            Node copy = oldToCopy[cur];
            copy.next = cur.next != null ? oldToCopy[cur.next] : null;
            copy.random = cur.random != null ? oldToCopy[cur.random] : null;
            cur = cur.next;
        }

        return head != null ? oldToCopy[head] : null;
    }
}