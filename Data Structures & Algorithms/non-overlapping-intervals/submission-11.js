class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number}
     */
    eraseOverlapIntervals(intervals) {
        intervals.sort((a, b) => a[0] - b[0]);
        
        const dfs = (i, prev) => {
            if (i === intervals.length) return 0;
            let res = dfs(i + 1, prev);
            if (prev === -1 || intervals[prev][1] <= intervals[i][0]) {
                res = Math.max(res, 1 + dfs(i + 1, i));
            }
            return res;
        };

        return intervals.length - dfs(0, -1);
    }
}