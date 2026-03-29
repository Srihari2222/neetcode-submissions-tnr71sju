class Solution {
public:
    int numDistinct(string s, string t) {
        int m = s.size(), n = t.size();
        if (n > m) return 0;
        vector<vector<int>> dp(m + 1, vector<int>(n + 1, -1));
        return dfs(s, t, 0, 0, dp);
    }

private:
    int dfs(const string &s, const string &t, int i, int j, vector<vector<int>> &dp) {
        if (j == t.size()) return 1;
        if (i == s.size()) return 0;
        if (dp[i][j] != -1) return dp[i][j];

        int res = dfs(s, t, i + 1, j, dp);
        if (s[i] == t[j]) {
            res += dfs(s, t, i + 1, j + 1, dp);
        }
        dp[i][j] = res;
        return res;
    }
};