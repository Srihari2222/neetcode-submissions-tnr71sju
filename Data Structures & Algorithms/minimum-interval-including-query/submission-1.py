class Solution:
    def minInterval(self, intervals: List[List[int]], queries: List[int]) -> List[int]:
        events = []
        # Create events for interval starts and ends
        for idx, (start, end) in enumerate(intervals):
            events.append((start, 0, end - start + 1, idx))    # Start event
            events.append((end, 2, end - start + 1, idx))      # End event (changed from end + 1)
        
        # Create events for queries
        for i, q in enumerate(queries):
            events.append((q, 1, i))
        
        # Sort events by time, then by type (end before query)
        events.sort(key=lambda x: (x[0], x[1]))
        
        sizes = []  # Min heap to store (interval_size, interval_index)
        ans = [-1] * len(queries)
        active_intervals = set()  # Track active intervals
        
        for time, type_val, *rest in events:
            if type_val == 0:  # Interval start
                interval_size, idx = rest
                heapq.heappush(sizes, (interval_size, idx))
                active_intervals.add(idx)
            elif type_val == 2:  # Interval end
                idx = rest[1]
                active_intervals.remove(idx)
            else:  # Query
                query_idx = rest[0]
                # Remove inactive intervals from heap
                while sizes and sizes[0][1] not in active_intervals:
                    heapq.heappop(sizes)
                # If any active interval exists, use the smallest one
                if sizes:
                    ans[query_idx] = sizes[0][0]
        
        return ans