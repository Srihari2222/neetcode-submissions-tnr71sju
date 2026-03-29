class Solution {
public:
    bool canJump(std::vector<int>& nums) {
        std::unordered_map<int, bool> memo;
        return dfs(nums, 0, memo);
    }

private:
    bool dfs(std::vector<int>& nums, int i, std::unordered_map<int, bool>& memo) {
        if (memo.count(i)) {
            return memo[i];
        }
        if (i >= nums.size() - 1) {
            return true;
        }
        if (nums[i] == 0) {
            return false;
        }
        
        int end = std::min((int)nums.size(), i + nums[i] + 1);
        for (int j = i + 1; j < end; j++) {
            if (dfs(nums, j, memo)) {
                memo[i] = true;
                return true;
            }
        }
        memo[i] = false;
        return false;
    }
};