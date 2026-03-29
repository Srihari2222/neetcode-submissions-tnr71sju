public class Solution {
    public int networkDelayTime(int[][] times, int n, int k) {
        Map<Integer, List<int[]>> adj = new HashMap<>();
        for (int i = 1; i <= n; i++) adj.put(i, new ArrayList<>());
        for (int[] time : times) {
            adj.get(time[0]).add(new int[] {time[1], time[2]});
        }
        Map<Integer, Integer> dist = new HashMap<>();
        for (int i = 1; i <= n; i++) dist.put(i, Integer.MAX_VALUE);
        dist.put(k, 0);
        
        Queue<int[]> q = new LinkedList<>();
        q.offer(new int[] {k, 0});

        while (!q.isEmpty()) {
            int[] curr = q.poll();
            int node = curr[0], time = curr[1];
            if (dist.get(node) < time) {
                continue;
            }
            for (int[] nei : adj.get(node)) {
                int nextNode = nei[0], weight = nei[1];
                if (time + weight < dist.get(nextNode)) {
                    dist.put(nextNode, time + weight);
                    q.offer(new int[] {nextNode, time + weight});
                }
            }
        }

        int res = Collections.max(dist.values());
        return res == Integer.MAX_VALUE ? -1 : res;
    }
}