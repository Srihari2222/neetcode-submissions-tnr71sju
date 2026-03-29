public class Solution {
    public double findMedianSortedArrays(int[] n1, int[] n2) {
        int len1 = n1.length, len2 = n2.length;
        int[] merged = new int[len1 + len2];
        System.arraycopy(n1, 0, merged, 0, len1);
        System.arraycopy(n2, 0, merged, len1, len2);
        Arrays.sort(merged);
        
        int totalLen = merged.length;
        if (totalLen % 2 == 0) {
            return (merged[totalLen / 2 - 1] + merged[totalLen / 2]) / 2.0;
        } else {
            return merged[totalLen / 2];
        }
    }
}