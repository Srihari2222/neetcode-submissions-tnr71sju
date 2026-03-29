class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        return dfs(nums, 0, false);
    }

private:
    int dfs(vector<int>& nums, int i, bool flag) {
        if (i == nums.size()) return flag ? 0 : -1e6;
        if (flag) return max(0, nums[i] + dfs(nums, i + 1, true));
        return max(dfs(nums, i + 1, false), nums[i] + dfs(nums, i + 1, true));
    }
};