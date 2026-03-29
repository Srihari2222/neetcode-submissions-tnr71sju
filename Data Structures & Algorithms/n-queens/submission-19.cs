public class Solution {
    bool[] col, posDiag, negDiag;
    List<List<string>> res;
    char[][] board;

    public List<List<string>> SolveNQueens(int n) {
        col = new bool[n];
        posDiag = new bool[2 * n];
        negDiag = new bool[2 * n];
        res = new List<List<string>>();
        board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new string('.', n).ToCharArray();
        }
        Backtrack(0, n);
        return res;
    }

    private void Backtrack(int r, int n) {
        if (r == n) {
            var copy = new List<string>();
            foreach (var row in board) {
                copy.Add(new string(row));
            }
            res.Add(copy);
            return;
        }
        for (int c = 0; c < n; c++) {
            if (col[c] || posDiag[r + c] || negDiag[r - c + n]) {
                continue;
            } 
            col[c] = true;
            posDiag[r + c] = true;
            negDiag[r - c + n] = true;
            board[r][c] = 'Q';

            Backtrack(r + 1, n);

            col[c] = false;
            posDiag[r + c] = false;
            negDiag[r - c + n] = false;
            board[r][c] = '.';
        }
    }
}