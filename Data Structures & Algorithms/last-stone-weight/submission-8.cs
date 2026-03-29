public class Solution {
    public int LastStoneWeight(IList<int> stones) {
        while (stones.Count > 1) {
            stones = new List<int>(stones);
            stones.Sort();
            int cur = stones[stones.Count - 1] - stones[stones.Count - 2];
            stones.RemoveAt(stones.Count - 1);
            stones.RemoveAt(stones.Count - 1);
            if (cur != 0) {
                stones.Add(cur);
            }
        }
        return stones.Count == 0 ? 0 : stones[0];
    }
}