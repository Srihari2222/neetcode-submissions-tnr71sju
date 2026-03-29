public class Solution {
    public int NumDistinct(string s, string t) {
        if (t.Length > s.Length) {
            return 0;
        }
        return Dfs(s, t, 0, 0);
    }

    private int Dfs(string s, string t, int i, int j) {
        if (j == t.Length) {
            return 1;
        }
        if (i == s.Length) {
            return 0;
        }

        int res = Dfs(s, t, i + 1, j);
        if (s[i] == t[j]) {
            res += Dfs(s, t, i + 1, j + 1);
        }
        return res;
    }
}