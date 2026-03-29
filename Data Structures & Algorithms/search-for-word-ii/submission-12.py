class TrieNode:
    def __init__(self):
        self.children = {}
        self.isWord = False
        self.refs = 0
        self.idx = -1

    def addWord(self, word, i):
        cur = self
        cur.refs += 1
        for c in word:
            if c not in cur.children:
                cur.children[c] = TrieNode()
            cur = cur.children[c]
            cur.refs += 1
        cur.isWord = True
        cur.idx = i

class Solution:
    def findWords(self, board: List[List[str]], words: List[str]) -> List[str]:
        root = TrieNode()
        for i in range(len(words)):
            root.addWord(words[i], i)

        ROWS, COLS = len(board), len(board[0])
        res = []

        def dfs(r, c, node):
            if (r < 0 or c < 0 or r >= ROWS or 
                c >= COLS or board[r][c] == "*" or 
                board[r][c] not in node.children
            ):
                return
            
            tmp = board[r][c]
            node = node.children[board[r][c]]
            board[r][c] = "*"
            if node.isWord:
                res.append(words[node.idx])
                node.isWord = False
                node.idx = -1
                node.refs -= 1
                if not node.refs:
                    node = None
                    board[r][c] = tmp
                    return

            dfs(r + 1, c, node)
            dfs(r - 1, c, node)
            dfs(r, c + 1, node)
            dfs(r, c - 1, node)

            board[r][c] = tmp

        for r in range(ROWS):
            for c in range(COLS):
                dfs(r, c, root)

        return res