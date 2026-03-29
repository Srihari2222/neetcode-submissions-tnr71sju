class Solution {
    /**
     * @param {number[][]} matrix
     * @return {void}
     */
    setZeroes(matrix) {
        const ROWS = matrix.length, COLS = matrix[0].length;
        const mark = matrix.map(row => [...row]);

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                if (matrix[r][c] === 0) {
                    for (let col = 0; col < COLS; col++) {
                        mark[r][col] = 0;
                    }
                    for (let row = 0; row < ROWS; row++) {
                        mark[row][c] = 0;
                    }
                }
            }
        }

        for (let r = 0; r < ROWS; r++) {
            for (let c = 0; c < COLS; c++) {
                matrix[r][c] = mark[r][c];
            }
        }
    }
}