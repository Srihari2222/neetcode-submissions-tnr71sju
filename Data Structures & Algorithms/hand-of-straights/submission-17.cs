public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) return false;

        var count = new SortedDictionary<int, int>();
        foreach (int num in hand) {
            if (!count.ContainsKey(num)) count[num] = 0;
            count[num]++;
        }

        var q = new Queue<int>();
        int lastNum = -1, openGroups = 0;

        foreach (int num in count.Keys) {
            if ((openGroups > 0 && num > lastNum + 1) || 
                 openGroups > count[num]) {
                return false;
            }

            q.Enqueue(count[num] - openGroups);
            lastNum = num;
            openGroups = count[num];

            if (q.Count == groupSize) {
                openGroups -= q.Dequeue();
            }
        }
        return openGroups == 0;
    }
}