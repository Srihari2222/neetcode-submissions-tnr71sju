class CountSquares:

    def __init__(self):
        self.pts_count = defaultdict(int)

    def add(self, point: List[int]) -> None:
        self.pts_count[tuple(point)] += 1

    def count(self, point: List[int]) -> int:
        px, py = point
        res = 0
        for key, cnt in self.pts_count.items():
            x, y = key
            if px == x and py == y:
                continue

            if abs(px - x) == abs(py - y):
                p0, p1 = (x, py), (px, y)
                res += cnt * self.pts_count.get(p0, 0) * self.pts_count.get(p1, 0) # here 
        
        return res
