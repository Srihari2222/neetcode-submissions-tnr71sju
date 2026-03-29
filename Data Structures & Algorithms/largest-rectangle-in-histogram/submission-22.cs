public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        int[] leftMost = new int[n];
        int[] rightMost = new int[n];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++) {
            leftMost[i] = -1;
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) {
                stack.Pop();
            }
            if (stack.Count > 0) {
                leftMost[i] = stack.Peek();
            }
            stack.Push(i);
        }

        stack.Clear();
        for (int i = n - 1; i >= 0; i--) {
            rightMost[i] = n;
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) {
                stack.Pop();
            }
            if (stack.Count > 0) {
                rightMost[i] = stack.Peek();
            }
            stack.Push(i);
        }

        int maxArea = 0;
        for (int i = 0; i < n; i++) {
            leftMost[i] += 1;
            rightMost[i] -= 1;
            maxArea = Math.Max(maxArea, heights[i] * (rightMost[i] - leftMost[i] + 1));
        }

        return maxArea;
    }
}