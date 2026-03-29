public class Solution {
    public int CountSubstrings(string s) {
        int res = 0, n = s.Length;
        bool[,] dp = new bool[n, n];

        for (int i = n - 1; i >= 0; i--) {
            for (int j = i; j < n; j++) {
                if (s[i] == s[j] && 
                   (j - i <= 2 || dp[i + 1, j - 1])) {
                    
                    dp[i, j] = true;
                    res++;
                }
            }
        }

        return res;
    }
}