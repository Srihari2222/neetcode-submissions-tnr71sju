class Solution {
    /**
     * @param {number[][]} intervals
     * @return {number[][]}
     */
    merge(intervals) {
        let max = 0;
        for (let i = 0; i < intervals.length; i++) {
            max = Math.max(intervals[i][0], max);
        }

        let mp = new Array(max + 1).fill(0);
        for (let i = 0; i < intervals.length; i++) {
            let start = intervals[i][0];
            let end = intervals[i][1];
            mp[start] = Math.max(end + 1, mp[start]);
        }

        let res = [];
        let have = -1;
        let intervalStart = -1;
        for (let i = 0; i < mp.length; i++) {
            if (mp[i] !== 0) {
                if (intervalStart === -1) intervalStart = i;
                have = Math.max(mp[i] - 1, have);
            }
            if (have === i) {
                res.push([intervalStart, have]);
                have = -1;
                intervalStart = -1;
            }
        }

        if (intervalStart !== -1) {
            res.push([intervalStart, have]);
        }

        return res;
    }
}