class Solution {
public:
    int getGap(int gap) {
        if(gap == 1) return 0;
        return gap/2 + gap%2;
    }
    double res(vector<int> nums, int n) {
        if(n%2 == 1) {
            return nums[n/2];
        } else {
            return (double) (nums[n/2-1] + nums[n/2])/2;
        }
    }
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        int n = nums1.size();
        int m = nums2.size();
        if(n==0) return res(nums2, m);
        if(m==0) return res(nums1, n);
        int gap = m+n;
        while(gap!=0) {
            gap=getGap(gap);
            for(int i=0;i+gap<m+n;i++) {
                if(i<n && i+gap<n) {
                    if(nums1[i]>nums1[i+gap]) {
                        swap(nums1[i],nums1[i+gap]);
                    }
                } else if(i<n && i+gap>=n) {
                    if(nums1[i] > nums2[(i+gap)-n]) {
                        swap(nums1[i] , nums2[(i+gap)%n]);
                    }
                } else if(i>=n) {
                    if(nums2[i-n] > nums2[(i+gap)-n]) {
                        swap(nums2[i-n] , nums2[(i+gap)-n]);
                    }
                }
            }
        }
        if((n+m) % 2 == 1 ) {
            int mid = (n+m)/2;
            if(mid >= n) {
                return nums2[mid-n];
            } else {
                return nums1[mid];
            }
        } else {
            int mid = (n+m)/2-1;
            int mid2 = mid+1;
            if(mid<n && mid2<n) {
                return (double)(nums1[mid]+nums1[mid2])/2;
            } else if(mid<n && mid2>=n) {
                return (double)(nums1[mid]+nums2[mid2-n])/2;
            } else {
                return (double)(nums2[mid-n]+nums2[mid2-n])/2;
            }
        }
        return 0.1;
    }
};