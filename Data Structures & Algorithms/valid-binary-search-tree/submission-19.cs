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
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }

        Queue<(TreeNode node, long left, long right)> queue = new Queue<(TreeNode, long, long)>();
        queue.Enqueue((root, long.MinValue, long.MaxValue));

        while (queue.Count > 0) {
            var (node, left, right) = queue.Dequeue();

            if (!(left < node.val && node.val < right)) {
                return false;
            }
            if (node.left != null) {
                queue.Enqueue((node.left, left, node.val));
            }
            if (node.right != null) {
                queue.Enqueue((node.right, node.val, right));
            }
        }

        return true;
    }
}