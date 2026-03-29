public class WordDictionary {

    private List<String> store;

    public WordDictionary() {
        store = new ArrayList<>();
    }

    public void addWord(String word) {
        store.add(word);
    }

    public boolean search(String word) {
        for (String w : store) {
            if (w.length() != word.length()) continue;
            int i = 0;
            while (i < w.length()) {
                if (w.charAt(i) == word.charAt(i) || 
                    word.charAt(i) == '.') {
                    i++;
                } else {
                    break;
                }
            }
            if (i == w.length()) {
                return true;
            }
        }
        return false;
    }
}