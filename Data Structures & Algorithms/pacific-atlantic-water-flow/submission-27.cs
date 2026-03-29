public class Solution {
    private int[][] directions = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        Queue<int[]> pacQueue = new Queue<int[]>();
        Queue<int[]> atlQueue = new Queue<int[]>();

        for (int c = 0; c < COLS; c++) {
            pacQueue.Enqueue(new int[] { 0, c });
            atlQueue.Enqueue(new int[] { ROWS - 1, c });
        }
        for (int r = 0; r < ROWS; r++) {
            pacQueue.Enqueue(new int[] { r, 0 });
            atlQueue.Enqueue(new int[] { r, COLS - 1 });
        }

        Bfs(pacQueue, pac, heights);
        Bfs(atlQueue, atl, heights);

        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r, c]) {
                    res.Add(new List<int> { r, c });
                }
            }
        }
        return res;
    }

    private void Bfs(Queue<int[]> q, bool[,] ocean, int[][] heights) {
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int r = cur[0], c = cur[1];
            ocean[r, c] = true;
            foreach (var dir in directions) {
                int nr = r + dir[0], nc = c + dir[1];
                if (nr >= 0 && nr < heights.Length && nc >= 0 && 
                    nc < heights[0].Length && !ocean[nr, nc] && 
                    heights[nr][nc] >= heights[r][c]) {
                    q.Enqueue(new int[] { nr, nc });
                }
            }
        }
    }
}