public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int[] indegree = new int[numCourses];
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }
        foreach (var pre in prerequisites) {
            indegree[pre[1]]++;
            adj[pre[0]].Add(pre[1]);
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        int finish = 0;
        int[] output = new int[numCourses];
        while (q.Count > 0) {
            int node = q.Dequeue();
            output[numCourses - finish - 1] = node;
            finish++;
            foreach (var nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 0) {
                    q.Enqueue(nei);
                }
            }
        }

        if (finish != numCourses) {
            return new int[0];
        }
        return output;
    }
}