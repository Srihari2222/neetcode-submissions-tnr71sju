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
        let curr = root;
    
        while (curr) {
            if (!curr.left) {
                k--;
                if (k === 0) return curr.val;
                curr = curr.right;
            } else {
                let pred = curr.left;
                while (pred.right && pred.right !== curr) 
                    pred = pred.right;
                
                if (!pred.right) {
                    pred.right = curr;
                    curr = curr.left;
                } else {
                    pred.right = null;
                    k--;
                    if (k === 0) return curr.val;
                    curr = curr.right;
                }
            }
        }
        return -1;
    }
}