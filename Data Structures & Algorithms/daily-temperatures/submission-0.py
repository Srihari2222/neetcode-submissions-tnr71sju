class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        n = len(temperatures)
        res = []

        for i in range(n):
            count = 1
            for j in range(i + 1, n):
                if temperatures[j] > temperatures[i]:
                    break
                count += 1
            count = 0 if (n - i) == count else count
            res.append(count)
        return res