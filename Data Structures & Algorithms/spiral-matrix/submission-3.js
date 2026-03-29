class Solution {
    /**
     * @param {number[][]} matrix
     * @return {number[]}
     */
    spiralOrder(matrix) {
        const m = matrix.length, n = matrix[0].length;
        const res = [];

        // append all the elements in the given direction
        const dfs = (row, col, r, c, dr, dc) => {
            if (row === 0 || col === 0) return;

            for (let i = 0; i < col; i++) {
                r += dr;
                c += dc;
                res.push(matrix[r][c]);
            }

            // sub-problem
            dfs(col, row - 1, r, c, dc, -dr);
        };

        // start by going to the right
        dfs(m, n, 0, -1, 0, 1);
        return res;
    }
}