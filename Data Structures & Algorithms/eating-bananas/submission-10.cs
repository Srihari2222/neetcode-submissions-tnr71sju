public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int speed = 1;
        while (true) {
            int totalTime = 0;
            foreach (int pile in piles) {
                totalTime += (int) Math.Ceiling((double) pile / speed);
            }

            if (totalTime <= h) {
                return speed;
            }
            speed++;
        }
    }
}