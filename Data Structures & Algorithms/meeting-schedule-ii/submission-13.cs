/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        var mp = new SortedDictionary<int, int>();
        foreach (var i in intervals) {
            if (!mp.ContainsKey(i.start)) mp[i.start] = 0;
            if (!mp.ContainsKey(i.end)) mp[i.end] = 0;
            mp[i.start]++;
            mp[i.end]--;
        }
        int prev = 0, res = 0;
        foreach (var kvp in mp) {
            prev += kvp.Value;
            res = Math.Max(res, prev);
        }
        return res;
    }
}