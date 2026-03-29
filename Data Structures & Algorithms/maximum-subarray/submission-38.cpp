class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        return dfs(nums, 0, nums.size() - 1);
    }

private:
    int dfs(std::vector<int>& nums, int l, int r) {
        if (l > r) {
            return INT_MIN;
        }
        int m = (l + r) >> 1;
        int leftSum = 0, rightSum = 0, curSum = 0;
        for (int i = m - 1; i >= l; --i) {
            curSum += nums[i];
            leftSum = max(leftSum, curSum);
        }
        curSum = 0;
        for (int i = m + 1; i <= r; ++i) {
            curSum += nums[i];
            rightSum = max(rightSum, curSum);
        }
        return max(dfs(nums, l, m - 1), 
                   max(dfs(nums, m + 1, r), 
                       leftSum + nums[m] + rightSum));
    }
};