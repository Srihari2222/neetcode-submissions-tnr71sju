public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        var events = new List<int[]>();
        // Create events for intervals
        for (int i = 0; i < intervals.Length; i++) {
            events.Add(new int[] { intervals[i][0], 0, intervals[i][1] - intervals[i][0] + 1, i });
            events.Add(new int[] { intervals[i][1], 2, intervals[i][1] - intervals[i][0] + 1, i });
        }
        
        // Create events for queries
        for (int i = 0; i < queries.Length; i++) {
            events.Add(new int[] { queries[i], 1, i });
        }
        // Sort by time and type (end before query)
        events.Sort((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));
        
        int[] ans = new int[queries.Length];
        Array.Fill(ans, -1);
        // Min heap storing [size, index]
        var pq = new PriorityQueue<(int size, int idx), int>();
        var inactive = new bool[intervals.Length];
        
        foreach (var e in events) {
            if (e[1] == 0) { // Interval start
                pq.Enqueue((e[2], e[3]), e[2]);
            } else if (e[1] == 2) { // Interval end
                inactive[e[3]] = true;
            } else {
                int queryIdx = e[2];
                while (pq.Count > 0 && inactive[pq.Peek().idx]) {
                    pq.Dequeue();
                }
                if (pq.Count > 0) {
                    ans[queryIdx] = pq.Peek().size;
                }
            }
        }
        
        return ans;
    }
}