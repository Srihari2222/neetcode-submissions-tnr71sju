public class Solution {
    public int CountSubstrings(string s) {
        int res = 0;

        for (int i = 0; i < s.Length; i++) {
            for (int j = i; j < s.Length; j++) {
                int l = i, r = j;
                while (l < r && s[l] == s[r]) {
                    l++;
                    r--;
                }
                res += (l >= r) ? 1 : 0;
            }
        }

        return res;
    }
}