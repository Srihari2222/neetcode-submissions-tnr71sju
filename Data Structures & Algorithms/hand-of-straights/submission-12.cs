public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0)
            return false;

        var count = new Dictionary<int, int>();
        foreach (int num in hand) {
            if (count.ContainsKey(num))
                count[num]++;
            else
                count[num] = 1;
        }

        var minH = new PriorityQueue<int, int>();
        foreach (var num in count.Keys)
            minH.Enqueue(num, num);

        while (minH.Count > 0) {
            int first = minH.Peek();
            for (int i = first; i < first + groupSize; i++) {
                if (!count.ContainsKey(i) || count[i] == 0)
                    return false;
                
                count[i]--;
                if (count[i] == 0) {
                    if (i != minH.Peek())
                        return false;
                    minH.Dequeue();
                }
            }
        }
        return true;
    }
}