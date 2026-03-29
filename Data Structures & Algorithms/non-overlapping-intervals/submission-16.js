class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number}
     */
    eraseOverlapIntervals(intervals) {
        intervals.sort((a, b) => a[1] - b[1]);
        const n = intervals.length;
        let memo = new Array(n).fill(-1);  

        const dfs = (i) => {
            if (i >= n) return 0;
            if (memo[i] !== -1) return memo[i];

            let res = 1;
            for (let j = i + 1; j < n; j++) {
                if (intervals[i][1] <= intervals[j][0]) {
                    res = Math.max(res, 1 + dfs(j));
                }
            }
            memo[i] = res;
            return res;
        };

        const maxNonOverlapping = dfs(0);
        return n - maxNonOverlapping;
    }
}