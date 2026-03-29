class MedianFinder {
    private List<int> data;

    public MedianFinder() {
        data = new List<int>();
    }

    public void AddNum(int num) {
        data.Add(num);
    }

    public double FindMedian() {
        data.Sort();
        int n = data.Count;
        if ((n & 1) == 1) {
            return data[n / 2];
        } else {
            return (data[n / 2] + data[n / 2 - 1]) / 2.0;
        }
    }
}