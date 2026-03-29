class Solution {
public:
    bool isAnagram(string s, string t) {
        vector<int> table(26, 0);
        for (char &ch : s) {
            table[ch]++;
        }
        bool ss = true;
        for (char &ch : t) {
            if (ss)cout<<s<<endl;
            if(table[ch] == 0) return false;
            table[ch]--;
            ss=false;
        }
        return true;
    }
};
