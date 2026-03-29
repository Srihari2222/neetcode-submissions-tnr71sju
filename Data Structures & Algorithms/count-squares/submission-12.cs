public class CountSquares {
    private Dictionary<int, Dictionary<int, int>> ptsCount;

    public CountSquares() {
        ptsCount = new Dictionary<int, Dictionary<int, int>>();
    }

    public void Add(int[] point) {
        int x = point[0], y = point[1];
        if (!ptsCount.ContainsKey(x)) {
            ptsCount[x] = new Dictionary<int, int>();
        }
        if (!ptsCount[x].ContainsKey(y)) ptsCount[x][y] = 0;
        ptsCount[x][y]++;
    }

    public int Count(int[] point) {
        int res = 0;
        int x1 = point[0], y1 = point[1];

        if (!ptsCount.ContainsKey(x1)) return res;

        foreach (var kv in ptsCount[x1]) {
            int y2 = kv.Key, cnt = kv.Value;
            int side = y2 - y1;
            if (side == 0) continue;

            int x3 = x1 + side, x4 = x1 - side;

            res += cnt *
                   (ptsCount.ContainsKey(x3) && ptsCount[x3].ContainsKey(y1) ? ptsCount[x3][y1] : 0) *
                   (ptsCount.ContainsKey(x3) && ptsCount[x3].ContainsKey(y2) ? ptsCount[x3][y2] : 0);

            res += cnt *
                   (ptsCount.ContainsKey(x4) && ptsCount[x4].ContainsKey(y1) ? ptsCount[x4][y1] : 0) *
                   (ptsCount.ContainsKey(x4) && ptsCount[x4].ContainsKey(y2) ? ptsCount[x4][y2] : 0);
        }

        return res;
    }
}