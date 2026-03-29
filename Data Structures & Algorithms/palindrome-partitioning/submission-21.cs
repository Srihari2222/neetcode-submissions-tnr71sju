public class Solution {
    
    public List<List<string>> Partition(string s) {
        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        Dfs(0, s, part, res);
        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (IsPali(s, i, j)) {
                part.Add(s.Substring(i, j - i + 1));
                Dfs(j + 1, s, part, res);
                part.RemoveAt(part.Count - 1);
            }
        }
    }

    private bool IsPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}