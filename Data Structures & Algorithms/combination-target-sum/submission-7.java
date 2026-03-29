public class Solution {
    public List<List<Integer>> combinationSum(int[] nums, int target) {
        List<List<Integer>> res = new ArrayList<>();
        Arrays.sort(nums);
        
        dfs(0, new ArrayList<>(), 0, nums, target, res);
        return res;
    }

    private void dfs(int i, List<Integer> cur, int total, int[] nums, int target, List<List<Integer>> res) {
        if (total == target) {
            res.add(new ArrayList<>(cur));
            return;
        }
        
        for (int j = i; j < nums.length; j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.add(nums[j]);
            dfs(j, cur, total + nums[j], nums, target, res);
            cur.remove(cur.size() - 1);
        }
    }
}