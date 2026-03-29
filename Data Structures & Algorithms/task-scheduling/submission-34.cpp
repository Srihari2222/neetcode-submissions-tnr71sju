class Solution {
public:
    int leastInterval(vector<char>& tasks, int n) {        
        if (tasks.size() == 0) return 0;
        int occurrences[26] = {0};
        priority_queue<pair<int, int>> maxHeap;
        deque<pair<int, int>> queue;
        for(int i = 0; i < tasks.size(); ++i) {
            occurrences[tasks[i] - 65]++;
        }
        
        for (int i = 0; i < 26; ++i) {
            if (occurrences[i]) {
                maxHeap.push(make_pair(occurrences[i], i));
            }
        }
        
        int time = 0;
        pair<int, int> top;
        while (!maxHeap.empty()) {
            pair<int, int> current = maxHeap.top();
            maxHeap.pop();
            current.first--;
            time++;
            if (current.first > 0) {
                queue.push_back(make_pair(current.first, time + n));
            }
            if (queue.front().second == time) {
                maxHeap.push(queue.front());
                queue.pop_front();
            }
            else if(maxHeap.empty() && queue.front().second > time) {
                time += queue.front().second - time;
                maxHeap.push(queue.front());
                queue.pop_front();
            }
        }
        return time;
    }
};