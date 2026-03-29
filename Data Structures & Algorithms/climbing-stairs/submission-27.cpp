class Solution {
public:
    int climbStairs(int n) {
        if (n == 1) return 1;
        
        vector<vector<int>> M = {{1, 1}, {1, 0}};
        vector<vector<int>> result = matrixPow(M, n);

        return result[0][0];
    }
    
private:
    vector<vector<int>> matrixMult(vector<vector<int>>& A, vector<vector<int>>& B) {
        return {{A[0][0] * B[0][0] + A[0][1] * B[1][0],
                 A[0][0] * B[0][1] + A[0][1] * B[1][1]},
                {A[1][0] * B[0][0] + A[1][1] * B[1][0],
                 A[1][0] * B[0][1] + A[1][1] * B[1][1]}};
    }

    vector<vector<int>> matrixPow(vector<vector<int>>& M, int p) {
        vector<vector<int>> result = {{1, 0}, {0, 1}};  
        vector<vector<int>> base = M;

        while (p > 0) {
            if (p % 2 == 1) {
                result = matrixMult(result, base);
            }
            base = matrixMult(base, base);
            p /= 2;
        }

        return result;
    }
};