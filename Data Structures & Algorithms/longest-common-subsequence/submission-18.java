public class Solution {
    public int longestCommonSubsequence(String text1, String text2) {
        if (text1.length() < text2.length()) {
            String temp = text1;
            text1 = text2;
            text2 = temp;
        }

        int[] prev = new int[text2.length() + 1];
        int[] curr = new int[text2.length() + 1];

        for (int i = text1.length() - 1; i >= 0; i--) {
            for (int j = text2.length() - 1; j >= 0; j--) {
                if (text1.charAt(i) == text2.charAt(j)) {
                    curr[j] = 1 + prev[j + 1];
                } else {
                    curr[j] = Math.max(curr[j + 1], prev[j]);
                }
            }
            int[] temp = prev;
            prev = curr;
            curr = temp;
        }

        return prev[0];
    }
}