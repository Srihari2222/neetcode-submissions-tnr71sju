public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length, n = p.Length;
        return Dfs(0, 0, s, p, m, n);
    }

    private bool Dfs(int i, int j, string s, string p, int m, int n) {
        if (j == n) {
            return i == m;
        }

        bool match = i < m && (s[i] == p[j] || p[j] == '.');
        if (j + 1 < n && p[j + 1] == '*') {
            return Dfs(i, j + 2, s, p, m, n) || 
                   (match && Dfs(i + 1, j, s, p, m, n));
        }

        if (match) {
            return Dfs(i + 1, j + 1, s, p, m, n);
        }

        return false;
    }
}