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
            sort(feed.rbegin(), feed.rend());
            for (const auto& tweet : feed) {
                res.push_back(tweet[1]);
            }
            return res;
        }

        quickSelect(feed, 0, feed.size() - 1, feed.size() - 10);

        for (int i = feed.size() - 1; i >= feed.size() - 10; --i) {
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
        int pivot = feed[right][0];
        int i = left;
        for (int j = left; j < right; ++j) {
            if (feed[j][0] <= pivot) {
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
        if (pivotIndex == k) return;
        else if (pivotIndex < k) quickSelect(feed, pivotIndex + 1, right, k);
        else quickSelect(feed, left, pivotIndex - 1, k);
    }
};
