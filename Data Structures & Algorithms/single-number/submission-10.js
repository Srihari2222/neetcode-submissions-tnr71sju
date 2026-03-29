class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    singleNumber(nums) {
        const seen = new Set();
        for (const num of nums) {
            if (seen.has(num)) {
                seen.delete(num);
            } else {
                seen.add(num);
            }
        }
        return Array.from(seen)[0];
    }
}