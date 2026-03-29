public class Solution {
    public int reverse(int x) {
        long res = reverseHelper(Math.abs(x), 0) * (x < 0 ? -1 : 1);
        if (res < Integer.MIN_VALUE || res > Integer.MAX_VALUE) {
            return 0;
        }
        return (int) res;
    }

    private long reverseHelper(int n, long rev) {
        if (n == 0) {
            return rev;
        }
        rev = rev * 10 + n % 10;
        return reverseHelper(n / 10, rev);
    }
}