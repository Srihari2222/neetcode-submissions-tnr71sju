public class Solution {    
    public ListNode MergeKLists(ListNode[] lists) {
        List<int> nodes = new List<int>();
        foreach (ListNode lst in lists) {
            while (lst != null) {
                nodes.Add(lst.val);
                lst = lst.next;
            }
        }
        nodes.Sort();

        ListNode res = new ListNode(0);
        ListNode cur = res;
        foreach (int node in nodes) {
            cur.next = new ListNode(node);
            cur = cur.next;
        }
        return res.next;
    }
}