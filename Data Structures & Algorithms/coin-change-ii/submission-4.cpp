class Solution {
public:
    int change(int amount, vector<int>& coins) {
        int n=coins.size();
        vector<vector<int>> dp(n,vector<int>(amount,-1));
        return rec(coins,dp,n,0,amount);
    }
    int rec(vector<int> &coins,vector<vector<int>> &dp,int n,int idx,int amount){
        if(amount==0)return 1;
        if(amount<0 || idx >= n)return 0;
        if(dp[idx][amount-1]!=-1)return dp[idx][amount-1];
        int res=rec(coins,dp,n,idx+1,amount);
        res+=rec(coins,dp,n,idx,amount-coins[idx]);
        return dp[idx][amount-1]=res;
    }
};