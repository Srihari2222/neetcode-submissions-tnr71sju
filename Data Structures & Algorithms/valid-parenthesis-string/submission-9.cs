public class Solution {
    public bool CheckValidString(string s) {
        return Dfs(0, 0, s);
    }

    private bool Dfs(int i, int open, string s) {
        if (open < 0) return false;
        if (i == s.Length) return open == 0;

        if (s[i] == '(') {
            return Dfs(i + 1, open + 1, s);
        } else if (s[i] == ')') {
            return Dfs(i + 1, open - 1, s);
        } else {
            return Dfs(i + 1, open, s) ||
                   Dfs(i + 1, open + 1, s) ||
                   Dfs(i + 1, open - 1, s);
        }
    }
}