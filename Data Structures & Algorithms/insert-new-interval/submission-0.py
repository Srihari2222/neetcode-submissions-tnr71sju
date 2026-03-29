from bisect import bisect_left, bisect_right
class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        n = len(intervals)
        res = []
        
        start = bisect_left([interval[1] for interval in intervals], newInterval[0])
        res.extend(intervals[:start])
        
        while start < n and newInterval[1] >= intervals[start][0]:
            newInterval[0] = min(newInterval[0], intervals[start][0])
            newInterval[1] = max(newInterval[1], intervals[start][1])
            start += 1
        res.append(newInterval)
        res.extend(intervals[start:])
        return res