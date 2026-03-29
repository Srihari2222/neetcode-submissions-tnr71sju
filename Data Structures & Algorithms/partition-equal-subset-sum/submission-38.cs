public class Solution {
    public bool CanPartition(int[] nums) {
        if (Sum(nums) % 2 != 0) {
            return false;
        }

        int target = Sum(nums) / 2;
        bool[] dp = new bool[target + 1];
        bool[] nextDp = new bool[target + 1];

        dp[0] = true;
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 1; j <= target; j++) {
                if (j >= nums[i]) {
                    nextDp[j] = dp[j] || dp[j - nums[i]];
                } else {
                    nextDp[j] = dp[j];
                }
            }
            bool[] temp = dp;
            dp = nextDp;
            nextDp = temp;
        }
        
        return dp[target];
    }

    private int Sum(int[] nums) {
        int total = 0;
        foreach (var num in nums) {
            total += num;
        }
        return total;
    }
}