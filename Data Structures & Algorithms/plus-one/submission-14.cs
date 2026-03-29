public class Solution {
    public int[] PlusOne(int[] digits) {
        int one = 1;
        int i = 0;
        bool carry = true;

        for (int j = digits.Length - 1; j >= 0; j--) {
            if (carry) {
                if (digits[j] == 9) {
                    digits[j] = 0;
                } else {
                    digits[j]++;
                    carry = false;
                }
            }
        }
        if (carry) {
            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            for (int j = 0; j < digits.Length; j++) {
                result[j + 1] = digits[j];
            }
            return result;
        }
        return digits;
    }
}