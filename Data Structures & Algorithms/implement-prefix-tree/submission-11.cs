public class TrieNode {
    public TrieNode[] children = new TrieNode[26];
    public bool endOfWord = false;
}

public class PrefixTree {
    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
    }

    public void Insert(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                cur.children[i] = new TrieNode();
            }
            cur = cur.children[i];
        }
        cur.endOfWord = true;
    }

    public bool Search(string word) {
        TrieNode cur = root;
        foreach (char c in word) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                return false;
            }
            cur = cur.children[i];
        }
        return cur.endOfWord;
    }

    public bool StartsWith(string prefix) {
        TrieNode cur = root;
        foreach (char c in prefix) {
            int i = c - 'a';
            if (cur.children[i] == null) {
                return false;
            }
            cur = cur.children[i];
        }
        return true;
    }
}