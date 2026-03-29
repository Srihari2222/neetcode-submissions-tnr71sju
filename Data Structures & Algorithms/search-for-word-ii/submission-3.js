class Solution {
    /**
     * @param {character[][]} board
     * @param {string[]} words
     * @return {string[]}
     */
    findWords(board, words) {
        const ROWS = board.length, COLS = board[0].length;
        const res = [];

        const backtrack = (r, c, word, i) => {
            if (i === word.length) return true;
            if (r < 0 || c < 0 || r >= ROWS || c >= COLS || board[r][c] !== word[i]) return false;

            const temp = board[r][c];
            board[r][c] = '*';
            const ret = backtrack(r + 1, c, word, i + 1) ||
                        backtrack(r - 1, c, word, i + 1) ||
                        backtrack(r, c + 1, word, i + 1) ||
                        backtrack(r, c - 1, word, i + 1);
            board[r][c] = temp;
            return ret;
        };

        for (const word of words) {
            let flag = false;
            for (let r = 0; r < ROWS; r++) {
                if (flag) break;
                for (let c = 0; c < COLS; c++) {
                    if (board[r][c] !== word[0]) continue;
                    if (backtrack(r, c, word, 0)) {
                        res.push(word);
                        flag = true;
                        break;
                    }
                }
            }
        }
        return res;
    }
}
