class Solution {
public:
    vector<vector<string>> partition(string s) {
        return dfs(s, 0);
    }

    vector<vector<string>> dfs(string s, int i) {
        if (i >= s.size()) {
            return {{}};
        }

        vector<vector<string>> ret;
        for (int j = i; j < s.size(); j++) {
            if (isPali(s, i, j)) {
                auto nxt = dfs(s, j + 1);
                for (auto& part : nxt) {
                    vector<string> cur;
                    cur.push_back(s.substr(i, j - i + 1));
                    cur.insert(cur.end(), part.begin(), part.end());
                    ret.push_back(cur);
                }
            }
        }
        return ret;
    }

    bool isPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
};