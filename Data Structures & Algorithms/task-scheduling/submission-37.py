class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        if not tasks:
            return 0

        # count occurrences of each task
        occurrences = [0] * 26
        for c in tasks:
            occurrences[ord(c) - 65] += 1

        # debug print of tasks
        for c in tasks:
            print(c, end='')

        # max-heap of (count, task_index)
        # Python's heapq is a min-heap, so push negatives
        maxHeap: List[tuple[int,int]] = []
        for i in range(26):
            if occurrences[i] > 0:
                heapq.heappush(maxHeap, (-occurrences[i], i))

        queue: deque[tuple[int,int]] = deque()  # stores (remaining_count, ready_time)
        time = 0

        while maxHeap:
            cnt, idx = heapq.heappop(maxHeap)
            cnt += 1  # decrement (since cnt is negative)
            time += 1

            if cnt < 0:  # still have this task left
                queue.append((cnt, time + n))

            # if front of cooldown queue is ready, push back into heap
            if queue and queue[0][1] == time:
                ready_cnt, ready_idx = queue.popleft()
                heapq.heappush(maxHeap, (ready_cnt, ready_idx))
            # if heap empty but tasks still cooling, fast-forward time
            elif queue and not maxHeap and queue[0][1] > time:
                time = queue[0][1]
                ready_cnt, ready_idx = queue.popleft()
                heapq.heappush(maxHeap, (ready_cnt, ready_idx))

        return time