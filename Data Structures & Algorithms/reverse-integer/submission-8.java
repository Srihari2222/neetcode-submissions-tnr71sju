public class Solution {
    public int reverse(int x) {
        int org = x;
        x = Math.abs(x);
        long res = Long.parseLong(new StringBuilder(
                   String.valueOf(x)).reverse().toString()
                );
        if (org < 0) {
            res *= -1;
        }
        if (res < -(1 << 31) || res > (1 << 31) - 1) {
            return 0;
        }
        return (int)res;
    }
}