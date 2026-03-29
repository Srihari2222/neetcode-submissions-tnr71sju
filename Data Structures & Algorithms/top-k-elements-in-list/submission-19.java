class Solution {
    public int[] topKFrequent(int[] nums, int k) {
         Map<Integer, Integer> count = new HashMap<>();
        List<List<Integer>> freq = new ArrayList<>(Collections.nCopies(nums.length + 1, new ArrayList<>()));

        for (int num : nums) {
            count.put(num, count.getOrDefault(num, 0) + 1);
        }
        for (Map.Entry<Integer, Integer> entry : count.entrySet()) {
            freq.get(entry.getValue()).add(entry.getKey());
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.length - 1; i > 0 && index < k; i--) {
            for (int n : freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
}
