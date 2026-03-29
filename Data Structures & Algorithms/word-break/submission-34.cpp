class Solution {
public:
    unordered_set<string> wordSet;
    vector<int> memo;
    int t;

    bool wordBreak(string s, vector<string>& wordDict) {
        wordSet.insert(wordDict.begin(), wordDict.end());
        memo.resize(s.size(), -1);
        t = 0;
        for (string& w : wordDict) {
            t = max(t, int(w.length()));
        }
        return dfs(s, 0);
    }

    bool dfs(string& s, int i) {
        if (i == s.size()) {
            return true;
        }
        if (memo[i] != -1) {
            return memo[i] == 1;
        }

        for (int j = i; j < (i + t, s.size()); j++) {
            if (wordSet.count(s.substr(i, j - i + 1))) {
                if (dfs(s, j + 1)) {
                    memo[i] = 1;
                    return true;
                }
            }
        }
        memo[i] = 0;
        return false;
    }
};