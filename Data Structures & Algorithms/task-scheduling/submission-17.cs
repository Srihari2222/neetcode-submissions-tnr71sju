public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (var task in tasks) {
            count[task - 'A']++;
        }

        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++) {
            if (count[i] > 0) {
                maxHeap.Enqueue(count[i], -count[i]);
            }
        }

        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();  
        while (maxHeap.Count > 0 || queue.Count > 0) {
            if (queue.Count > 0 && time >= queue.Peek()[1]) {
                int[] temp = queue.Dequeue();
                maxHeap.Enqueue(temp[0], -temp[0]);
            }
            if (maxHeap.Count > 0) {
                int cnt = maxHeap.Dequeue() - 1;
                if (cnt > 0) {
                    queue.Enqueue(new int[] { cnt, time + n + 1 });
                }
            }
            time++;
        }
        return time;
    }
}