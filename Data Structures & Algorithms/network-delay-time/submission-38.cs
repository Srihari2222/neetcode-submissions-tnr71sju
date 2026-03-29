public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
        dist[k - 1] = 0;

        for (int i = 0; i < n - 1; i++) {
            foreach (var time in times) {
                int u = time[0] - 1, v = time[1] - 1, w = time[2];
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                }
            }
        }

        int maxDist = dist.Max();
        return maxDist == int.MaxValue ? -1 : maxDist;
    }
}