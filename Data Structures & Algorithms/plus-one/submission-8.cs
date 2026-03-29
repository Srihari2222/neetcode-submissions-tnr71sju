public class Solution {
    public int[] PlusOne(int[] digits) {
        if (digits.Length == 0)
            return new int[] { 1 };

        if (digits[digits.Length - 1] < 9) {
            digits[digits.Length - 1] += 1;
            return digits;
        } else {
            int[] newDigits = new int[digits.Length - 1];
            Array.Copy(digits, 0, newDigits, 0, digits.Length - 1);
            int[] result = PlusOne(newDigits);
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = 0;
            return result;
        }
    }
}