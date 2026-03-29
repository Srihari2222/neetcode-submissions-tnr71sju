public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
        int n = nums.Length;
        Dictionary<int, int>[] dp = new Dictionary<int, int>[n + 1];
        for (int i = 0; i <= n; i++) {
            dp[i] = new Dictionary<int, int>();
        }
        dp[0][0] = 1;

        for (int i = 0; i < n; i++) {
            foreach (var entry in dp[i]) {
                int total = entry.Key;
                int count = entry.Value;
                if (!dp[i + 1].ContainsKey(total + nums[i])) {
                    dp[i + 1][total + nums[i]] = 0;
                }
                dp[i + 1][total + nums[i]] += count;

                if (!dp[i + 1].ContainsKey(total - nums[i])) {
                    dp[i + 1][total - nums[i]] = 0;
                }
                dp[i + 1][total - nums[i]] += count;
            }
        }
        return dp[n].ContainsKey(S) ? dp[n][S] : 0;
    }
}