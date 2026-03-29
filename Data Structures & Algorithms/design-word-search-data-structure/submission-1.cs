public class WordDictionary {

    private List<string> store;

    public WordDictionary() {
        store = new List<string>();
    }

    public void AddWord(string word) {
        store.Add(word);
    }

    public bool Search(string word) {
        foreach (string w in store) {
            if (w.Length != word.Length) continue;
            int i = 0;
            while (i < w.Length) {
                if (w[i] == word[i] || word[i] == '.') {
                    i++;
                } else {
                    break;
                }
            }
            if (i == w.Length) {
                return true;
            }
        }
        return false;
    }
}