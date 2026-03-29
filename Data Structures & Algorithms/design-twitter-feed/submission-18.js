/**
 * const { PriorityQueue } = require('@datastructures-js/priority-queue');
 */
class Twitter {
    constructor() {
        this.count = 0; 
        this.tweetMap = new Map(); // userId -> array of [count, tweetId]
        this.followMap = new Map(); // userId -> set of followeeIds
    }

    /**
     * @param {number} userId
     * @param {number} tweetId
     * @return {void}
     */
    postTweet(userId, tweetId) {
        if (!this.tweetMap.has(userId)) {
            this.tweetMap.set(userId, []);
        }
        this.tweetMap.get(userId).push([this.count, tweetId]);
        this.count -= 1;
    }

    /**
     * @param {number} userId
     * @return {number[]}
     */
    getNewsFeed(userId) {
        const res = [];
        if (!this.followMap.has(userId)) {
            this.followMap.set(userId, new Set());
        }
        this.followMap.get(userId).add(userId);
        const minHeap = new PriorityQueue(
            (a, b) => a[0] - b[0]
        );

        for (const followeeId of this.followMap.get(userId)) {
            if (this.tweetMap.has(followeeId)) {
                const tweets = this.tweetMap.get(followeeId);
                const index = tweets.length - 1;
                const [count, tweetId] = tweets[index];
                minHeap.enqueue([count, tweetId, followeeId, index - 1]);
            }
        }

        while (!minHeap.isEmpty() && res.length < 10) {
            const [count, tweetId, followeeId, nextIndex] = minHeap.dequeue();
            res.push(tweetId);
            if (nextIndex >= 0) {
                const [olderCount, olderTweetId] = this.tweetMap.get(followeeId)[nextIndex];
                minHeap.enqueue([olderCount, olderTweetId, followeeId, nextIndex - 1]);
            }
        }

        return res;
    }

    /**
     * @param {number} followerId
     * @param {number} followeeId
     * @return {void}
     */
    follow(followerId, followeeId) {
        if (!this.followMap.has(followerId)) {
            this.followMap.set(followerId, new Set());
        }
        this.followMap.get(followerId).add(followeeId);
    }

    /**
     * @param {number} followerId
     * @param {number} followeeId
     * @return {void}
     */
    unfollow(followerId, followeeId) {
        if (this.followMap.has(followerId)) {
            this.followMap.get(followerId).delete(followeeId);
        }
    }
}