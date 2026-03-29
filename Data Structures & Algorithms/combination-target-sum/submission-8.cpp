class Solution {
public:
    vector<vector<int>> combinationSum(vector<int>& nums, int target) {
        vector<std::vector<int>> res;
        sort(nums.begin(), nums.end());
        dfs(0, {}, 0, nums, target, res);
        return res;
    }

    void dfs(int i, vector<int> cur, int total, vector<int>& nums, int target, vector<vector<int>>& res) {
        if (total == target) {
            res.push_back(cur);
            return;
        }
        
        for (int j = i; j < nums.size(); j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.push_back(nums[j]);
            dfs(j, cur, total + nums[j], nums, target, res);
            cur.pop_back();
        }
    }
};