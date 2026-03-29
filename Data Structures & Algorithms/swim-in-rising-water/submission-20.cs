public class Solution {
    public int SwimInWater(int[][] grid) {
        int N = grid.Length;
        var visit = new HashSet<(int, int)>();
        var minHeap = new PriorityQueue<(int t, int r, int c), int>();
        int[][] directions = { 
            new int[]{0, 1}, new int[]{0, -1}, 
            new int[]{1, 0}, new int[]{-1, 0} 
        };

        minHeap.Enqueue((grid[0][0], 0, 0), grid[0][0]);
        visit.Add((0, 0));

        while (minHeap.Count > 0) {
            var curr = minHeap.Dequeue();
            int t = curr.t, r = curr.r, c = curr.c;
            if (r == N - 1 && c == N - 1) {
                return t;
            }
            foreach (var dir in directions) {
                int neiR = r + dir[0], neiC = c + dir[1];
                if (neiR < 0 || neiC < 0 || neiR >= N || 
                    neiC >= N || visit.Contains((neiR, neiC))) {
                    continue;
                }
                visit.Add((neiR, neiC));
                minHeap.Enqueue(
                    (Math.Max(t, grid[neiR][neiC]), neiR, neiC), 
                    Math.Max(t, grid[neiR][neiC]));
            }
        }

        return N * N;  
    }
}