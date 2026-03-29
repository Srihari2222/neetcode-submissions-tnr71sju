public class Solution {
    public int numDistinct(String s, String t) {
        if (t.length() > s.length()) {
            return 0;
        }
        return dfs(s, t, 0, 0);
    }

    private int dfs(String s, String t, int i, int j) {
        if (j == t.length()) {
            return 1;
        }
        if (i == s.length()) {
            return 0;
        }

        int res = dfs(s, t, i + 1, j);
        if (s.charAt(i) == t.charAt(j)) {
            res += dfs(s, t, i + 1, j + 1);
        }
        return res;
    }
}