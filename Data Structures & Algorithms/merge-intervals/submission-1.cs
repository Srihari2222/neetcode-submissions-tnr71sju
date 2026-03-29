public class Solution {
    public int[][] Merge(int[][] intervals) {
        var mp = new SortedDictionary<int, int>();
        foreach (var point in intervals) {
            if (!mp.ContainsKey(point[0])) mp[point[0]] = 0;
            if (!mp.ContainsKey(point[1])) mp[point[1]] = 0;
            mp[point[0]]++;
            mp[point[1]]--;
        }

        var res = new List<int[]>();
        var interval = new int[2];
        int have = 0;
        foreach (var kvp in mp) {
            if (have == 0) interval[0] = kvp.Key;
            have += kvp.Value;
            if (have == 0) {
                interval[1] = kvp.Key;
                res.Add(new int[] { interval[0], interval[1] });
            }
        }
        return res.ToArray();
    }
}