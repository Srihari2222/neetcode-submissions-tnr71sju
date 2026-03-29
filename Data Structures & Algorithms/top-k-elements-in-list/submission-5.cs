public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }

        var heap = new SortedSet<(int, int)>();
        foreach (var entry in count) {
            heap.Add((entry.Value, entry.Key));
            if (heap.Count > k) {
                heap.Remove(heap.Min);
            }
        }

        var res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Max.Item2;
            heap.Remove(heap.Max);
        }

        return res;
    }
}
