class Solution {
public:
    int maxArea(vector<int>& heights) {
        int mx = 0;
        int n = heights.size();
        int l = 0, r = 0;
        while (r < n) {
            r++;
            mx = max(mx, min(heights[l], heights[r]) * (r-l));
            if (heights[r] > heights[l]) {
                l = r;
            }
        }
        return mx;
    }
};