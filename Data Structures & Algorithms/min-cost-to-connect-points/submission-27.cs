public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int N = points.Length;
        var adj = new Dictionary<int, List<int[]>>();
        for (int i = 0; i < N; i++) {
            int x1 = points[i][0];
            int y1 = points[i][1];
            for (int j = i + 1; j < N; j++) {
                int x2 = points[j][0];
                int y2 = points[j][1];
                int dist = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                if (!adj.ContainsKey(i))
                    adj[i] = new List<int[]>();
                adj[i].Add(new int[] { j, dist });

                if (!adj.ContainsKey(j))
                    adj[j] = new List<int[]>();
                adj[j].Add(new int[] { i, dist });
            }
        }

        int res = 0;
        var visit = new HashSet<int>();
        var pq = new PriorityQueue<int, int>(); 
        pq.Enqueue(0, 0); 

        while (visit.Count < N && pq.Count > 0) {
            if (pq.TryPeek(out int i, out int cost)) {
                pq.Dequeue();

                if (visit.Contains(i)) {
                    continue;
                }

                res += cost;
                visit.Add(i);

                if (adj.ContainsKey(i)) {
                    foreach (var edge in adj[i]) {
                        var nei = edge[0];
                        var neiCost = edge[1];
                        if (!visit.Contains(nei)) {
                            pq.Enqueue(nei, neiCost);
                        }
                    }
                }
            }
        }
        return visit.Count == N ? res : -1;
    }
}