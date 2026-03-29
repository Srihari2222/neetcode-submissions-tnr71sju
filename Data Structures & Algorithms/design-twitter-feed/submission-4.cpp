class Twitter {
    int count;
    unordered_map<int, vector<vector<int>>> tweetMap;
    unordered_map<int, set<int>> followMap;

public:
    Twitter() {
        count = 0;
    }

    void postTweet(int userId, int tweetId) {
        tweetMap[userId].push_back({count++, tweetId});
    }

    vector<int> getNewsFeed(int userId) {
        vector<int> res;
        vector<vector<int>> feed;

        followMap[userId].insert(userId);
        for (int followeeId : followMap[userId]) {
            if (tweetMap.count(followeeId)) {
                for (const vector<int>& tweet : tweetMap[followeeId]) {
                    feed.push_back(tweet);
                }
            }
        }

        if (feed.size() <= 10) {
            sort(feed.rbegin(), feed.rend());  // Sort in descending order by timestamp
            for (const auto& tweet : feed) {
                res.push_back(tweet[1]);
            }
            return res;
        }

        quickSelect(feed, 0, feed.size() - 1, 10);  // We want the top 10 tweets

        sort(feed.end() - 10, feed.end(), greater<vector<int>>());  // Sort the top 10
        for (int i = feed.size() - 10; i < feed.size(); ++i) {
            res.push_back(feed[i][1]);
        }

        return res;
    }

    void follow(int followerId, int followeeId) {
        followMap[followerId].insert(followeeId);
    }

    void unfollow(int followerId, int followeeId) {
        followMap[followerId].erase(followeeId);
    }

private:
    int partition(vector<vector<int>>& feed, int left, int right) {
        int pivot = feed[right][0];  // Pivot is the tweet count
        int i = left;
        for (int j = left; j < right; ++j) {
            if (feed[j][0] > pivot) {  // We want larger values first (most recent tweets)
                swap(feed[i], feed[j]);
                i++;
            }
        }
        swap(feed[i], feed[right]);
        return i;
    }

    void quickSelect(vector<vector<int>>& feed, int left, int right, int k) {
        if (left >= right) return;
        int pivotIndex = partition(feed, left, right);
        int numRight = right - pivotIndex + 1;  // Number of elements on the right of pivot
        if (numRight == k) return;  // We have exactly k largest elements in the right part
        else if (numRight > k) quickSelect(feed, pivotIndex + 1, right, k);  // Look on the right
        else quickSelect(feed, left, pivotIndex - 1, k - numRight);  // Look on the left
    }
};
