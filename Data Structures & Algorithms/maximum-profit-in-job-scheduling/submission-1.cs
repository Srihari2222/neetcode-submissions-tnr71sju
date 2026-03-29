public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        int n = startTime.Length;
        var intervals = new List<(int start, int end, int profit)>();

        for (int i = 0; i < n; i++) {
            intervals.Add((startTime[i], endTime[i], profit[i]));
        }

        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        Dictionary<int, int> cache = new();

        int Dfs(int i) {
            if (i == n) return 0;
            if (cache.ContainsKey(i)) return cache[i];

            // Option 1: don't include
            int res = Dfs(i + 1);

            // Option 2: include current job
            int j = i + 1;
            while (j < n && intervals[j].start < intervals[i].end) {
                j++;
            }

            res = Math.Max(res, intervals[i].profit + Dfs(j));
            cache[i] = res;
            return res;
        }

        return Dfs(0);
    }
}