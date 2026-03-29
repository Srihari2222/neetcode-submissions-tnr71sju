public class Solution {
    public boolean isMatch(String s, String p) {
        int m = s.length(), n = p.length();
        return dfs(0, 0, s, p, m, n);
    }

    private boolean dfs(int i, int j, String s, String p, int m, int n) {
        if (j == n) return i == m;

        boolean match = i < m && (s.charAt(i) == p.charAt(j) || 
                        p.charAt(j) == '.');
        if (j + 1 < n && p.charAt(j + 1) == '*') {
            return dfs(i, j + 2, s, p, m, n) || 
                   (match && dfs(i + 1, j, s, p, m, n));
        }

        if (match) {
            return dfs(i + 1, j + 1, s, p, m, n);
        }
        
        return false;
    }
}