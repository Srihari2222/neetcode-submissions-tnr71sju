public class Solution {
    int ROWS, COLS;
    bool pacific, atlantic;
    int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
    };

    public List<List<int>> PacificAtlantic(int[][] heights) {
        ROWS = heights.Length;
        COLS = heights[0].Length;
        List<List<int>> res = new List<List<int>>();

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                pacific = false;
                atlantic = false;
                Dfs(heights, r, c, int.MaxValue);
                if (pacific && atlantic) {
                    res.Add(new List<int>{r, c});
                }
            }
        }
        return res;
    }

    private void Dfs(int[][] heights, int r, int c, int prevVal) {
        if (r < 0 || c < 0) {
            pacific = true;
            return;
        }
        if (r >= ROWS || c >= COLS) {
            atlantic = true;
            return;
        }
        if (heights[r][c] > prevVal) {
            return;
        }

        int tmp = heights[r][c];
        heights[r][c] = int.MaxValue;
        foreach (var dir in directions) {
            Dfs(heights, r + dir[0], c + dir[1], tmp);
            if (pacific && atlantic) {
                break;
            }
        }
        heights[r][c] = tmp;
    }
}