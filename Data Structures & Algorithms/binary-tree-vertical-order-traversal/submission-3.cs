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

        Dictionary<int, List<int>> cols = new();
        Queue<(TreeNode node, int col)> queue = new();
        queue.Enqueue((root, 0));
        int minCol = 0, maxCol = 0;

        while (queue.Count > 0) {
            var (node, col) = queue.Dequeue();
            if (!cols.ContainsKey(col))
                cols[col] = new List<int>();
            cols[col].Add(node.val);
            minCol = Math.Min(minCol, col);
            maxCol = Math.Max(maxCol, col);

            if (node.left != null) queue.Enqueue((node.left, col - 1));
            if (node.right != null) queue.Enqueue((node.right, col + 1));
        }

        var res = new List<List<int>>();
        for (int c = minCol; c <= maxCol; c++) {
            res.Add(cols[c]);
        }

        return res;
    }
}