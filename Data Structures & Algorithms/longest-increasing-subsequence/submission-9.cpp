class Solution {
public:
    int lengthOfLIS(vector<int>& nums) {
        vector<int> dp;
        dp.push_back(nums[0]);
        int ans=1,n=nums.size();
        for(int i=1;i<n;i++){
            if(dp.back() < nums[i]){ 
                dp.push_back(nums[i]);
                ans++;
            }
            else dp[lower_bound(dp.begin(),dp.end(),nums[i]) - dp.begin()]=nums[i]; 
        }
        return ans;
    }
};
