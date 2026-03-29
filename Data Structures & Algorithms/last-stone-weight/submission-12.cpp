class Solution {
public:
    int lastStoneWeight(vector<int>& stones) {
        sort(stones.begin(), stones.end());
        int n = stones.size();

        while (n > 1) {
            int cur = stones[n - 1] - stones[n - 2];
            n -= 2;
            if (cur > 0) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (stones[mid] < cur) {
                        l = mid + 1;
                    } else {
                        r = mid;
                    }
                }
                int pos = l;
                stones.push_back(0);
                for (int i = n + 1; i > pos; i--) {
                    stones[i] = stones[i - 1];
                }
                stones[pos] = cur;
                n++;
            }
        }
        return n > 0 ? stones[0] : 0;
    }
};