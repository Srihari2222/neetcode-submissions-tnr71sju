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

    /**
     * @param {number} n
     * @param {number} n
     * @return {boolean}
     */
    connected(u, v) {
        return this.find(u) == this.find(v);
    }
}

class Solution {
    /**
     * @param {number[][]} grid
     * @return {number}
     */
    swimInWater(grid) {
        const N = grid.length;
        const dsu = new DSU(N * N);
        const positions = [];
        for (let r = 0; r < N; r++) {
            for (let c = 0; c < N; c++) {
                positions.push([grid[r][c], r, c]);
            }
        }
        positions.sort((a, b) => a[0] - b[0]);
        const directions = [
            [0, 1], [1, 0], [0, -1], [-1, 0]
        ];

        for (const [t, r, c] of positions) {
            for (const [dr, dc] of directions) {
                const nr = r + dr, nc = c + dc;
                if (nr >= 0 && nr < N && nc >= 0 && 
                    nc < N && grid[nr][nc] <= t) {
                    dsu.union(r * N + c, nr * N + nc);
                }
            }
            if (dsu.connected(0, N * N - 1)) return t;
        }
        return -1;
    }
}