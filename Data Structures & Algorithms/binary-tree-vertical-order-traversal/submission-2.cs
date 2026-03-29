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
    private SortedDictionary<int, List<(int, int)>> cols = new();

    public List<List<int>> VerticalOrder(TreeNode root) {
        DFS(root, 0, 0);

        List<List<int>> res = new();
        foreach (var entry in cols) {
            var list = entry.Value.OrderBy(x => x.Item1).Select(x => x.Item2).ToList();
            res.Add(list);
        }

        return res;
    }

    private void DFS(TreeNode node, int row, int col) {
        if (node == null) return;
        if (!cols.ContainsKey(col)) cols[col] = new List<(int, int)>();
        cols[col].Add((row, node.val));
        DFS(node.left, row + 1, col - 1);
        DFS(node.right, row + 1, col + 1);
    }
}