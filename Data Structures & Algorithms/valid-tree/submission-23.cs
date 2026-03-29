public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length > n - 1) {
            return false;
        }

        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        HashSet<int> visit = new HashSet<int>();
        if (!Dfs(0, -1, visit, adj)) {
            return false;
        }

        return visit.Count == n;
    }

    private bool Dfs(int node, int parent, HashSet<int> visit, 
                     List<List<int>> adj) {
        if (visit.Contains(node)) {
            return false;
        }

        visit.Add(node);
        foreach (var nei in adj[node]) {
            if (nei == parent) {
                continue;
            }
            if (!Dfs(nei, node, visit, adj)) {
                return false;
            }
        }
        return true;
    }
}