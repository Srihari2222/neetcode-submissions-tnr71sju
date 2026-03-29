public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!adj.ContainsKey(time[0])) {
                adj[time[0]] = new List<int[]>();
            }
            adj[time[0]].Add(new int[] { time[1], time[2] });
        }

        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;

        Dfs(k, 0, adj, dist);
        int res = dist.Values.Max();
        return res == int.MaxValue ? -1 : res;
    }

    private void Dfs(int node, int time, 
                     Dictionary<int, List<int[]>> adj, 
                     Dictionary<int, int> dist) {
        if (time >= dist[node]) return;
        dist[node] = time;
        if (!adj.ContainsKey(node)) return;
        foreach (var edge in adj[node]) {
            Dfs(edge[0], time + edge[1], adj, dist);
        }
    }
}