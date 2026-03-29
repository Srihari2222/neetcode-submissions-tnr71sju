public class Solution {
    public string LongestPalindrome(string s) {
        string res = "";
        int resLen = 0;

        for (int i = 0; i < s.Length; i++) {
            for (int j = i; j < s.Length; j++) {
                int l = i, r = j;
                while (l < r && s[l] == s[r]) {
                    l++;
                    r--;
                }

                if (l >= r && resLen < (j - i + 1)) {
                    res = s.Substring(i, j - i + 1);
                    resLen = j - i + 1;
                }
            }
        }

        return res;
    }
}