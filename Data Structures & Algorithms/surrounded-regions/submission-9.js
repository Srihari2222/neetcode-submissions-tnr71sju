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

    /**
     * @param {number} u
     * @param {number} v
     * @return {boolean}
     */
    connected(u, v) {
        return this.find(u) === this.find(v);
    }
}

class Solution {
    /**
     * @param {character[][]} board
     * @return {void} Do not return anything, modify board in-place instead.
     */
    solve(board) {
        const ROWS = board.length, COLS = board[0].length;
        const dsu = new DSU(ROWS * COLS + 1);
        const directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                if (board[r][c] !== 'O') continue;
                if (r === 0 || c === 0 || 
                    r === ROWS - 1 || c === COLS - 1) {
                    dsu.union(ROWS * COLS, r * COLS + c);
                } else {
                    for (let [dx, dy] of directions) {
                        const nr = r + dx, nc = c + dy;
                        if (board[nr][nc] === 'O') {
                            dsu.union(r * COLS + c, nr * COLS + nc);
                        }
                    }
                }
            }
        }

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                if (!dsu.connected(ROWS * COLS, r * COLS + c)) {
                    board[r][c] = 'X';
                }
            }
        }
    }
}