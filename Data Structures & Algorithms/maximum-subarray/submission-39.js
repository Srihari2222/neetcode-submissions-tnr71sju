class Solution {
    /**
     * @param {number[]} nums
     * @return {number}
     */
    maxSubArray(nums) {
        const dfs = (l, r) => {
            if (l > r) {
                return -Infinity;
            }
            let m = (l + r) >> 1;
            let leftSum = 0, rightSum = 0, curSum = 0;
            for (let i = m - 1; i >= l; i--) {
                curSum += nums[i];
                leftSum = Math.max(leftSum, curSum);
            }

            curSum = 0;
            for (let i = m + 1; i <= r; i++) {
                curSum += nums[i];
                rightSum = Math.max(rightSum, curSum);
            }
            return Math.max(dfs(l, m - 1), 
                        Math.max(dfs(m + 1, r), 
                            leftSum + nums[m] + rightSum));
        }
    }
}