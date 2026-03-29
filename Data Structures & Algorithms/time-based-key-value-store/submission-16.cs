public class TimeMap {
    private Dictionary<string, SortedDictionary<int, string>> m;

    public TimeMap() {
        m = new Dictionary<string, SortedDictionary<int, string>>();
    }

    public void Set(string key, string value, int timestamp) {
        if (!m.ContainsKey(key)) {
            m[key] = new SortedDictionary<int, string>();
        }
        m[key][timestamp] = value;
    }

    public string Get(string key, int timestamp) {
        if (!m.ContainsKey(key)) return "";
        var timestamps = m[key];
        if (timestamps.TryGetValue(timestamp, out string value)) {
            return value;
        }
        var lastEntry = timestamps.LastOrDefault(pair => pair.Key <= timestamp);
        return lastEntry.Equals(default(KeyValuePair<int, string>)) ? "" : lastEntry.Value;
    }
}