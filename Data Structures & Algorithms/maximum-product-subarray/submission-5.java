public class Solution {
    public int maxProduct(List<Integer> nums) {
        int res = nums.get(0);

        for (int i = 0; i < nums.size(); i++) {
            int cur = nums.get(i);
            res = Math.max(res, cur);
            for (int j = i + 1; j < nums.size(); j++) {
                cur *= nums.get(j);
                res = Math.max(res, cur);
            }
        }
        
        return res;
    }
}