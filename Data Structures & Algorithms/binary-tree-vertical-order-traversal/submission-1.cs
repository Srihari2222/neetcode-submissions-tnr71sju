/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public List<List<int>> VerticalOrder(TreeNode root) {
        if (root == null) return new List<List<int>>();

        var cols = new SortedDictionary<int, List<int>>();
        var queue = new Queue<(TreeNode node, int pos)>();
        queue.Enqueue((root, 0));

        while (queue.Count > 0) {
            var (node, pos) = queue.Dequeue();

            if (!cols.ContainsKey(pos))
                cols[pos] = new List<int>();
            cols[pos].Add(node.val);

            if (node.left != null) queue.Enqueue((node.left, pos - 1));
            if (node.right != null) queue.Enqueue((node.right, pos + 1));
        }

        return cols.Values.ToList<List<int>>();
    }
}