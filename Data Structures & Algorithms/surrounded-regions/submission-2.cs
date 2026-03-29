public class Solution {
    private int ROWS, COLS;

    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        for (int r = 0; r < ROWS; r++) {
            if (board[r][0] == 'O') {
                Capture(board, r, 0);
            }
            if (board[r][COLS - 1] == 'O') {
                Capture(board, r, COLS - 1);
            }
        }

        for (int c = 0; c < COLS; c++) {
            if (board[0][c] == 'O') {
                Capture(board, 0, c);
            }
            if (board[ROWS - 1][c] == 'O') {
                Capture(board, ROWS - 1, c);
            }
        }

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T') {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void Capture(char[][] board, int r, int c) {
        if (r < 0 || c < 0 || r == ROWS || 
            c == COLS || board[r][c] != 'O') {
            return;
        }
        board[r][c] = 'T';
        Capture(board, r + 1, c);
        Capture(board, r - 1, c);
        Capture(board, r, c + 1);
        Capture(board, r, c - 1);
    }
}