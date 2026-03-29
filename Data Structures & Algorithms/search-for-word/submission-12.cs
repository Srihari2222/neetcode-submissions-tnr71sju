public class Solution {
    private int ROWS, COLS;
    private bool[,] visited;

    public bool Exist(char[][] board, string word) {
        ROWS = board.Length;
        COLS = board[0].Length;
        visited = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (DFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool DFS(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }

        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || 
            board[r][c] != word[i] || visited[r, c]) {
            return false;
        }

        visited[r, c] = true;
        bool res = DFS(board, word, r + 1, c, i + 1) || 
                   DFS(board, word, r - 1, c, i + 1) ||
                   DFS(board, word, r, c + 1, i + 1) || 
                   DFS(board, word, r, c - 1, i + 1);
        visited[r, c] = false;

        return res;
    }
}