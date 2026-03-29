class Solution {
public:
    int eraseOverlapIntervals(vector<vector<int>>& intervals) {
        sort(intervals.begin(), intervals.end(), [](auto& a, auto& b) {
            return a[1] < b[1];
        });
        int n = intervals.size();
        vector<int> dp(n, 0);  

        for (int i = 0; i < n; i++) {
            dp[i] = 1;  
            for (int j = 0; j < i; j++) {
                if (intervals[j][1] <= intervals[i][0]) {  
                    dp[i] = max(dp[i], 1 + dp[j]);
                }
            }
        }

        int maxNonOverlapping = *max_element(dp.begin(), dp.end());  
        return n - maxNonOverlapping;
    }
};