public class DSU {
    private int[] Parent, Size;

    public DSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int Find(int node) {
        if (node != Parent[node]) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u);
        int pv = Find(v);
        if (pu == pv) return false;
        if (Size[pu] >= Size[pv]) {
            Size[pu] += Size[pv];
            Parent[pv] = pu;
        } else {
            Size[pv] += Size[pu];
            Parent[pu] = pv;
        }
        return true;
    }

    public int GetSize(int node) {
        return Size[Find(node)];
    }
}

public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int ROWS = grid.Length;
        int COLS = grid[0].Length;
        DSU dsu = new DSU(ROWS * COLS);

        int[][] directions = new int[][] {
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 }
        };
        int area = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == 1) {
                    foreach (var d in directions) {
                        int nr = r + d[0];
                        int nc = c + d[1];
                        if (nr >= 0 && nc >= 0 && nr < ROWS && 
                            nc < COLS && grid[nr][nc] == 1) {
                            dsu.Union(r * COLS + c, nr * COLS + nc);
                        }
                    }
                    area = Math.Max(area, dsu.GetSize(r * COLS + c));
                }
            }
        }

        return area;
    }
}