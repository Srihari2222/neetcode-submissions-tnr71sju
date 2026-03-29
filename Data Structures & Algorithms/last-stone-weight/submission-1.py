class Solution:
    def lastStoneWeight(self, stones: List[int]) -> int:
        bucket = [0] * 1001
        
        maxStone = 0
        for stone in stones:
            bucket[stone] += 1
            maxStone = max(maxStone, stone)
        
        i = maxStone
        while i > 0:
            if bucket[i] % 2 == 0:
                i -= 1
                continue
            first = i
            i -= 1

            while i > 0 and bucket[i] == 0:
                i -= 1
            
            if i == 0:
                return first
            second = i
            bucket[i] -= 1
            bucket[first - second] += 1
        return i