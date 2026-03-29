public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        return Dfs(s, wordSet, 0);
    }

    private bool Dfs(string s, HashSet<string> wordSet, int i) {
        if (i == s.Length) {
            return true;
        }

        for (int j = i; j < s.Length; j++) {
            if (wordSet.Contains(s.Substring(i, j - i + 1))) {
                if (Dfs(s, wordSet, j + 1)) {
                    return true;
                }
            }
        }
        return false;
    }
}