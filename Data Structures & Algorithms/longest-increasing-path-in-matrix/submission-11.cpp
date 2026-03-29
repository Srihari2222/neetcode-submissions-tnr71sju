class Solution {
public:
    vector<vector<int>> directions = {{-1, 0}, {1, 0}, 
                                      {0, -1}, {0, 1}};
    
    int dfs(vector<vector<int>>& matrix, int r, int c, int prevVal) {
        int ROWS = matrix.size(), COLS = matrix[0].size();
        if (r < 0 || r >= ROWS || c < 0 || 
            c >= COLS || matrix[r][c] <= prevVal)
            return 0;
        
        int res = 1;
        for (auto d : directions)
            res = max(res, 1 + dfs(matrix, r + d[0], 
                                   c + d[1], matrix[r][c]));
        return res;
    }

    int longestIncreasingPath(vector<vector<int>>& matrix) {
        int ROWS = matrix.size(), COLS = matrix[0].size(), LIP = 0;
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                LIP = max(LIP, dfs(matrix, r, c, INT_MIN));
            }
        }
        return LIP;
    }
};