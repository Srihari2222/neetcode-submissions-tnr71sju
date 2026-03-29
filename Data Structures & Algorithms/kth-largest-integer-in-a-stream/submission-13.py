import heapq

class KthLargest:
    maxHeap = []
    k = 0

    def __init__(self, k: int, nums: List[int]):
        self.k = k
        heapq.heapify(self.maxHeap)
        for n in nums:
            heapq.heappush(self.maxHeap, -n)


    def add(self, val: int) -> int:
        heapq.heappush(self.maxHeap, -val)
        temp = []
        for i in range(self.k):
            temp.append(heapq.heappop(self.maxHeap))
        res = -temp[-1]
        for n in temp:
            heapq.heappush(self.maxHeap, n)
        return res