public class Solution {
    public bool CheckValidString(string s) {
        Stack<int> left = new Stack<int>();
        Stack<int> star = new Stack<int>();
        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];
            if (ch == '(') {
                left.Push(i);
            } else if (ch == '*') {
                star.Push(i);
            } else {
                if (left.Count == 0 && star.Count == 0) return false;
                if (left.Count > 0) {
                    left.Pop();
                } else {
                    star.Pop();
                }
            }
        }
        
        while (left.Count > 0 && star.Count > 0) {
            if (left.Pop() > star.Pop()) return false;
        }
        return left.Count == 0;
    }
}