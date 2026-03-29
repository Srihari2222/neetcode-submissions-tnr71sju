class Solution {
public:
    int change(int amount, vector<int>& coins) {
        sort(coins.begin(), coins.end());
        return dfs(coins, 0, amount);
    }

private:
    int dfs(const vector<int>& coins, int i, int a) {
        if (a == 0) {
            return 1;
        }
        if (i >= coins.size()) {
            return 0;
        }

        int res = 0;
        if (a >= coins[i]) {
            res = dfs(coins, i + 1, a);
            res += dfs(coins, i, a - coins[i]);
        }
        return res;
    }
};