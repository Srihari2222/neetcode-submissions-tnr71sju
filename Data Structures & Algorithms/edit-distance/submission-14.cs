public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        return Dfs(0, 0, word1, word2, m, n);
    }

    private int Dfs(int i, int j, string word1, string word2, int m, int n) {
        if (i == m) return n - j;
        if (j == n) return m - i;

        if (word1[i] == word2[j]) {
            return Dfs(i + 1, j + 1, word1, word2, m, n);
        }

        int res = Math.Min(Dfs(i + 1, j, word1, word2, m, n), 
                           Dfs(i, j + 1, word1, word2, m, n));
        res = Math.Min(res, Dfs(i + 1, j + 1, word1, word2, m, n));
        return res + 1;
    }
}