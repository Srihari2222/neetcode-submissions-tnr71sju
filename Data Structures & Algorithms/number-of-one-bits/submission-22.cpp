class Solution {
public:
    int hammingWeight(int n) {
        int res = 0;
        while (n != 0) {
            n &= (n - 1);  // clears the lowest set bit
            res++;         // increment count
        }
        return res;
    }
};
