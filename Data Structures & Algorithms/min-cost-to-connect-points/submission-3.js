class DSU {
    constructor(n) {
        this.Parent = Array.from({ length: n + 1 }, (_, i) => i);
        this.Size = Array(n + 1).fill(1);
    }

    /**
     * @param {number} node
     * @return {number}
     */
    find(node) {
        if (this.Parent[node] !== node) {
            this.Parent[node] = this.find(this.Parent[node]);
        }
        return this.Parent[node];
    }

    /**
     * @param {number} u
     * @param {number} v
     * @return {boolean}
     */
    union(u, v) {
        let pu = this.find(u), pv = this.find(v);
        if (pu === pv) return false;
        if (this.Size[pu] < this.Size[pv]) [pu, pv] = [pv, pu];
        this.Size[pu] += this.Size[pv];
        this.Parent[pv] = pu;
        return true;
    }
}

class Solution {
    /**
     * @param {number[][]} points
     * @return {number}
     */
    minCostConnectPoints(points) {
        const n = points.length;
        const dsu = new DSU(n);
        const edges = [];

        for (let i = 0; i < n; i++) {
            for (let j = i + 1; j < n; j++) {
                const dist = Math.abs(points[i][0] - points[j][0]) + 
                             Math.abs(points[i][1] - points[j][1]);
                edges.push([dist, i, j]);
            }
        }

        edges.sort((a, b) => a[0] - b[0]);
        let res = 0;

        for (const [dist, u, v] of edges) {
            if (dsu.union(u, v)) {
                res += dist;
            }
        }
        return res;
    }
}