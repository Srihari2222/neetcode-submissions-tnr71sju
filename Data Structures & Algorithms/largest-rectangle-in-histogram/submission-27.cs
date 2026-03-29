public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int maxArea = 0;
        Stack<int[]> stack = new Stack<int[]>(); // pair: (index, height)

        for (int i = 0; i < heights.Length; i++) {
            int start = i;
            while (stack.Count > 0 && stack.Peek()[1] > heights[i]) {
                int[] top = stack.Pop();
                int index = top[0];
                int height = top[1];
                maxArea = Math.Max(maxArea, height * (i - index));
                start = index;
            }
            stack.Push(new int[] { start, heights[i] });
        }

        foreach (int[] pair in stack) {
            int index = pair[0];
            int height = pair[1];
            maxArea = Math.Max(maxArea, height * (heights.Length - index));
        }
        return maxArea;
    }
}