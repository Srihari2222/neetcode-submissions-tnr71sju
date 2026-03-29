public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length == 0) {
            return 0;
        }
        int n = height.Length;
        int res = 0;

        for (int i = 0; i < n; i++) {
            int leftMax = height[i];
            int rightMax = height[i];

            for (int j = 0; j < i; j++) {
                leftMax = Math.Max(leftMax, height[j]);
            }
            for (int j = i + 1; j < n; j++) {
                rightMax = Math.Max(rightMax, height[j]);
            }

            res += Math.Min(leftMax, rightMax) - height[i];
        }

        return res;
    }
}