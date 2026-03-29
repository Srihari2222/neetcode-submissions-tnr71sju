public class Solution {
    public string MinWindow(string s, string t) {
        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        foreach (char c in t) {
            if (countT.ContainsKey(c)) {
                countT[c]++;
            } else {
                countT[c] = 1;
            }
        }

        int[] res = { -1, -1 };
        int resLen = int.MaxValue;

        for (int i = 0; i < s.Length; i++) {
            Dictionary<char, int> countS = new Dictionary<char, int>();
            for (int j = i; j < s.Length; j++) {
                if (countS.ContainsKey(s[j])) {
                    countS[s[j]]++;
                } else {
                    countS[s[j]] = 1;
                }

                bool flag = true;
                foreach (var c in countT.Keys) {
                    if (!countS.ContainsKey(c) || countS[c] < countT[c]) {
                        flag = false;
                        break;
                    }
                }

                if (flag && (j - i + 1) < resLen) {
                    resLen = j - i + 1;
                    res[0] = i;
                    res[1] = j;
                }
            }
        }

        return resLen == int.MaxValue ? "" : s.Substring(res[0], resLen);
    }
}