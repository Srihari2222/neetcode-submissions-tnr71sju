from typing import List

class Solution:
    def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
        intervals.sort()  # Sort by end time
        n = len(intervals)
        memo = {}

        def dfs(i):
            if i in memo:
                return memo[i]

            # The count of non-overlapping intervals starting from this interval
            count = 1
            
            for j in range(i + 1, n):
                if intervals[i][1] <= intervals[j][0]:  # No overlap
                    count = max(count, 1 + dfs(j))  # Explore next valid interval

            memo[i] = count
            return count

        # Start from the first interval
        max_non_overlapping = dfs(0)

        return n - max_non_overlapping  # Total intervals minus the max found