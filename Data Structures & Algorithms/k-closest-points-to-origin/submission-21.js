class Solution {
    /**
     * @param {number[][]} points
     * @param {number} k
     * @return {number[][]}
     */
    kClosest(points, k) {
        let L = 0, R = points.length - 1, pivot = points.length;

        while (pivot !== k) {
            pivot = this.partition(points, L, R);
            if (pivot < k) {
                L = pivot + 1;
            } else {
                R = pivot - 1;
            }
        }
        return points.slice(0, k);
    }

    /**
     * @param {number[][]} points
     * @param {number} l
     * @param {number} r
     * @return {number}
     */
    partition(points, l, r) {
        const pivotIdx = r;
        const pivotDist = this.euclidean(points[pivotIdx]);
        let i = l;
        for (let j = l; j < r; j++) {
            if (this.euclidean(points[j]) <= pivotDist) {
                [points[i], points[j]] = [points[j], points[i]];
                i++;
            }
        }
        [points[i], points[r]] = [points[r], points[i]];
        return i;
    }

    /**
     * @param {number[]} point
     * @return {number}
     */
    euclidean(point) {
        return point[0] ** 2 + point[1] ** 2;
    }
}