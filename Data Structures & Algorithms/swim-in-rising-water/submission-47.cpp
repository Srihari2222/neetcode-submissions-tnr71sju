class DSU {
    vector<int> Parent, Size;
public:
    DSU(int n) : Parent(n + 1), Size(n + 1, 1) {
        for (int i = 0; i <= n; i++) Parent[i] = i;
    }

    int find(int node) {
        if (Parent[node] != node)
            Parent[node] = find(Parent[node]);
        return Parent[node];
    }

    bool unionSets(int u, int v) {
        int pu = find(u), pv = find(v);
        if (pu == pv) return false;
        if (Size[pu] < Size[pv]) swap(pu, pv);
        Size[pu] += Size[pv];
        Parent[pv] = pu;
        return true;
    }

    bool connected(int u, int v) {
        return find(u) == find(v);
    }
};

class Solution {
public:
    int swimInWater(vector<vector<int>>& grid) {
        int N = grid.size();
        DSU dsu(N * N);
        vector<tuple<int, int, int>> positions;
        for (int r = 0; r < N; r++)
            for (int c = 0; c < N; c++)
                positions.emplace_back(grid[r][c], r, c);

        sort(positions.begin(), positions.end());
        vector<pair<int, int>> directions = {
            {0, 1}, {1, 0}, {0, -1}, {-1, 0}
        };

        for (auto& [t, r, c] : positions) {
            for (auto& [dr, dc] : directions) {
                int nr = r + dr, nc = c + dc;
                if (nr >= 0 && nr < N && nc >= 0 && 
                    nc < N && grid[nr][nc] <= t) {
                    dsu.unionSets(r * N + c, nr * N + nc);
                }
            }
            if (dsu.connected(0, N * N - 1)) return t;
        }
        return N * N;
    }
};