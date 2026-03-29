class Solution {
public:
    int eraseOverlapIntervals(vector<vector<int>>& intervals) {
        sort(intervals.begin(), intervals.end());
        return intervals.size() - dfs(intervals, 0, -1);
    }

private:
    int dfs(const vector<vector<int>>& intervals, int i, int prev) {
        if (i == intervals.size()) return 0;
        int res = dfs(intervals, i + 1, prev);
        if (prev == -1 || intervals[prev][1] <= intervals[i][0]) {
            res = max(res, 1 + dfs(intervals, i + 1, i));
        }
        return res;
    }
};