class Solution {
    /**
     * @param {number[][]} intervals
     * @param {number[]} queries
     * @return {number[]}
     */
    minInterval(intervals, queries) {
        const res = [];
        for (const q of queries) {
            let cur = -1;
            for (const [l, r] of intervals) {
                if (l <= q && q <= r) {
                    if (cur === -1 || (r - l + 1) < cur) {
                        cur = r - l + 1;
                    }
                }
            }
            res.push(cur);
        }
        return res;
    }
}