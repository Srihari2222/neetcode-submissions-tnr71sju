public class Solution {
    public int Trap(int[] height) {
        if (height.Length == 0) {
            return 0;
        }

        Stack<int> stack = new Stack<int>();
        int res = 0;

        for (int i = 0; i < height.Length; i++) {
            while (stack.Count > 0 && height[i] >= height[stack.Peek()]) {
                int mid = height[stack.Pop()];
                if (stack.Count > 0) {
                    int right = height[i];
                    int left = height[stack.Peek()];
                    int h = Math.Min(right, left) - mid;
                    int w = i - stack.Peek() - 1;
                    res += h * w;
                }
            }
            stack.Push(i);
        }
        return res;
    }
}