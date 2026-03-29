public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var words = new HashSet<string>(wordList);
        if (!words.Contains(endWord) || beginWord == endWord) return 0;
        int res = 0;
        var q = new Queue<string>();
        q.Enqueue(beginWord);
        
        while (q.Count > 0) {
            res++;
            int len = q.Count;
            for (int i = 0; i < len; i++) {
                string node = q.Dequeue();
                if (node == endWord) return res;
                char[] arr = node.ToCharArray();
                for (int j = 0; j < arr.Length; j++) {
                    char original = arr[j];
                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == original) continue;
                        arr[j] = c;
                        string nei = new string(arr);
                        if (words.Contains(nei)) {
                            q.Enqueue(nei);
                            words.Remove(nei);
                        }
                    }
                    arr[j] = original;
                }
            }
        }
        return 0;
    }
}