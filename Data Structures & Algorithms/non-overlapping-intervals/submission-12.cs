public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        return intervals.Length - Dfs(intervals, 0, -1);
    }

    private int Dfs(int[][] intervals, int i, int prev) {
        if (i == intervals.Length) return 0;
        int res = Dfs(intervals, i + 1, prev);
        if (prev == -1 || intervals[prev][1] <= intervals[i][0]) {
            res = Math.Max(res, 1 + Dfs(intervals, i + 1, i));
        }
        return res;
    }
}