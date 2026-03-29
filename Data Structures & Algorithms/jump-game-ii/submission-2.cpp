class Solution {
public:
    int jump(vector<int>& nums) {
        return dfs(nums, 0);
    }

private:
    int dfs(vector<int>& nums, int i) {
        if (i == nums.size() - 1) {
            return 0;
        }
        if (nums[i] == 0) return 1000000;
        int res = 1000000;
        int end = min((int)nums.size() - 1, i + nums[i]);
        for (int j = i + 1; j <= end; ++j) {
            res = min(res, 1 + dfs(nums, j));
        }
        return res;
    }
};