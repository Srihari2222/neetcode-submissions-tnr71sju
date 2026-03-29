class Solution {
public:
    bool isValid(string s) {
        while (s.find("()") != string::npos || s.find("{}") != string::npos || s.find("[]") != string::npos) {
            s = s.erase(s.find("()"), 2);
            s = s.erase(s.find("{}"), 2);
            s = s.erase(s.find("[]"), 2);
        }
        return s.empty();
    }
};