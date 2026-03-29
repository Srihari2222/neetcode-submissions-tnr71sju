class Solution {
    Set<List<String>> res = new HashSet<>();
    public List<List<String>> partition(String s) {
        if(s.length() == 0) return new ArrayList<>();
        String temp = "" + s.charAt(0);
        List<String> init = new ArrayList<>();
        init.add(temp);
        call(init, s,1);
        return new ArrayList<>(res);
    }
    void call(List<String> curr, String s,int index) {
        if(index == s.length()) {
            boolean isPalindrome = true;
            for(int i=0;i<curr.size();i++) {
                if(!checkPalindrome(curr.get(i))) {
                    isPalindrome = false;
                    break;
                }
            }
            if(isPalindrome) res.add(curr);
            return;
        }
        String last = curr.get(curr.size() -1);
        last += s.charAt(index);
        List<String> firstKind = new ArrayList<>(curr);
        firstKind.set(firstKind.size()-1,last);
        call(firstKind, s, index+1);
        List<String> secKind = new ArrayList<>(curr);
        String temp = "" + s.charAt(index);
        secKind.add(temp);
        call(secKind,s,index+1);
    }

    boolean checkPalindrome(String element) {
        int i=0;
        while(i < (element.length()-1-i)) {
            if(element.charAt(i) != element.charAt(element.length()-1-i))
            return false;
            i++;
        }
        return true;
    }
}