class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        vector<vector<int>> memo(nums.size() + 1, vector<int>(2, INT_MIN));
        return dfs(nums, 0, false, memo);
    }
    
private:
    int dfs(vector<int>& nums, int i, bool flag, vector<vector<int>>& memo) {
        if (i == nums.size()) return flag ? 0 : -1e6;
        int f = flag ? 1 : 0;
        if (memo[i][f] != INT_MIN) return memo[i][f];
        if (flag)
            memo[i][f] = max(0, nums[i] + dfs(nums, i + 1, true, memo));
        else
            memo[i][f] = max(dfs(nums, i + 1, false, memo), 
                             nums[i] + dfs(nums, i + 1, true, memo));
        return memo[i][f];
    }
};