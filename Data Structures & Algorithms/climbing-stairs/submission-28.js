class Solution {
    /**
     * @param {number} n
     * @return {number}
     */
    climbStairs(n) {
        if (n === 1) return 1;

        const matrixMult = (A, B) => {
            return [
                [A[0][0] * B[0][0] + A[0][1] * B[1][0],
                 A[0][0] * B[0][1] + A[0][1] * B[1][1]],
                [A[1][0] * B[0][0] + A[1][1] * B[1][0],
                 A[1][0] * B[0][1] + A[1][1] * B[1][1]]
            ];
        };

        const matrixPow = (M, p) => {
            let result = [[1, 0], [0, 1]];  
            let base = M;

            while (p > 0) {
                if (p % 2 === 1) {
                    result = matrixMult(result, base);
                }
                base = matrixMult(base, base);
                p = Math.floor(p / 2);
            }

            return result;
        };

        const M = [[1, 1], [1, 0]];
        const result = matrixPow(M, n);

        return result[0][0];
    }
}