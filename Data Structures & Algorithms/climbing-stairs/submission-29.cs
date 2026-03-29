public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1) return 1;

        int[,] M = new int[,] {{1, 1}, {1, 0}};
        int[,] result = MatrixPow(M, n);

        return result[0, 0];
    }

    private int[,] MatrixMult(int[,] A, int[,] B) {
        return new int[,] {
            {A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0],
             A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1]},
            {A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0],
             A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1]}
        };
    }

    private int[,] MatrixPow(int[,] M, int p) {
        int[,] result = new int[,] {{1, 0}, {0, 1}};  
        int[,] baseM = M;

        while (p > 0) {
            if (p % 2 == 1) {
                result = MatrixMult(result, baseM);
            }
            baseM = MatrixMult(baseM, baseM);
            p /= 2;
        }

        return result;
    }
}