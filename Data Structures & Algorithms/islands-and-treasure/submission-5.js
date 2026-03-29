class Solution {
    /**
     * @param {number[][]} grid
     */
    islandsAndTreasure(grid) {
        let ROWS = grid.length;
        let COLS = grid[0].length;
        const directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
        const INF = 2147483647;
        let visit = Array.from({ length: ROWS }, () => 
                    Array(COLS).fill(false));

        const dfs = (r, c) => {
            if (r < 0 || c < 0 || r >= ROWS || 
                c >= COLS || grid[r][c] === -1 || visit[r][c]) {
                return INF;
            }
            if (grid[r][c] === 0) {
                return 0;
            }
            visit[r][c] = true;
            let res = INF;
            for (let [dx, dy] of directions) {
                res = Math.min(res, 1 + dfs(r + dx, c + dy));
            }
            visit[r][c] = false;
            return res;
        };

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                if (grid[r][c] === INF) {
                    grid[r][c] = dfs(r, c);
                }
            }
        }
    }
}