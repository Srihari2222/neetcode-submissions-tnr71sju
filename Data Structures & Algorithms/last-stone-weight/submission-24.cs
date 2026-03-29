public class Solution {
    public int LastStoneWeight(int[] stones) {
        int maxStone = 0;
        foreach (int stone in stones) {
            maxStone = Math.Max(maxStone, stone);
        }

        int[] bucket = new int[maxStone + 1];
        foreach (int stone in stones) {
            bucket[stone]++;
        }

        int first = maxStone, second = maxStone;
        while (first > 0) {
            if (bucket[first] % 2 == 0) {
                first--;
                continue;
            }

            int j = Math.Min(first - 1, second);
            while (j > 0 && bucket[j] == 0) {
                j--;
            }

            if (j == 0) {
                return first;
            }

            second = j;
            bucket[first]--;
            bucket[second]--;
            bucket[first - second]++;
            first = Math.Max(first - second, second);
        }

        return first;
    }
}