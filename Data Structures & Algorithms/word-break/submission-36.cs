public class Solution {
    private HashSet<string> wordSet;
    private Dictionary<int, bool> memo;
    private int t;

    public bool WordBreak(string s, List<string> wordDict) {
        wordSet = new HashSet<string>(wordDict);
        memo = new Dictionary<int, bool>();
        t = 0;
        foreach (var w in wordDict) {
            t = Math.Max(t, w.Length);
        }
        return Dfs(s, 0);
    }

    private bool Dfs(string s, int i) {
        if (i == s.Length) {
            return true;
        }
        if (memo.ContainsKey(i)) {
            return memo[i];
        }

        for (int j = i; j < Math.Min(i + t, s.Length); j++) {
            if (wordSet.Contains(s.Substring(i, j - i + 1))) {
                if (Dfs(s, j + 1)) {
                    memo[i] = true;
                    return true;
                }
            }
        }
        memo[i] = false;
        return false;
    }
}