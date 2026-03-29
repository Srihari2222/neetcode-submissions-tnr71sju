class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number[][]}
     */
    merge(intervals) {
        const mp = new Map();
        for (const [start, end] of intervals) {
            mp.set(start, (mp.get(start) || 0) + 1);
            mp.set(end, (mp.get(end) || 0) - 1);
        }

        const sortedKeys = Array.from(mp.keys()).sort((a, b) => a - b);
        const res = [];
        let interval = [];
        let have = 0;

        for (const i of sortedKeys) {
            if (interval.length === 0) {
                interval.push(i);
            }
            have += mp.get(i);
            if (have === 0) {
                interval.push(i);
                res.push(interval);
                interval = [];
            }
        }
        return res;
    }
}