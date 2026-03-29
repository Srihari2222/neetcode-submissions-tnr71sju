public class Solution {
    public int MaxProduct(List<int> nums) {
        int res = nums[0];

        for (int i = 0; i < nums.Count; i++) {
            int cur = nums[i];
            res = Math.Max(res, cur);
            for (int j = i + 1; j < nums.Count; j++) {
                cur *= nums[j];
                res = Math.Max(res, cur);
            }
        }
        
        return res;
    }
}