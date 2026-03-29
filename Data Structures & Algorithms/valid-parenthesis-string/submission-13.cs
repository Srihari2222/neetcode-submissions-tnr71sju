public class Solution {
    public bool CheckValidString(string s) {
        int n = s.Length;
        bool?[,] memo = new bool?[n + 1, n + 1];
        return Dfs(0, 0, s, memo);
    }

    private bool Dfs(int i, int open, string s, bool?[,] memo) {
        if (open < 0) return false;
        if (i == s.Length) return open == 0;

        if (memo[i, open].HasValue) return memo[i, open].Value;

        bool result;
        if (s[i] == '(') {
            result = Dfs(i + 1, open + 1, s, memo);
        } else if (s[i] == ')') {
            result = Dfs(i + 1, open - 1, s, memo);
        } else {
            result = Dfs(i + 1, open, s, memo) || 
                     Dfs(i + 1, open + 1, s, memo) || 
                     Dfs(i + 1, open - 1, s, memo);
        }

        memo[i, open] = result;
        return result;
    }
}