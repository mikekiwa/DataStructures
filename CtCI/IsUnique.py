# Implement an algorithm to determine if a string has all unique characters. What if you
# cannot use additional data structures

import time

# This solution has a complexity of O(N + NlogN)
# Sorting takes NlogN time and then linear time to run through the string for duplicates
# This algorithm does not use any extra space
def isUnique(s):
    if len(s) > 128:
        return False
    sorted(s)

    for i in range(len(s) - 1):
        j = i + 1
        if s[i] == s[j]:
            return False
    return True

if __name__ == '__main__':
    start_time = time.clock()
    print('Yes' if isUnique('`1234567890-=~!@#$%^&*()_+qwertyuiop[]{}\|asdfghjkl::""zxcvbnm<<>>??') else 'No')
    print(time.clock() - start_time, ' seconds')