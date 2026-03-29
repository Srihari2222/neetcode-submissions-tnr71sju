public class Solution {
    
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> prereq = new Dictionary<int, List<int>>();
        foreach (var pair in prerequisites) {
            if (!prereq.ContainsKey(pair[0])) {
                prereq[pair[0]] = new List<int>();
            }
            prereq[pair[0]].Add(pair[1]);
        }

        List<int> output = new List<int>();
        HashSet<int> visit = new HashSet<int>();
        HashSet<int> cycle = new HashSet<int>();

        for (int course = 0; course < numCourses; course++) {
            if (!Dfs(course, prereq, visit, cycle, output)) {
                return new int[0];
            }
        }

        return output.ToArray();
    }

    private bool Dfs(int course, Dictionary<int, List<int>> prereq,
                     HashSet<int> visit, HashSet<int> cycle, 
                     List<int> output) {
                        
        if (cycle.Contains(course)) {
            return false;
        }
        if (visit.Contains(course)) {
            return true;
        }

        cycle.Add(course);
        if (prereq.ContainsKey(course)) {
            foreach (int pre in prereq[course]) {
                if (!Dfs(pre, prereq, visit, cycle, output)) {
                    return false;
                }
            }
        }
        cycle.Remove(course);
        visit.Add(course);
        output.Add(course);
        return true;
    }
}