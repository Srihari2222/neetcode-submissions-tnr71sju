public class Solution {
    private HashSet<String> wordSet;
    private Boolean[] memo;
    private int t;

    public boolean wordBreak(String s, List<String> wordDict) {
        wordSet = new HashSet<>(wordDict);
        memo = new Boolean[s.length()];
        t = 0;
        for (int i = 0; i < wordDict.size(); i++) {
            t = Math.max(t, wordDict.get(i).length());
        }
        return dfs(s, 0);
    }

    private boolean dfs(String s, int i) {
        if (i == s.length()) {
            return true;
        }
        if (memo[i] != null) {
            return memo[i];
        }

        for (int j = i; j < Math.min(i + t, s.length()); j++) {
            if (wordSet.contains(s.substring(i, j + 1))) {
                if (dfs(s, j + 1)) {
                    memo[i] = true;
                    return true;
                }
            }
        }
        memo[i] = false;
        return false;
    }
}