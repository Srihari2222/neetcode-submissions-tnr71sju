class Twitter {
    private int time;
    private Dictionary<int, HashSet<int>> followMap;
    private Dictionary<int, List<(int, int)>> tweetMap;

    public Twitter() {
        time = 0;
        followMap = new Dictionary<int, HashSet<int>>();
        tweetMap = new Dictionary<int, List<(int, int)>>();
    }

    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) {
            tweetMap[userId] = new List<(int, int)>();
        }
        tweetMap[userId].Add((time++, tweetId));
    }

    public List<int> GetNewsFeed(int userId) {
        var feed = new List<(int, int)>(tweetMap.GetValueOrDefault(userId, new List<(int, int)>()));
        foreach (var followeeId in followMap.GetValueOrDefault(userId, new HashSet<int>())) {
            feed.AddRange(tweetMap.GetValueOrDefault(followeeId, new List<(int, int)>()));
        }
        feed.Sort((a, b) => b.Item1 - a.Item1);
        var res = new List<int>();
        for (int i = 0; i < Math.Min(10, feed.Count); i++) {
            res.Add(feed[i].Item2);
        }
        return res;
    }

    public void Follow(int followerId, int followeeId) {
        if (followerId != followeeId) {
            if (!followMap.ContainsKey(followerId)) {
                followMap[followerId] = new HashSet<int>();
            }
            followMap[followerId].Add(followeeId);
        }
    }

    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)) {
            followMap[followerId].Remove(followeeId);
        }
    }
}