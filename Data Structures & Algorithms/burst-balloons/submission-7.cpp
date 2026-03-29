class Solution {
public:
    int maxCoins(vector<int>& nums) {
        int n = nums.size();
        vector<int> newNums(n + 2, 1);
        for (int i = 0; i < n; i++) {
            newNums[i + 1] = nums[i];
        }

        return dfs(newNums, 1, newNums.size() - 2);
    }

    int dfs(vector<int>& nums, int l, int r) {
        if (l > r) return 0;

        int maxCoins = 0;
        for (int i = l; i <= r; i++) {
            int coins = nums[l - 1] * nums[i] * nums[r + 1];
            coins += dfs(nums, l, i - 1) + dfs(nums, i + 1, r);
            maxCoins = max(maxCoins, coins);
        }
        return maxCoins;
    }
};