public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
        int n = intervals.Length;
        int[] dp = new int[n];  

        for (int i = 0; i < n; i++) {
            dp[i] = 1;  
            for (int j = 0; j < i; j++) {
                if (intervals[j][1] <= intervals[i][0]) {  
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
            }
        }

        int maxNonOverlapping = 0;
        foreach (var count in dp) {
            maxNonOverlapping = Math.Max(maxNonOverlapping, count);
        }  
        return n - maxNonOverlapping;
    }
}