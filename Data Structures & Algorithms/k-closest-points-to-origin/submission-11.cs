public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();
        foreach (int[] point in points) {
            int dist = point[0] * point[0] + point[1] * point[1];
            minHeap.Enqueue(new int[] { dist, point[0], point[1] }, dist);
        }

        int[][] result = new int[K][];
        for (int i = 0; i < K; ++i) {
            int[] point = minHeap.Dequeue();
            result[i] = new int[] { point[1], point[2] };
        }
        return result;
    }
}