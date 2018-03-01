import time

def checkPermutation(s1, s2):
    if len(s1) != len(s2):
        return False

    letters = dict()

    for value in s1:
        if not value in letters.keys():
            letters[value] = 1
        else:
            letters[value] += 1

    for value in s2:
        if not value in letters.keys():
            return False
        else:
            letters[value] -= 1
            if letters[value] < 0:
                return False

    return True

if __name__ == '__main__':
    start_time = time.clock()
    print('Yes' if checkPermutation('abvncuythrjfkgloturi', 'riyacukglotuthbvnrjf') else 'No')
    print(time.clock() - start_time)
    start_time = time.clock()
    print('Yes' if checkPermutation('abvabvncuythrjfkgloturabvncuythrjfkgloturiincuyabvncuytabvncuythrjfkgloturihrjfkgloturithrjfkgloturi', 'riyacriyariyacuriyacukglotuthbriyacukglotuthbvnrjrvnrjfkglotuthbvnrjfcukglotuthbvnrjfukglotuthbvnrjf') else 'No')
    print(time.clock() - start_time)