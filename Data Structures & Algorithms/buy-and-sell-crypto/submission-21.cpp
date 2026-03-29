class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int result = 0;
        int l = 0, r = 1;

        while (r < prices.size()) {
            result = max(result, prices[r] - prices[l]);

            if (prices[l] > prices[r]) {
                l = r;
            }
            
            r++;
        }
        return result;
    }
};