class Solution {
public:
    int longestCommonSubsequence(string text1, string text2) {
        return dfs(text1, text2, 0, 0);
    }

private:
    int dfs(const string& text1, const string& text2, int i, int j) {
        if (i == text1.size() || j == text2.size()) {
            return 0;
        }
        if (text1[i] == text2[j]) {
            return 1 + dfs(text1, text2, i + 1, j + 1);
        }
        return max(dfs(text1, text2, i + 1, j),
                   dfs(text1, text2, i, j + 1));
    }
};