public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<List<int>> adj = new List<List<int>>();
        bool[] visit = new bool[n];
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int res = 0;
        for (int node = 0; node < n; node++) {
            if (!visit[node]) {
                Bfs(adj, visit, node);
                res++;
            }
        }
        return res;
    }

    private void Bfs(List<List<int>> adj, bool[] visit, int node) {
        Queue<int> q = new Queue<int>();
        q.Enqueue(node);
        visit[node] = true;
        while (q.Count > 0) {
            int cur = q.Dequeue();
            foreach (var nei in adj[cur]) {
                if (!visit[nei]) {
                    visit[nei] = true;
                    q.Enqueue(nei);
                }
            }
        }
    }
}