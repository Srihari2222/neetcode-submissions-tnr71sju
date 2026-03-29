/**
 * // Definition for a Node.
 * class Node {
 *     constructor(val = 0, neighbors = []) {
 *       this.val = val;
 *       this.neighbors = neighbors;
 *     }
 * }
 */

class Solution {
    /**
     * @param {Node} node
     * @return {Node}
     */
    cloneGraph(node) {
        if (!node) return null;
        const oldToNew = new Map();
        const q = new Queue();
        oldToNew.set(node, new Node(node.val));
        q.push(node);

        while (!q.isEmpty()) {
            const cur = q.pop();
            for (const nei of cur.neighbors) {
                if (!oldToNew.has(nei)) {
                    oldToNew.set(nei, new Node(nei.val));
                    q.push(nei);
                }
                oldToNew.get(cur).neighbors.push(oldToNew.get(nei));
            }
        }
        return oldToNew.get(node);
    }
}