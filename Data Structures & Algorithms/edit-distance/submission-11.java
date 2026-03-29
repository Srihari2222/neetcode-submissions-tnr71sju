public class Solution {
    public int minDistance(String word1, String word2) {
        int m = word1.length(), n = word2.length();

        return dfs(0, 0, word1, word2, m, n);
    }

    private int dfs(int i, int j, String word1, String word2, int m, int n) {
        if (i == m) return n - j;
        if (j == n) return m - i;

        if (word1.charAt(i) == word2.charAt(j)) {
            return dfs(i + 1, j + 1, word1, word2, m, n);
        }

        int res = Math.min(dfs(i + 1, j, word1, word2, m, n), 
                           dfs(i, j + 1, word1, word2, m, n));
        res = Math.min(res, dfs(i + 1, j + 1, word1, word2, m, n));
        return res + 1;
    }
}