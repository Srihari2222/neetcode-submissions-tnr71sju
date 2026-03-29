class Solution {
public:
    int climbStairs(int n) {
        return dfs(n, 0);
    }

    int dfs(int n, int i) {
        if (i >= n) return i == n;
        return dfs(n, i + 1) + dfs(n, i + 2);
    }
};