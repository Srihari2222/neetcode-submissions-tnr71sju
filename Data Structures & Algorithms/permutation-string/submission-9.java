public class Solution {
    public boolean checkInclusion(String s1, String s2) {
        char[] sortedS1 = s1.toCharArray();
        Arrays.sort(sortedS1);

        for (int i = 0; i <= s2.length() - s1.length(); i++) {
            String subStr = s2.substring(i, i + s1.length());
            char[] sortedSubStr = subStr.toCharArray();
            Arrays.sort(sortedSubStr);
            if (Arrays.equals(sortedS1, sortedSubStr)) {
                return true;
            }
        }
        return false;
    }
}