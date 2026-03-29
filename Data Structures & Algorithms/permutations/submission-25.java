public class Solution {
    List<List<Integer>> res = new ArrayList<>();

    public List<List<Integer>> permute(int[] nums) {
        backtrack(new ArrayList<>(), nums, 0);
        return res;
    }

    private void backtrack(List<Integer> perm, int[] nums, int mask) {
        if (perm.size() == nums.length) {
            res.add(new ArrayList<>(perm));
            return;
        }
        for (int i = 0; i < nums.length; i++) {
            if ((mask & (1 << i)) == 0) {
                perm.add(nums[i]);
                backtrack(perm, nums, mask | (1 << i));
                perm.remove(perm.size() - 1);
            }
        }
    }
}