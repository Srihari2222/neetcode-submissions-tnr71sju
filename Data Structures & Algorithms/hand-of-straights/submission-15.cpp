class Solution {
public:
    bool isNStraightHand(vector<int>& hand, int groupSize) {
        if (hand.size() % groupSize != 0) return false;

        map<int, int> count;
        for (int num : hand) count[num]++;
        
        queue<int> q;
        int lastNum = -1, openGroups = 0;

        for (auto& entry : count) {
            int num = entry.first;
            if ((openGroups > 0 && num > lastNum + 1) || 
                 openGroups > count[num]) {
                return false;
            }

            q.push(count[num] - openGroups);
            lastNum = num;
            openGroups = count[num];

            if (q.size() == groupSize) {
                openGroups -= q.front();
                q.pop();
            }
        }
        return openGroups == 0;
    }
};