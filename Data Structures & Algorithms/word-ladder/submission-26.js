class Solution {
    /**
     * @param {string} beginWord
     * @param {string} endWord
     * @param {string[]} wordList
     * @return {number}
     */
    ladderLength(beginWord, endWord, wordList) {
        if (!wordList.includes(endWord) || 
            beginWord === endWord) {
            return 0;
        }
        const m = wordList[0].length;
        const wordSet = new Set(wordList);
        const qb = [beginWord], qe = [endWord];
        const fromBegin = { [beginWord]: 1 };
        const fromEnd = { [endWord]: 1 };

        while (qb.length && qe.length) {
            if (qb.length > qe.length) {
                [qb, qe] = [qe, qb];
                [fromBegin, fromEnd] = [fromEnd, fromBegin];
            }
            const size = qb.length;
            for (let k = 0; k < size; k++) {
                const word = qb.shift();
                const steps = fromBegin[word];
                for (let i = 0; i < m; i++) {
                    for (let c = 97; c <= 122; c++) {
                        if (String.fromCharCode(c) === word[i])
                            continue;
                        const nei = word.slice(0, i) + 
                                    String.fromCharCode(c) + 
                                    word.slice(i + 1);
                        if (!wordSet.has(nei))
                            continue;
                        if (fromEnd[nei] !== undefined)
                            return steps + fromEnd[nei];
                        if (fromBegin[nei] === undefined) {
                            fromBegin[nei] = steps + 1;
                            qb.push(nei);
                        }
                    }
                }
            }
        }
        return 0;
    }
}