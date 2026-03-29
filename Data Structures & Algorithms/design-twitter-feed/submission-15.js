/**
 * const { PriorityQueue } = require('@datastructures-js/priority-queue');
 */
class Twitter {
    constructor() {
        // Global count (decremented for each new tweet => newer tweets have more negative 'count')
        this.count = 0;
        // tweetMap: userId -> array of [count, tweetId] (up to 10 items)
        this.tweetMap = new Map();
        // followMap: userId -> set of followeeIds
        this.followMap = new Map();
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
        const tweets = this.tweetMap.get(userId);
        tweets.push([this.count, tweetId]);
        if (tweets.length > 10) {
            // Keep only 10 recent tweets
            tweets.shift();
        }
        // Decrement count so that more recent tweets have smaller (more negative) values
        this.count--;
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
        // Ensure user follows themself
        this.followMap.get(userId).add(userId);

        // We'll create a "min-heap" (by 'count') for the final retrieval of newest tweets first.
        // The item shape is: [count, tweetId, userId, nextIndex]
        // compare(a, b) => a[0] - b[0] ensures the smallest a[0] (most negative = newest) is returned first.
        const minHeap = new PriorityQueue((a, b) => a[0] - b[0]);

        // If user follows >= 10, gather the 10 newest tweets across all followees using a "max-heap" approach:
        //   - We'll store '[-count, tweetId, userId, nextIndex]' in a min-heap, so the smallest -count 
        //     (which is actually the oldest tweet) is popped first if we exceed size 10.
        if (this.followMap.get(userId).size >= 10) {
            const maxHeap = new PriorityQueue((a, b) => a[0] - b[0]);
            for (const followeeId of this.followMap.get(userId)) {
                if (!this.tweetMap.has(followeeId)) continue;
                const tweets = this.tweetMap.get(followeeId);
                const idx = tweets.length - 1;
                const [cnt, tId] = tweets[idx];
                // Store as [-cnt, tId, followeeId, idx-1]
                maxHeap.enqueue([-cnt, tId, followeeId, idx - 1]);
                if (maxHeap.size() > 10) {
                    // Remove the oldest tweet (smallest -count => largest actual count)
                    maxHeap.dequeue();
                }
            }
            // Transfer all items from maxHeap => minHeap, flipping -cnt back to cnt
            while (maxHeap.size() > 0) {
                const [negCount, tId, fId, idx] = maxHeap.dequeue();
                minHeap.enqueue([-negCount, tId, fId, idx]);
            }

        } else {
            // If fewer than 10 followees, push each followee's most recent tweet directly to minHeap
            for (const followeeId of this.followMap.get(userId)) {
                if (!this.tweetMap.has(followeeId)) continue;
                const tweets = this.tweetMap.get(followeeId);
                const idx = tweets.length - 1;
                const [cnt, tId] = tweets[idx];
                minHeap.enqueue([cnt, tId, followeeId, idx - 1]);
            }
        }

        // Extract at most 10 tweets from minHeap (newest first),
        // then push the next older tweet from the same user if available.
        while (minHeap.size() > 0 && res.length < 10) {
            const [cnt, tId, fId, idx] = minHeap.dequeue();
            res.push(tId);
            if (idx >= 0) {
                const [olderCount, olderTId] = this.tweetMap.get(fId)[idx];
                minHeap.enqueue([olderCount, olderTId, fId, idx - 1]);
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