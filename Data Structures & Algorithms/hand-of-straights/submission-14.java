public class Solution {
    public boolean isNStraightHand(int[] hand, int groupSize) {
        if (hand.length % groupSize != 0) return false;

        Map<Integer, Integer> count = new TreeMap<>();
        for (int num : hand) {
            count.put(num, count.getOrDefault(num, 0) + 1);
        }

        Queue<Integer> q = new LinkedList<>();
        int lastNum = -1, openGroups = 0;

        for (int num : count.keySet()) {
            if ((openGroups > 0 && num > lastNum + 1) || 
                 openGroups > count.get(num)) {
                return false;
            }

            q.add(count.get(num) - openGroups);
            lastNum = num;
            openGroups = count.get(num);

            if (q.size() == groupSize) {
                openGroups -= q.poll();
            }
        }
        return openGroups == 0;
    }
}