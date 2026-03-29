public class Solution {
    public int CharacterReplacement(string s, int k) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            Dictionary<char, int> count = new Dictionary<char, int>();
            int maxf = 0;
            for (int j = i; j < s.Length; j++) {
                if (count.ContainsKey(s[j])) {
                    count[s[j]]++;
                } else {
                    count[s[j]] = 1;
                }
                maxf = Math.Max(maxf, count[s[j]]);
                if ((j - i + 1) - maxf <= k) {
                    res = Math.Max(res, j - i + 1);
                }
            }
        }
        return res;
    }
}