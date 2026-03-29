public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int inf = int.MaxValue / 2;
        int[,] dist = new int[n, n];
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                dist[i, j] = i == j ? 0 : inf;
            }
        }
        
        foreach (var time in times) {
            int u = time[0] - 1, v = time[1] - 1, w = time[2];
            dist[u, v] = w;
        }
        
        for (int mid = 0; mid < n; mid++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dist[i, j] = Math.Min(dist[i, j], dist[i, mid] + dist[mid, j]);
        
        int res = Enumerable.Range(0, n).Select(i => dist[k-1, i]).Max();
        return res == inf ? -1 : res;
    }
}
