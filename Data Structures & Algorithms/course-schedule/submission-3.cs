public class Solution {
    // Map each course to its prerequisites
    private Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
    // Store all courses along the current DFS path
    private HashSet<int> visiting = new HashSet<int>();

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        for (int i = 0; i < numCourses; i++) {
            preMap[i] = new List<int>();
        }
        foreach (var prereq in prerequisites) {
            preMap[prereq[0]].Add(prereq[1]);
        }

        for (int c = 0; c < numCourses; c++) {
            if (!Dfs(c)) {
                return false;
            }
        }
        return true;
    }

    private bool Dfs(int crs) {
        if (visiting.Contains(crs)) {
            // Cycle detected
            return false;
        }
        if (preMap[crs].Count == 0) {
            return true;
        }

        visiting.Add(crs);
        foreach (int pre in preMap[crs]) {
            if (!Dfs(pre)) {
                return false;
            }
        }
        visiting.Remove(crs);
        preMap[crs].Clear();
        return true;
    }
}