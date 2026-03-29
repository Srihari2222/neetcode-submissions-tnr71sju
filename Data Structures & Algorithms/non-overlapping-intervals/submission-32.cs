public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int res = 0;
        int prevEnd = intervals[0][1];
        
        for (int i = 1; i < intervals.Length; i++) {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start >= prevEnd) {
                prevEnd = end;
            } else {
                res++;
                prevEnd = Math.Min(end, prevEnd);
            }
        }
        return res;
    }
}