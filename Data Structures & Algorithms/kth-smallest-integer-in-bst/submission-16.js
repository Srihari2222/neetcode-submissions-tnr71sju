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
        const tmp = new Int32Array(2);
        tmp[0] = k;
        this.dfs(root, tmp);
        return tmp[1];
    }

    /**
     * @param {TreeNode} node
     * @param {number[]} tmp
     */
    dfs(node, tmp) {
        if (!node) return;
        this.dfs(node.left, tmp);
        tmp[0]--;
        if (tmp[0] === 0) {
            tmp[1] = node.val;
            return;
        }
        this.dfs(node.right, tmp);
    }
}