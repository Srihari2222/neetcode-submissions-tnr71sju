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
     * @return {number}
     */
    goodNodes(root) {
        let res = 0;
        let q = new Queue();
        q.push([root, -Infinity]);

        while (!q.isEmpty()) {
            let [node, maxval] = q.pop();
            if (node.val >= maxval) {
                res++;
            }
            if (node.left) {
                q.push([node.left, Math.max(maxval, node.val)]);
            }
            if (node.right) {
                q.push([node.right, Math.max(maxval, node.val)]);
            }
        }
        return res;
    }
}