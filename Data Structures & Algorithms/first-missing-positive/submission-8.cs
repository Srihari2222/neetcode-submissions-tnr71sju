public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int missing = 1;
        
        while (true) {
            bool found = false;
            
            foreach (int num in nums) {
                if (num == missing) {
                    found = true;
                    break;
                }
            }

            if (!found) {
                return missing;
            }

            missing++;
        }
    }
}