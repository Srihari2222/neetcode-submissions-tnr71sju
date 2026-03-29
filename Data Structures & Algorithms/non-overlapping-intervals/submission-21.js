class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number}
     */
    eraseOverlapIntervals(intervals) {
        intervals.sort((a, b) => a[1] - b[1]);
        const n = intervals.length;
        const dp = new Array(n).fill(0);  

        for (let i = 0; i < n; i++) {
            dp[i] = 1;  
            for (let j = 0; j < i; j++) {
                if (intervals[j][1] <= intervals[i][0]) {  
                    dp[i] = Math.max(dp[i], 1 + dp[j]);
                }
            }
        }

        const maxNonOverlapping = Math.max(...dp);  
        return n - maxNonOverlapping;
    }
}