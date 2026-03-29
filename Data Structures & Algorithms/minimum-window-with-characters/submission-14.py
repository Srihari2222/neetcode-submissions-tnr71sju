class Solution:
    def minWindow(self, s: str, t: str) -> str:
        tdict = dict()
        results = []
        for char in t:
            if char not in tdict:
                tdict[char] = 1
            else:
                tdict[char] +=1

        left =0 
        right = 0
        running = dict()
        found = False
       
        while right < len(s):
            print(running, left, right)

            successflag = True
            if s[right] not in running:
                running[s[right]] = 1
            else:
                running[s[right]] += 1

            #Pruning 
            if found == True and s[right] in tdict:
                while s[left] != s[right]:
                    if running[s[left]] == 1:
                        del running[s[left]]
                    else:
                        running[s[left]] -=1
                    left += 1
                running[s[left]] -=1
                left += 1
                found = False

            for key, value in tdict.items():
                if key not in running:
                    successflag = False
                elif running[key] < value:
                    successflag = False

            
            if successflag:
    
                while s[left] not in tdict:
                    if running[s[left]] == 1:
                        del running[s[left]]
                    else:
                        running[s[left]] -=1

                    left += 1

                while left < right and s[left] == s[left+1] and running[s[left]] > tdict[s[left]]:
                    if running[s[left]] == 1:
                        del running[s[left]]
                    else:
                        running[s[left]] -=1
                    print()

                    left += 1

                found = True
                results.append(s[left:right+1])
            


            right +=1

        print(results)
        if len(results) == 0:
            return ""
        else:
            results.sort(key=len)
            return results[0]


        