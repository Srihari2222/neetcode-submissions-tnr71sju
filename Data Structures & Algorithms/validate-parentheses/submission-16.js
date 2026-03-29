class Solution {
    /**
     * @param {string} s
     * @return {boolean}
     */
    isValid(s) {
let par = {
'}':'{',
']':'[',
')':'('
}

    for(let p of s){
        if(p == par){
            return false;
        }else{
            return true;
        }
    }
}
}
