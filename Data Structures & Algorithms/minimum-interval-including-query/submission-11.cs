public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        int[] res = new int[queries.Length];
        int idx = 0;
        foreach (int q in queries) {
            int cur = -1;
            foreach (var interval in intervals) {
                int l = interval[0], r = interval[1];
                if (l <= q && q <= r) {
                    if (cur == -1 || (r - l + 1) < cur) {
                        cur = r - l + 1;
                    }
                }
            }
            res[idx++] = cur;
        }
        return res;
    }
}