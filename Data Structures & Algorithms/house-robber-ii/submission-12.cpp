class Solution {
public:
    int rob(vector<int>& nums) {
        if (nums.size() == 1) return nums[0];
        return max(dfs(0, true, nums), dfs(1, false, nums));
    }

private:
    int dfs(int i, bool flag, vector<int>& nums) {
        if (i >= nums.size() || (flag && i == nums.size() - 1)) 
            return 0;

        return max(dfs(i + 1, flag, nums), 
                   nums[i] + dfs(i + 2, flag || i == 0, nums));
    }
};