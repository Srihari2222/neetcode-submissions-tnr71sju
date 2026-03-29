class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number}
     */
    eraseOverlapIntervals(intervals) {
        intervals.sort((a, b) => a[1] - b[1]);
        const n = intervals.length;
        const dp = new Array(n).fill(0);
        dp[0] = 1;

        const bs = (r, target) => {
            let l = 0;
            while (l < r) {
                const m = (l + r) >> 1;
                if (intervals[m][1] <= target) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            return l;
        }

        for (let i = 1; i < n; i++) {
            const idx = bs(i, intervals[i][0]);
            if (idx === 0) {
                dp[i] = dp[i - 1];
            } else {
                dp[i] = Math.max(dp[i - 1], 1 + dp[idx - 1]);
            }
        }
        return n - dp[n - 1];
    }
}