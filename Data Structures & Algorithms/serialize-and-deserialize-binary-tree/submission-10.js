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

class Codec {
    /**
     * Encodes a tree to a single string.
     *
     * @param {TreeNode} root
     * @return {string}
     */
    serialize(root) {
        if (!root) return "N";
        const res = [];
        const queue = new Queue();
        queue.push(root);

        while (!queue.isEmpty()) {
            const node = queue.pop();
            if (!node) {
                res.push("N");
            } else {
                res.push(node.val);
                queue.push(node.left);
                queue.push(node.right);
            }
        }
        return res.join(",");
    }

    /**
     * Decodes your encoded data to tree.
     *
     * @param {string} data
     * @return {TreeNode}
     */
    deserialize(data) {
        const vals = data.split(",");
        if (vals[0] === "N") return null;
        const root = new TreeNode(parseInt(vals[0]));
        const queue = new Queue([root]);
        let index = 1;

        while (!queue.isEmpty()) {
            const node = queue.pop();
            if (vals[index] !== "N") {
                node.left = new TreeNode(parseInt(vals[index]));
                queue.push(node.left);
            }
            index++;
            if (vals[index] !== "N") {
                node.right = new TreeNode(parseInt(vals[index]));
                queue.push(node.right);
            }
            index++;
        }
        return root;
    }
}