public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        int ROWS = board.Length, COLS = board[0].Length;
        List<string> res = new List<string>();

        foreach (string word in words) {
            bool flag = false;
            for (int r = 0; r < ROWS && !flag; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (board[r][c] != word[0]) continue;
                    if (Backtrack(board, r, c, word, 0)) {
                        res.Add(word);
                        flag = true;
                        break;
                    }
                }
            }
        }
        return res;
    }

    private bool Backtrack(char[][] board, int r, int c, string word, int i) {
        if (i == word.Length) return true;
        if (r < 0 || c < 0 || r >= board.Length || 
            c >= board[0].Length || board[r][c] != word[i])
            return false;

        board[r][c] = '*';
        bool ret = Backtrack(board, r + 1, c, word, i + 1) ||
                   Backtrack(board, r - 1, c, word, i + 1) ||
                   Backtrack(board, r, c + 1, word, i + 1) ||
                   Backtrack(board, r, c - 1, word, i + 1);
        board[r][c] = word[i];
        return ret;
    }
}