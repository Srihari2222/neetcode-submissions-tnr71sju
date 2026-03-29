public class Solution {
    public boolean validTree(int n, int[][] edges) {
        if (edges.length > n - 1) {
            return false;
        }

        List<List<Integer>> adj = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            adj.add(new ArrayList<>());
        }

        for (int[] edge : edges) {
            adj.get(edge[0]).add(edge[1]);
            adj.get(edge[1]).add(edge[0]);
        }

        Set<Integer> visit = new HashSet<>();
        Queue<Integer> q = new LinkedList<>();
        q.offer(0);
        visit.add(0);

        while (!q.isEmpty()) {
            int node = q.poll();
            for (int nei : adj.get(node)) {
                if (visit.contains(nei)) {
                    continue;
                }
                visit.add(nei);
                adj.get(nei).remove(Integer.valueOf(node));
                q.offer(nei);
            }
        }

        return visit.size() == n;
    }
}