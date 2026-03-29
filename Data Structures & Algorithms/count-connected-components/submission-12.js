class DSU {
    /**
     * @param {number} n
     */
    constructor(n) {
        this.parent = Array.from({ length: n + 1 }, (_, i) => i);
    }

    /**
     * @param {number} node
     * @return {number}
     */
    find(node) {
        if (this.parent[node] !== node) {
            this.parent[node] = this.find(this.parent[node]);
        }
        return this.parent[node];
    }

    /**
     * @param {number} u
     * @param {number} v
     * @return {boolean}
     */
    union(u, v) {
        const pu = this.find(u);
        const pv = this.find(v);
        if (pu === pv) {
            return false;
        }
        this.parent[pv] = pu;
        return true;
    }
}

class Solution {
    /**
     * @param {number} n
     * @param {number[][]} edges
     * @returns {number}
     */
    countComponents(n, edges) {
        const dsu = new DSU(n);
        let res = n;
        for (const [u, v] of edges) {
            if (dsu.union(u, v)) {
                res--;
            }
        }
        return res;
    }
}