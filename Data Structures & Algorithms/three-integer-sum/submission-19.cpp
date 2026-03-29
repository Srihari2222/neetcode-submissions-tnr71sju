class Solution {
public:
vector<vector<int>> threeSum(vector<int>& nums) {
set<vector<int>> ans;
sort(nums.begin(), nums.end());

    for (int i = 0; i < nums.size(); ++i) {
        int left = i+1;
        int right = nums.size()-1;
        while (left < right) {
            while (-nums[i] < nums[left]+nums[right]) --right;
            if (nums[left]+nums[right] == -nums[i]) {
                vector<int> triple{nums[i], nums[left], nums[right]};
                sort(triple.begin(), triple.end());
                ans.insert(triple);
            }
            ++left;
        }
    }
    return vector<vector<int>>(ans.begin(), ans.end());
}
};