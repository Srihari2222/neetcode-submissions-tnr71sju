public class Solution {
    public int[] minInterval(int[][] intervals, int[] queries) {
        int[] res = new int[queries.length];
        int idx = 0;
        for (int q : queries) {
            int cur = -1;
            for (int[] interval : intervals) {
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