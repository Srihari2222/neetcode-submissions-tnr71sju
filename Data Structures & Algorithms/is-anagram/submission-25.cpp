class Solution {
public:
    bool isAnagram(string s, string t) {
        vector<int> table(26, 0);
        for (char &ch : s) {
            table[ch]++;
        }
        cout<<s<<endl;
        for (char &ch : t) {
            if(table[ch] == 0) return false;
            table[ch]--;
        }
        return true;
    }
};
