class Solution {
public:
    int swimInWater(vector<vector<int>>& grid) {
        int n = grid.size();
        vector<vector<bool>> visit(n, vector<bool>(n, false));
        return dfs(grid, visit, 0, 0, 0);
    }

private:
    int dfs(vector<vector<int>>& grid, vector<vector<bool>>& visit, 
            int r, int c, int t) {
        int n = grid.size();
        if (r < 0 || c < 0 || r >= n || c >= n || visit[r][c]) {
            return 1000000;
        }
        if (r == n - 1 && c == n - 1) {
            return max(t, grid[r][c]);
        }
        visit[r][c] = true;
        t = max(t, grid[r][c]);
        int res = min(min(dfs(grid, visit, r + 1, c, t),
                                     dfs(grid, visit, r - 1, c, t)),
                           min(dfs(grid, visit, r, c + 1, t),
                                    dfs(grid, visit, r, c - 1, t)));
        visit[r][c] = false;
        return res;
    }
};