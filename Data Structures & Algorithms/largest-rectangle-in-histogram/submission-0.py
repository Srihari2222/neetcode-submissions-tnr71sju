class Solution:
    def largestRectangleArea(self, heights: List[int]) -> int:
        n = len(heights)
        maxArea = 0

        for i in range(n):
            maxArea = max(maxArea, 1 * heights[i])

            minHeight = heights[i]
            for j in range(i + 1, n):
                minHeight = min(minHeight, heights[j])
                maxArea = max(maxArea, minHeight * (j - i + 1))
        return maxArea
