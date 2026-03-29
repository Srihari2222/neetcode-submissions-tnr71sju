public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        return Dfs(text1, text2, 0, 0);
    }

    private int Dfs(string text1, string text2, int i, int j) {
        if (i == text1.Length || j == text2.Length) {
            return 0;
        }
        if (text1[i] == text2[j]) {
            return 1 + Dfs(text1, text2, i + 1, j + 1);
        }
        return Math.Max(Dfs(text1, text2, i + 1, j), 
                        Dfs(text1, text2, i, j + 1));
    }
}