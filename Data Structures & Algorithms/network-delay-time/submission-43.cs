public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 1; i <= n; i++) adj[i] = new List<int[]>();
        foreach (var time in times) {
            adj[time[0]].Add(new int[] {time[1], time[2]});
        }
        
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;
        dist[k] = 0;

        var q = new Queue<int[]>();
        q.Enqueue(new int[] {k, 0});

        while (q.Count > 0) {
            var curr = q.Dequeue();
            int node = curr[0], time = curr[1];
            if (dist[node] < time) continue;
            foreach (var nei in adj[node]) {
                int nextNode = nei[0], weight = nei[1];
                if (time + weight < dist[nextNode]) {
                    dist[nextNode] = time + weight;
                    q.Enqueue(new int[] {nextNode, time + weight});
                }
            }
        }

        int res = 0;
        foreach (var time in dist.Values) { 
            res = Math.Max(res, time);
        }
        return res == int.MaxValue ? -1 : res;
    }
}