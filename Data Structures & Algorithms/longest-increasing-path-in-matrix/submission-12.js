class Solution {
    /**
     * @param {number[][]} matrix
     * @return {number}
     */
    longestIncreasingPath(matrix) {
        const directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];
        const ROWS = matrix.length, COLS = matrix[0].length;

        const dfs = (r, c, prevVal) => {
            if (r < 0 || r >= ROWS || c < 0 || 
                c >= COLS || matrix[r][c] <= prevVal) {
                return 0;
            }

            let res = 1;
            for (let d of directions) {
                res = Math.max(res, 1 + dfs(r + d[0], 
                                        c + d[1], matrix[r][c]));
            }
            return res;
        };

        let LIP = 0;
        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                LIP = Math.max(LIP, dfs(r, c, -Infinity));
            }
        }
        return LIP;
    }
}