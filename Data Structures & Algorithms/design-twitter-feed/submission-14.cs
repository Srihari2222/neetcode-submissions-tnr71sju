class Twitter {
    private int count;
    private Dictionary<int, List<int[]>> tweetMap;
    private Dictionary<int, HashSet<int>> followMap;

    public Twitter() {
        count = 0;
        tweetMap = new Dictionary<int, List<int[]>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) {
            tweetMap[userId] = new List<int[]>();
        }
        tweetMap[userId].Add(new int[] { count++, tweetId });
    }

    public List<int> GetNewsFeed(int userId) {
        List<int> res = new List<int>();
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();

        if (!followMap.ContainsKey(userId)) {
            followMap[userId] = new HashSet<int>();
        }
        followMap[userId].Add(userId);

        foreach (int followeeId in followMap[userId]) {
            if (tweetMap.ContainsKey(followeeId) && tweetMap[followeeId].Count > 0) {
                List<int[]> tweets = tweetMap[followeeId];
                int index = tweets.Count - 1;
                int[] latestTweet = tweets[index];
                minHeap.Enqueue(new int[] { latestTweet[0], latestTweet[1], followeeId, index }, -latestTweet[0]);
            }
        }

        while (minHeap.Count > 0 && res.Count < 10) {
            int[] curr = minHeap.Dequeue();
            res.Add(curr[1]);
            int index = curr[3];
            if (index > 0) {
                int[] tweet = tweetMap[curr[2]][index - 1];
                minHeap.Enqueue(new int[] { tweet[0], tweet[1], curr[2], index - 1 }, -tweet[0]);
            }
        }

        return res;
    }

    public void Follow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)) {
            followMap[followerId] = new HashSet<int>();
        }
        followMap[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)) {
            followMap[followerId].Remove(followeeId);
        }
    }
}