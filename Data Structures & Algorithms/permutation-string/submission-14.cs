public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        char[] s1Arr = s1.ToCharArray();
        Array.Sort(s1Arr);
        string sortedS1 = new string(s1Arr);

        for (int i = 0; i < s2.Length; i++) {
            for (int j = i; j < s2.Length; j++) {
                char[] subStrArr = s2.Substring(i, j - i + 1).ToCharArray();
                Array.Sort(subStrArr);
                string sortedSubStr = new string(subStrArr);

                if (sortedSubStr == sortedS1) {
                    return true;
                }
            }
        }
        return false;
    }
}