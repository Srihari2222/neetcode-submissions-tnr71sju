class Solution {
public:
    bool hasDuplicate(vector<int>& nums) {
        unordered_map<int, int> occurences;

        if (nums.empty()) {
            return false;
        }

        for (int i = 0; i <= nums.size(); ++i) {
            occurences[nums[i]] += 1;
            
            if (occurences[nums[i]] > 1) {
                return true;
            }
        }

        return false;
    }
};
