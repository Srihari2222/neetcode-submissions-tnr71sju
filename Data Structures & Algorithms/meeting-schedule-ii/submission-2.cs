public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        var minHeap = new PriorityQueue<int, int>();
        
        foreach (var interval in intervals) {
            if (minHeap.Count > 0 && minHeap.Peek() <= interval.start) {
                minHeap.Dequeue();
            }
            minHeap.Enqueue(interval.end, interval.end);
        }
        
        return minHeap.Count;
    }
}