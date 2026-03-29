public class Solution {
    public int HammingWeight(uint n) {
        return BitOperations.PopCount(n);
    }
}