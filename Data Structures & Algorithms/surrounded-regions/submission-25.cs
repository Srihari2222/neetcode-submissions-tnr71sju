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
        if (Parent[node] != node) {
            Parent[node] = Find(Parent[node]);
        }
        return Parent[node];
    }

    public bool Union(int u, int v) {
        int pu = Find(u), pv = Find(v);
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

    public bool Connected(int u, int v) {
        return Find(u) == Find(v);
    }
}

public class Solution {
    public void Solve(char[][] board) {
        int ROWS = board.Length, COLS = board[0].Length;
        DSU dsu = new DSU(ROWS * COLS + 1);
        int[][] directions = new int[][] { 
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 } 
        };

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] != 'O') continue;
                if (r == 0 || c == 0 || 
                    r == ROWS - 1 || c == COLS - 1) {
                    dsu.Union(ROWS * COLS, r * COLS + c);
                } else {
                    foreach (var dir in directions) {
                        int nr = r + dir[0], nc = c + dir[1];
                        if (board[nr][nc] == 'O') {
                            dsu.Union(r * COLS + c, nr * COLS + nc);
                        }
                    }
                }
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (!dsu.Connected(ROWS * COLS, r * COLS + c)) {
                    board[r][c] = 'X';
                }
            }
        }
    }
}