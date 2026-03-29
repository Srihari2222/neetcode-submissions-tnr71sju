/**
 * Definition of Interval:
 * class Interval {
 *   constructor(start, end) {
 *     this.start = start;
 *     this.end = end;
 *   }
 * }
 */

class Solution {
    /**
     * @param {Interval[]} intervals
     * @returns {number}
     */
    minMeetingRooms(intervals) {
        const mp = new Map();
        for (const i of intervals) {
            mp.set(i.start, (mp.get(i.start) || 0) + 1);
            mp.set(i.end, (mp.get(i.end) || 0) - 1);
        }
        const sortedKeys = Array.from(mp.keys()).sort((a, b) => a - b);
        let prev = 0, res = 0;
        for (const key of sortedKeys) {
            prev += mp.get(key);
            res = Math.max(res, prev);
        }
        return res;
    }
}