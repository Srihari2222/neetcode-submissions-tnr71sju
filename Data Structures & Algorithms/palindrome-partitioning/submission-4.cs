public class Solution {
    
    public List<List<string>> Partition(string s) {
        return Dfs(s, 0);
    }

    private List<List<string>> Dfs(string s, int i) {
        if (i >= s.Length) {
            return new List<List<string>> { new List<string>() };
        }

        var ret = new List<List<string>>();
        for (int j = i; j < s.Length; j++) {
            if (IsPali(s, i, j)) {
                var nxt = Dfs(s, j + 1);
                foreach (var part in nxt) {
                    var cur = new List<string> { s.Substring(i, j - i + 1) };
                    cur.AddRange(part);
                    ret.Add(cur);
                }
            }
        }
        return ret;
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