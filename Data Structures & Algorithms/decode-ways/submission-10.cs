public class Solution {

    public int NumDecodings(string s) {
        Dictionary<int, int> dp = new Dictionary<int, int>();
        dp[s.Length] = 1;
        return Dfs(s, 0, dp);
    }

    private int Dfs(string s, int i, Dictionary<int, int> dp) {
        if (dp.ContainsKey(i)) {
            return dp[i];
        }
        if (s[i] == '0') {
            return 0;
        }

        int res = Dfs(s, i + 1, dp);
        if (i + 1 < s.Length && (s[i] == '1' || 
            s[i] == '2' && s[i + 1] < '7')) {
            res += Dfs(s, i + 2, dp);
        }
        dp[i] = res;
        return res;
    }
}