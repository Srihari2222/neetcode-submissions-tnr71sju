public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        int[] merged = new int[len1 + len2];
        Array.Copy(nums1, merged, len1);
        Array.Copy(nums2, 0, merged, len1, len2);
        Array.Sort(merged);
        
        int totalLen = merged.Length;
        if (totalLen % 2 == 0) {
            return (merged[totalLen / 2 - 1] + merged[totalLen / 2]) / 2.0;
        } else {
            return merged[totalLen / 2];
        }
    }
}