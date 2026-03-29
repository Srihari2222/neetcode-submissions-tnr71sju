class Solution {
public:
    int leastInterval(vector<char>& tasks, int n) {
        vector<int> count(26, 0);
        for (char task : tasks) {
            count[task - 'A']++;
        }
        
        vector<pair<int, int>> arr;
        for (int i = 0; i < 26; i++) {
            if (count[i] > 0) {
                arr.emplace_back(count[i], i);
            }
        }

        int time = 0;
        vector<int> processed;
        while (!arr.empty()) {
            int maxi = -1;
            for (int i = 0; i < arr.size(); i++) {
                bool ok = true;
                for (int j = max(0, time - n); j < time; j++) {
                    if (j < processed.size() && processed[j] == arr[i].second) {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                if (maxi == -1 || arr[maxi].first < arr[i].first) {
                    maxi = i;
                }
            }
            
            time++;
            int cur = -1;
            if (maxi != -1) {
                cur = arr[maxi].second;
                arr[maxi].first--;
                if (arr[maxi].first == 0) {
                    arr.erase(arr.begin() + maxi);
                }
            }
            processed.push_back(cur);
        }
        return time;
    }
};