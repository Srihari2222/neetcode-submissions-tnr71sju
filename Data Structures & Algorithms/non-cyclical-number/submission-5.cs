public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> visit = new HashSet<int>();

        while (!visit.Contains(n)) {
            visit.Add(n);
            n = SumOfSquares(n);
            if (n == 1) {
                return true;
            }
        }
        return false;
    }

    private int SumOfSquares(int n) {
        int output = 0;

        while (n > 0) {
            int digit = n % 10;
            digit = digit * digit;
            output += digit;
            n /= 10;
        }
        return output;
    }
}