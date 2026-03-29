public class Solution {
    int col = 0, posDiag = 0, negDiag = 0;
    List<List<string>> res;
    char[][] board;

    public List<List<string>> SolveNQueens(int n) {
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
            if ((col & (1 << c)) > 0 || (posDiag & (1 << (r + c))) > 0
                 || (negDiag & (1 << (r - c + n))) > 0) {
                continue;
            }
            col ^= (1 << c);
            posDiag ^= (1 << (r + c));
            negDiag ^= (1 << (r - c + n));
            board[r][c] = 'Q';

            Backtrack(r + 1, n);

            col ^= (1 << c);
            posDiag ^= (1 << (r + c));
            negDiag ^= (1 << (r - c + n));
            board[r][c] = '.';
        }
    }
}