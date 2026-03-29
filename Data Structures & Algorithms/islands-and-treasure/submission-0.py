class Solution:
    def islandsAndTreasure(self, grid: List[List[int]]) -> None:
        ROWS, COLS = len(grid), len(grid[0])
        directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]
        INF = 2147483647

        def dfs(r, c, visit):
            if (r < 0 or c < 0 or r >= ROWS or
                c >= COLS or grid[r][c] == -1 or
                (r, c) in visit
            ):
                return INF
            if grid[r][c] == 0:
                return 0

            visit.add((r, c))
            res = INF
            for dx, dy in directions:
                res = min(res, 1 + dfs(r + dx, c + dy, visit))
            return res

        for r in range(ROWS):
            for c in range(COLS):
                visit = set()
                if grid[r][c] == INF:
                    grid[r][c] = dfs(r, c, visit)