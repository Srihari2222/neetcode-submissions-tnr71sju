class DSU {
    constructor(n) {
        this.Parent = Array(n + 1).fill(0).map((_, i) => i);
        this.Size = Array(n + 1).fill(1);
    }

    find(node) {
        if (this.Parent[node] !== node) {
            this.Parent[node] = this.find(this.Parent[node]);
        }
        return this.Parent[node];
    }

    union(u, v) {
        let pu = this.find(u);
        let pv = this.find(v);
        if (pu === pv) return false;
        if (this.Size[pu] >= this.Size[pv]) {
            this.Size[pu] += this.Size[pv];
            this.Parent[pv] = pu;
        } else {
            this.Size[pv] += this.Size[pu];
            this.Parent[pu] = pv;
        }
        return true;
    }
}

class Solution {
    /**
     * @param {character[][]} grid
     * @return {number}
     */
    numIslands(grid) {
        const ROWS = grid.length;
        const COLS = grid[0].length;
        const dsu = new DSU(ROWS * COLS);

        const directions = [
            [1, 0], [-1, 0], [0, 1], [0, -1]
        ];

        let islands = 0;

        const index = (r, c) => r * COLS + c;

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                if (grid[r][c] === '1') {
                    islands++;
                    for (let [dr, dc] of directions) {
                        let nr = r + dr, nc = c + dc;
                        if (nr >= 0 && nc >= 0 && nr < ROWS && 
                            nc < COLS && grid[nr][nc] === '1') {
                            if (dsu.union(index(r, c), index(nr, nc))) {
                                islands--;
                            }
                        }
                    }
                }
            }
        }

        return islands;
    }
}