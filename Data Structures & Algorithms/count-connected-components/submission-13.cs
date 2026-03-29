public class DSU {
    private int[] parent;

    public DSU(int n) {
        parent = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            parent[i] = i;
        }
    }

    public int Find(int node) {
        if (parent[node] != node) {
            parent[node] = Find(parent[node]);
        }
        return parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv) {
            return false;
        }
        parent[pv] = pu;
        return true;
    }
}

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        DSU dsu = new DSU(n);
        int res = n;
        foreach (var edge in edges) {
            if (dsu.Union(edge[0], edge[1])) {
                res--;
            }
        }
        return res;
    }
}