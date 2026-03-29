class Solution {
public:
    bool isValid(string s) {
        while (true) {
            size_t pos = s.find_first_of("(){}[]");
            if (pos == string::npos) break;
            if ((s.substr(pos, 2) == "()") 
                || (s.substr(pos, 2) == "{}") 
                || (s.substr(pos, 2) == "[]")) 
            {
                s.erase(pos, 2);
                continue;
            }
            break;
        }
        return s.empty();
    }
};