public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int m = s1.Length, n = s2.Length;
        if (m + n != s3.Length) return false;
        if (n < m) {
            var temp = s1;
            s1 = s2;
            s2 = temp;
            int tempLength = m;
            m = n;
            n = tempLength;
        }
        
        bool[] dp = new bool[n + 1];
        dp[n] = true;
        for (int i = m; i >= 0; i--) {
            bool[] nextDp = new bool[n + 1];
            nextDp[n] = true;
            for (int j = n; j >= 0; j--) {
                if (i < m && s1[i] == s3[i + j] && dp[j]) {
                    nextDp[j] = true;
                }
                if (j < n && s2[j] == s3[i + j] && nextDp[j + 1]) {
                    nextDp[j] = true;
                }
            }
            dp = nextDp;
        }
        return dp[0];
    }
}