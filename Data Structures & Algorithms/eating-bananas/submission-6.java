public class Solution {
    public int minEatingSpeed(int[] piles, int h) {
        int speed = 1;
        while (true) {
            int totalTime = 0;
            for (int pile : piles) {
                totalTime += (int) Math.ceil((double) pile / speed);
            }

            if (totalTime <= h) {
                return speed;
            }
            speed++;
        }
    }
}