class Solution {
public:
    bool checkInclusion(std::string s1, std::string s2) {
        sort(s1.begin(), s1.end());

        for (int i = 0; i <= s2.size() - s1.size(); i++) {
            string subStr = s2.substr(i, s1.size());
            sort(subStr.begin(), subStr.end());
            if (subStr == s1) {
                return true;
            }
        }
        return false;
    }
};