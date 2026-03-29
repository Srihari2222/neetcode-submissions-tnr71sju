public class Solution {
    public int lastStoneWeight(List<Integer> stones) {
        while (stones.size() > 1) {
            stones.sort(null);
            int cur = stones.remove(stones.size() - 1) - stones.remove(stones.size() - 1);
            if (cur != 0) {
                stones.add(cur);
            }
        }
        return stones.isEmpty() ? 0 : stones.get(0);
    }
}