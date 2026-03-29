public class Solution {
    public bool Valid(string s) {
        int open = 0;
        foreach (char c in s) {
            open += (c == '(') ? 1 : -1;
            if (open < 0) return false;
        }
        return open == 0;
    }

    public void Dfs(string s, List<string> res, int n) {
        if (s.Length == 2 * n) {
            if (Valid(s)) res.Add(s);
            return;
        }
        Dfs(s + '(', res, n);
        Dfs(s + ')', res, n);
    }

    public List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        Dfs("", res, n);
        return res;
    }
}