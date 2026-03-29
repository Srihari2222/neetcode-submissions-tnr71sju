public class Solution {
    public int MaxArea(int[] heights) {
        int res = 0;
        for (int i = 0; i < heights.Length; i++) {
            for (int j = i + 1; j < heights.Length; j++) {
                res = Math.Max(res, Math.Min(heights[i], heights[j]) * (j - i));
            }
        }
        return res;
    }
}