public class Solution {
    public int jump(int[] nums) {
        Map<Integer, Integer> memo = new HashMap<>();
        return dfs(nums, 0, memo);
    }

    private int dfs(int[] nums, int i, Map<Integer, Integer> memo) {
        if (memo.containsKey(i)) {
            return memo.get(i);
        }
        if (i == nums.length - 1) {
            return 0;
        }
        if (nums[i] == 0) {
            return 1000000;
        }
        
        int res = 1000000;
        int end = Math.min(nums.length, i + nums[i] + 1);
        for (int j = i + 1; j < end; j++) {
            res = Math.min(res, 1 + dfs(nums, j, memo));
        }
        memo.put(i, res);
        return res;
    }
}