public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (text1.Length < text2.Length) {
            string temp = text1;
            text1 = text2;
            text2 = temp;
        }

        int[] prev = new int[text2.Length + 1];
        int[] curr = new int[text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--) {
            for (int j = text2.Length - 1; j >= 0; j--) {
                if (text1[i] == text2[j]) {
                    curr[j] = 1 + prev[j + 1];
                } else {
                    curr[j] = Math.Max(curr[j + 1], prev[j]);
                }
            }
            Array.Copy(curr, prev, text2.Length + 1);
        }

        return prev[0];
    }
}