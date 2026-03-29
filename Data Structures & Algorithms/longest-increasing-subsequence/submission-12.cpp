class Solution {
public:
    int lengthOfLIS(vector<int>& nums) {
        return dfs(nums, 0, -1);
    }

private:
    int dfs(vector<int>& nums, int i, int j) {
        if (i == nums.size()) {
            return 0;
        }

        int LIS = dfs(nums, i + 1, j); // not include 

        if (j == -1 || nums[j] < nums[i]) {
            LIS = max(LIS, 1 + dfs(nums, i + 1, i)); // include
        }

        return LIS;
    }
};