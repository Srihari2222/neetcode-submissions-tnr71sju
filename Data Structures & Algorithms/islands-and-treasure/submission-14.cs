public class Solution {
    private int[][] directions = new int[][] {
        new int[] { 1, 0 }, new int[] { -1, 0 },
        new int[] { 0, 1 }, new int[] { 0, -1 }
    };
    private int INF = int.MaxValue;
    private int ROWS, COLS;

    private int Bfs(int[][] grid, int r, int c) {
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { r, c });
        bool[][] visit = new bool[ROWS][];
        for (int i = 0; i < ROWS; i++) visit[i] = new bool[COLS];
        visit[r][c] = true;
        int steps = 0;

        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                var curr = q.Dequeue();
                int row = curr[0], col = curr[1];
                if (grid[row][col] == 0) return steps;
                foreach (var dir in directions) {
                    int nr = row + dir[0], nc = col + dir[1];
                    if (nr >= 0 && nr < ROWS && nc >= 0 && nc < COLS && 
                        !visit[nr][nc] && grid[nr][nc] != -1) {
                        visit[nr][nc] = true;
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
            }
            steps++;
        }
        return INF;
    }

    public void islandsAndTreasure(int[][] grid) {
        ROWS = grid.Length;
        COLS = grid[0].Length;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == INF) {
                    grid[r][c] = Bfs(grid, r, c);
                }
            }
        }
    }
}