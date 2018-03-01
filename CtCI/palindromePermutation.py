def palinPermutation(s):
    s = s.lower()
    s = s.replace(' ', '')
    letters = dict()

    for val in s:
        if val not in letters.keys():
            letters[val] = 1
        else:
            letters[val] += 1

    count = 0

    for key in letters.keys():
        if letters[key] % 2 != 0:
            count += 1

    if count > 1:
        return False

    return True

if __name__ == '__main__':
    print('Yes' if palinPermutation('Taco Coa') else 'No')