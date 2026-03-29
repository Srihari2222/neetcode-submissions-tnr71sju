public class Solution {
    private Dictionary<int, bool> memo;

    public bool WordBreak(string s, List<string> wordDict) {
        memo = new Dictionary<int, bool> { { s.Length, true } };
        return Dfs(s, wordDict, 0);
    }

    private bool Dfs(string s, List<string> wordDict, int i) {
        if (memo.ContainsKey(i)) {
            return memo[i];
        }

        foreach (var w in wordDict) {
            if (i + w.Length <= s.Length && 
                s.Substring(i, w.Length) == w) {
                if (Dfs(s, wordDict, i + w.Length)) {
                    memo[i] = true;
                    return true;
                }
            }
        }
        memo[i] = false;
        return false;
    }
}