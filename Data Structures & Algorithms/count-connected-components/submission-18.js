class DSU {
    /**
     * @param {number} n
     */
    constructor(n) {
        this.parent = Array.from({ length: n }, (_, i) => i);
        this.rank = Array(n).fill(1);
    }

    /**
     * @param {number} node
     * @return {number}
     */
    find(node) {
        let cur = node;
        while (cur !== this.parent[cur]) {
            this.parent[cur] = this.parent[this.parent[cur]];
            cur = this.parent[cur];
        }
        return cur;
    }

    /**
     * @param {number} u
     * @param {number} v
     * @return {boolean}
     */
    union(u, v) {
        let pu = this.find(u);
        let pv = this.find(v);
        if (pu === pv) {
            return false;
        }
        if (this.rank[pv] > this.rank[pu]) {
            [pu, pv] = [pv, pu];
        }
        this.parent[pv] = pu;
        this.rank[pu] += this.rank[pv];
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