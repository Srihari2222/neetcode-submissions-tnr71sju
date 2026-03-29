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
    private Dictionary<int, List<(int, int)>> cols = new();
    private int minCol = 0, maxCol = 0;

    public List<List<int>> VerticalOrder(TreeNode root) {
        if (root == null) return new List<List<int>>();
        DFS(root, 0, 0);
        var res = new List<List<int>>();

        for (int c = minCol; c <= maxCol; c++) {
            var list = cols.ContainsKey(c) ? cols[c] : new List<(int, int)>();
            list.Sort((a, b) => a.Item1.CompareTo(b.Item1)); // sort by row
            res.Add(list.Select(p => p.Item2).ToList());
        }

        return res;
    }

    private void DFS(TreeNode node, int row, int col) {
        if (node == null) return;
        if (!cols.ContainsKey(col)) cols[col] = new List<(int, int)>();
        cols[col].Add((row, node.val));
        minCol = Math.Min(minCol, col);
        maxCol = Math.Max(maxCol, col);
        DFS(node.left, row + 1, col - 1);
        DFS(node.right, row + 1, col + 1);
    }
}