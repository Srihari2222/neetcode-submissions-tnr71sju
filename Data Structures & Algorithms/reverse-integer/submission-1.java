public class Solution {
    public int reverse(int x) {
        List<Integer> digits = new ArrayList<>();
        int num = x;
        x = Math.abs(x);
        while (x != 0) {
            digits.add(x % 10);
            x /= 10;
        }
        long res = 0;
        for (int d : digits) {
            res *= 10;
            res += d;
        }
        
        res = num < 0 ? -res : res;
        if (res < -(1 << 31) || res > (1 << 31) - 1) {
            res = 0;
        }
        return (int)res;
    }
}