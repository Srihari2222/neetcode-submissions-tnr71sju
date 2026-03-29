class Solution {
public:
    int findKthLargest(vector<int>& nums, int k) {
        stack<int> s;
        for (auto n : nums) {
            stack<int> ss;
            while (!s.empty() && n > s.top()) {
                int cus = s.top();
                s.pop();
                ss.push(cus);
            }
            if (s.size() < k)
                s.push(n);
            while (!ss.empty() && s.size() < k) {
                s.push(ss.top());
                ss.pop();
            }
        }
        return s.top();
    }
};