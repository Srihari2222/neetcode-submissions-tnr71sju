public class Solution {
    
    public int[] manacher(String s) {
        StringBuilder t = new StringBuilder("#");
        for (char c : s.toCharArray()) {
            t.append(c).append("#");
        }
        int n = t.length();
        int[] p = new int[n];
        int l = 0, r = 0;
        for (int i = 0; i < n; i++) {
            p[i] = (i < r) ? Math.min(r - i, p[l + (r - i)]) : 0;
            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 &&
                   t.charAt(i + p[i] + 1) == t.charAt(i - p[i] - 1)) {
                p[i]++;
            }
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }
        return p;
    }

    public int countSubstrings(String s) {
        int res = 0;
        int[] p = manacher(s);
        for (int i : p) {
            res += (i + 1) / 2;
        }
        return res;
    }
}