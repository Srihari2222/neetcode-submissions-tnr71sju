/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     constructor(val = 0, left = null, right = null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

class Solution {
    /**
     * @param {number[]} preorder
     * @param {number[]} inorder
     * @return {TreeNode}
     */
    buildTree(preorder, inorder) {
        let preIdx = 0, inIdx = 0;
    
        function dfs(limit) {
            if (preIdx >= preorder.length) return null;
            if (inorder[inIdx] === limit) {
                inIdx++;
                return null;
            }
            
            let root = new TreeNode(preorder[preIdx++]);
            root.left = dfs(root.val);
            root.right = dfs(limit);
            return root;
        }
        
        return dfs(Infinity);
    }
}