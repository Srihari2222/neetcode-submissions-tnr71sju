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
    static bool LeftCheck(int val, int limit) {
        return val < limit; 
    }

    static bool RightCheck(int val, int limit) {
        return val > limit; 
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }

        if (!IsValid(root.left, root.val, LeftCheck) || 
            !IsValid(root.right, root.val, RightCheck)) {
            return false;
        }

        return IsValidBST(root.left) && IsValidBST(root.right);
    }

    public bool IsValid(TreeNode root, int limit, Func<int, int, bool> check) {
        if (root == null) {
            return true;
        }
        if (!check(root.val, limit)) {
            return false;
        }
        return IsValid(root.left, limit, check) && 
               IsValid(root.right, limit, check);
    }
}