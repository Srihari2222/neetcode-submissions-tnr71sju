class Solution {
public:
    vector<vector<int>> kClosest(vector<vector<int>>& points, int k) {
        int L = 0, R = points.size() - 1;
        int pivot = points.size();

        while (pivot != k) {
            pivot = partition(points, L, R);
            if (pivot < k) {
                L = pivot + 1;
            } else {
                R = pivot - 1;
            }
        }
        return vector<std::vector<int>>(points.begin(), points.begin() + k);
    }

private:
    int partition(vector<vector<int>>& points, int l, int r) {
        int pivotIdx = r;
        int pivotDist = euclidean(points[pivotIdx]);
        int i = l;
        for (int j = l; j < r; j++) {
            if (euclidean(points[j]) <= pivotDist) {
                swap(points[i], points[j]);
                i++;
            }
        }
        swap(points[i], points[r]);
        return i;
    }

    int euclidean(vector<int>& point) {
        return point[0] * point[0] + point[1] * point[1];
    }
};