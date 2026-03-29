class Solution {
public:
    bool wordBreak(string s, vector<string>& wordDict) {
        unordered_set<string> wordSet(wordDict.begin(), wordDict.end());
        return dfs(s, wordSet, 0);
    }

    bool dfs(const string& s, const unordered_set<string>& wordSet, int i) {
        if (i == s.size()) {
            return true;
        }

        for (int j = i; j < s.size(); j++) {
            if (wordSet.find(s.substr(i, j - i + 1)) != wordSet.end()) {
                if (dfs(s, wordSet, j + 1)) {
                    return true;
                }
            }
        }
        return false;
    }
};