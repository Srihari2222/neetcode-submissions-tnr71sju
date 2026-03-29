class Solution:
    def putMarbles(self, weights: List[int], k: int) -> int:
        n = len(weights)
        cache = {}

        def dfs(i, k):
            if (i, k) in cache:
                return cache[(i, k)]
            if k == 0:
                return [0, 0]
            if i == n - 1 or n - i - 1 < k:
                return [-float("inf"), float("inf")]

            res = [0, float("inf")]  # [maxScore, minScore]

            # make partition
            cur = dfs(i + 1, k - 1)
            res[0] = max(res[0], weights[i] + weights[i + 1] + cur[0])
            res[1] = min(res[1], weights[i] + weights[i + 1] + cur[1])

            # skip
            cur = dfs(i + 1, k)
            res[0] = max(res[0], cur[0])
            res[1] = min(res[1], cur[1])

            cache[(i, k)] = res
            return res

        ans = dfs(0, k - 1)
        return ans[0] - ans[1]