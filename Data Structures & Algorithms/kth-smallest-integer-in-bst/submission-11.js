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
     * @param {TreeNode} root
     * @param {number} k
     * @return {number}
     */
    kthSmallest(root, k) {
        const arr = [];
        this.dfs(root, arr);
        return arr[k - 1];
    }

    /**
     * @param {TreeNode} node
     * @param {number[]} arr
     */
    dfs(node, arr) {
        if (!node) return;
        this.dfs(node.left, arr);
        arr.push(node.val);
        this.dfs(node.right, arr);
    }
}