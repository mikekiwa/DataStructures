import time

def urlify(s):
    return s.strip().replace(' ', '%20')

def urlify1(s):
    s = s.strip()
    for i in range(len(s)):
        if s[i] == ' ':
            s = s[:i] + '%20' + s[i+1:]

    return s

if __name__ == '__main__':
    start_time = time.clock()
    print(urlify('Mr. John Smith    '))
    print(time.clock() - start_time)

    start_time = time.clock()
    print(urlify('Mr. John Smith'))
    print(time.clock() - start_time)

    start_time = time.clock()
    print(urlify('     Mr. John Smith'))
    print(time.clock() - start_time)

    start_time = time.clock()
    print(urlify1('Mr. John Smith    '))
    print(time.clock() - start_time)

    start_time = time.clock()
    print(urlify1('Mr. John Smith'))
    print(time.clock() - start_time)

    start_time = time.clock()
    print(urlify1('     Mr. John Smith'))
    print(time.clock() - start_time)