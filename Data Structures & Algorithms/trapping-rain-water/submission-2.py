class Solution:
    def trap(self, height: List[int]) -> int:
        if not height:
            return 0
        stack = [0]
        res = 0

        for i in range(len(height)):
            while stack and height[i] >= height[stack[-1]]:
                mid_height = height[stack.pop()]
                if stack:
                    right = height[i]
                    left = height[stack[-1]]
                    h = min(right, left) - mid_height
                    w = i - stack[-1] - 1
                    res += h * w
            stack.append(i)
        return res

