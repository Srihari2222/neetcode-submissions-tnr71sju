class Solution 
{
public:
    int minEatingSpeed(vector<int>& piles, int h) 
    {
        int n = piles.size();

        int left = 1;
        int right = *max_element(piles.begin(), piles.end());

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if(can_eat_all(piles, h, mid))
                right = mid - 1;
            else
                left = mid + 1;
        }
        return left;
    }

    bool can_eat_all(vector<int>& piles, int total_hours, int bananas_per_hour)
    {
        int hours_taken = 0;

        for(int i = 0; i < piles.size(); i++)
        {
            if(piles[i] <= bananas_per_hour)
                hours_taken++;
            else
                hours_taken += piles[i] / bananas_per_hour + 1;
        }

        return hours_taken <= total_hours;
    }
};