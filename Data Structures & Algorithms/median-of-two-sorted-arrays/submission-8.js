class Solution {
    /**
     * @param {number[]} nums1
     * @param {number[]} nums2
     * @return {number}
     */
    findMedianSortedArrays(nums1, nums2) {
        const len1 = nums1.length;
        const len2 = nums2.length;
        const merged = nums1.concat(nums2);
        merged.sort((a, b) => a - b);
        
        const totalLen = merged.length;
        if (totalLen % 2 === 0) {
            return (merged[totalLen / 2 - 1] + merged[totalLen / 2]) / 2.0;
        } else {
            return merged[Math.floor(totalLen / 2)];
        }
    }
}