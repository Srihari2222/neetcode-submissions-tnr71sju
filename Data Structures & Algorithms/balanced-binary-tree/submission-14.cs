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
    
    public bool IsBalanced(TreeNode root) {
        return Dfs(root)[0] == 1;
    }

    private int[] Dfs(TreeNode root) {
        if (root == null) {
            return new int[]{1, 0};
        }

        int[] left = Dfs(root.left);
        int[] right = Dfs(root.right);

        bool balanced = (left[0] == 1 && right[0] == 1) &&
                        (Math.Abs(left[1] - right[1]) <= 1);
        int height = 1 + Math.Max(left[1], right[1]);

        return new int[]{balanced ? 1 : 0, height};
    }
}