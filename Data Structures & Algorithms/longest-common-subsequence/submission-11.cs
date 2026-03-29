public class Solution {
    private int[,] memo;

    public int LongestCommonSubsequence(string text1, string text2) {
        memo = new int[text1.Length, text2.Length];
        for (int i = 0; i < text1.Length; i++) {
            for (int j = 0; j < text2.Length; j++) {
                memo[i, j] = -1;
            }
        }
        return Dfs(text1, text2, 0, 0);
    }

    private int Dfs(string text1, string text2, int i, int j) {
        if (i == text1.Length || j == text2.Length) {
            return 0;
        }
        if (memo[i, j] != -1) {
            return memo[i, j];
        }
        if (text1[i] == text2[j]) {
            memo[i, j] = 1 + Dfs(text1, text2, i + 1, j + 1);
        } else {
            memo[i, j] = Math.Max(Dfs(text1, text2, i + 1, j), 
                                  Dfs(text1, text2, i, j + 1));
        }
        return memo[i, j];
    }
}