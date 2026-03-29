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
     * @param {number} val
     * @param {number} limit
     * @returns {boolean}
     */
    left_check(val, limit) {
        return val < limit;
    }

    /**
     * @param {number} val
     * @param {number} limit
     * @returns {boolean}
     */
    right_check(val, limit) {
        return val > limit;
    }

    /**
     * @param {TreeNode} root
     * @returns {boolean}
     */
    isValidBST(root) {
        if (!root) {
            return true;
        }

        if (!this.isValid(root.left, root.val, this.left_check) ||
            !this.isValid(root.right, root.val, this.right_check)) {
            return false;
        }

        return this.isValidBST(root.left) && this.isValidBST(root.right);
    }

    /**
     * @param {TreeNode} root
     * @param {number} limit
     * @param {function} check
     * @returns {boolean}
     */
    isValid(root, limit, check) {
        if (!root) {
            return true;
        }
        if (!check.call(this, root.val, limit)) {
            return false;
        }
        return this.isValid(root.left, limit, check) &&
               this.isValid(root.right, limit, check);
    }
}