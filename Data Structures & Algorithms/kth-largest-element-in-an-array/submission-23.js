class Solution {
    /**
     * @param {number[]} nums
     * @param {number} k
     * @return {number}
     */
    findKthLargest(nums, k) {
        k = nums.length - k;
        let left = 0;
        let right = nums.length - 1;
        while (left < right) {
            const pivot = this.partition(nums, left, right);
            if (pivot < k) left = pivot + 1;
            else if (pivot > k) right = pivot - 1;
            else break;
        }
        return nums[k];
    }

    /**
     * @param {number[]} nums
     * @param {number} left
     * @param {number} right
     * @return {number}
     */
    partition(nums, left, right) {
        const pivot = nums[right];
        let fill = left;
        for (let i = left; i < right; i++) {
            if (nums[i] <= pivot) {
                [nums[fill], nums[i]] = [nums[i], nums[fill]];
                fill++;
            }
        }
        [nums[right], nums[fill]] = [nums[fill], nums[right]];
        return fill;
    }
}