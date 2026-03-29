public class Solution {
    private int[] memo;

    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int n = intervals.Length;
        memo = new int[n];  
        Array.Fill(memo, -1);

        int maxNonOverlapping = Dfs(intervals, 0);
        return n - maxNonOverlapping;
    }

    private int Dfs(int[][] intervals, int i) {
        if (i >= intervals.Length) return 0;
        if (memo[i] != -1) return memo[i];

        int res = 1;
        for (int j = i + 1; j < intervals.Length; j++) {
            if (intervals[i][1] <= intervals[j][0]) {
                res = Math.Max(res, 1 + Dfs(intervals, j));
            }
        }
        memo[i] = res;
        return res;
    }
}