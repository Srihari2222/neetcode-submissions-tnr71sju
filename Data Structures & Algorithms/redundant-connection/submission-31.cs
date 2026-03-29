public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] indegree = new int[n + 1];
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
            indegree[u]++;
            indegree[v]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= n; i++) {
            if (indegree[i] == 1) q.Enqueue(i);
        }

        while (q.Count > 0) {
            int node = q.Dequeue();
            indegree[node]--;
            foreach (int nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 1) q.Enqueue(nei);
            }
        }

        for (int i = edges.Length - 1; i >= 0; i--) {
            int u = edges[i][0], v = edges[i][1];
            if (indegree[u] == 2 && indegree[v] > 0) 
                return new int[] {u, v};
        }
        return new int[0];
    }
}