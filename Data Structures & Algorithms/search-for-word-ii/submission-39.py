class TrieNode:

    def __init__(self):
        self.children = {}
        self.isWord = False
        self.fullWord = ""

class Solution:

    def __init__(self):
        self.root = TrieNode()

    def findWords(self, board: List[List[str]], words: List[str]) -> List[str]:
        res = []
        self.addWords(words)
        for i in range(len(board)):
            for j in range(len(board[0])):
                if board[i][j] in self.root.children:
                    self.findWord(board, res, i, j, self.root)
        return res

    def findWord(self, board, res, i, j, curr):
        if curr.isWord:
            curr.isWord = False
            res.append(curr.fullWord)
            return
        if i < 0 or i >= len(board) or j < 0 or j >= len(board[0]) or board[i][j] not in curr.children:
            return
        temp = board[i][j]
        board[i][j] = "*"
        self.findWord(board, res, i + 1, j, curr.children[temp])
        self.findWord(board, res, i - 1, j, curr.children[temp])
        self.findWord(board, res, i, j + 1, curr.children[temp])
        self.findWord(board, res, i, j - 1, curr.children[temp])
        board[i][j] = temp


    def addWords(self, words):
        for word in words:
            curr = self.root
            for w in word:
                if w not in curr.children:
                    curr.children[w] = TrieNode()
                curr = curr.children[w]
            curr.isWord = True
            curr.fullWord = word