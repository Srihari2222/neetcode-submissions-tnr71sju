public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        return Dfs(s, wordDict, 0);
    }

    private bool Dfs(string s, List<string> wordDict, int i) {
        if (i == s.Length) {
            return true;
        }

        foreach (string w in wordDict) {
            if (i + w.Length <= s.Length && 
                s.Substring(i, w.Length) == w) {
                if (Dfs(s, wordDict, i + w.Length)) {
                    return true;
                }
            }
        }
        return false;
    }
}