class Solution {
public:
    bool isValid(string s) {
        if (s[0] == ')' || s[0] == '}' || s[0] == ']') {
return false;;
}

    for (int i = 0; i < s.size(); i++) {
        if (s[i] == ')' || s[i] == '}' || s[i] == ']') {
            continue;
        }
        int idxToReach = i + 1;
        int index = i + 1;
        if (s[i] == '(') {
            while (idxToReach < s.size()) {
            if (s[index] == ')' && index == idxToReach) {
                break;
            }  else if (s[index] == '(' || s[index] == '{' || s[index] == '[') {
                idxToReach += 2;
            } else if (s[index] != ')' && index == idxToReach) {
                return false;
            }
            index++;
            }
        } else if (s[i] == '[') {
            while (idxToReach < s.size()) {
            if (s[index] == ']' && index == idxToReach) {
                break;
            }  else if (s[index] == '(' || s[index] == '{' || s[index] == '[') {
                idxToReach += 2;
            } else if (s[index] != ']' && index == idxToReach) {
                return false;
            }
            index++;
            }
        } else if (s[i] == '{') {
            while (idxToReach < s.size()) {
            if (s[index] == '}' && index == idxToReach) {
                break;
            }  else if (s[index] == '(' || s[index] == '{' || s[index] == '[') {
                idxToReach += 2;
            } else if (s[index] != '}' && index == idxToReach) {
                return false;
            }
            index++;
            }
        } 
        if (idxToReach >= s.size()) {
            return false;
        }
    }
    return true;
}
};