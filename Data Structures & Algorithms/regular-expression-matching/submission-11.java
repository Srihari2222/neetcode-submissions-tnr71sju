public class Solution {
    public boolean isMatch(String s, String p) {
        boolean[] dp = new boolean[p.length() + 1];
        dp[p.length()] = true;

        for (int i = s.length(); i >= 0; i--) {
            boolean[] nextDp = new boolean[p.length() + 1];
            nextDp[p.length()] = i == s.length();

            for (int j = p.length() - 1; j >= 0; j--) {
                boolean match = i < s.length() && 
                                (s.charAt(i) == p.charAt(j) || 
                                 p.charAt(j) == '.');

                if (j + 1 < p.length() && p.charAt(j + 1) == '*') {
                    nextDp[j] = nextDp[j + 2];
                    if (match) {
                        nextDp[j] |= dp[j];
                    }
                } else if (match) {
                    nextDp[j] = dp[j + 1];
                }
            }

            dp = nextDp;
        }

        return dp[0];
    }
}