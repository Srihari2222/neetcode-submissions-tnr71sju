public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord) || beginWord == endWord) {
            return 0;
        }
        
        int n = wordList.Count;
        int m = wordList[0].Length;
        List<List<int>> adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        
        Dictionary<string, int> mp = new Dictionary<string, int>();
        for (int i = 0; i < n; i++) {
            mp[wordList[i]] = i;
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int cnt = 0;
                for (int k = 0; k < m; k++) {
                    if (wordList[i][k] != wordList[j][k]) {
                        cnt++;
                    }
                }
                if (cnt == 1) {
                    adj[i].Add(j);
                    adj[j].Add(i);
                }
            }
        }

        Queue<int> q = new Queue<int>();
        int res = 1;
        HashSet<int> visit = new HashSet<int>();
        
        for (int i = 0; i < m; i++) {
            for (char c = 'a'; c <= 'z'; c++) {
                if (c == beginWord[i]) {
                    continue;
                }
                string word = beginWord.Substring(0, i) + c + 
                              beginWord.Substring(i + 1);
                if (mp.ContainsKey(word) && !visit.Contains(mp[word])) {
                    q.Enqueue(mp[word]);
                    visit.Add(mp[word]);
                }
            }
        }

        while (q.Count > 0) {
            res++;
            int size = q.Count;
            for (int i = 0; i < size; i++) {
                int node = q.Dequeue();
                if (wordList[node] == endWord) {
                    return res;
                }
                foreach (int nei in adj[node]) {
                    if (!visit.Contains(nei)) {
                        visit.Add(nei);
                        q.Enqueue(nei);
                    }
                }
            }
        }
        
        return 0;
    }
}