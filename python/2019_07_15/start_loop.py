for i in range(1,5):
    for j in range(i):
        print('*',end = '+')
        # end의 기본값은 \n이기 때문에 ''를 주어 그냥 진행토록 한다.
    print()

collection01 = [1,3,5,7,9,11]
i = 0
print(collection01)
for contain in collection01:
    print(str(i) + "'s contain : " + str(contain))
    i = i+1

for y in range(1,10):
    for z in range(9-y):
        print(' ', end = " ")
    for x in range(y):
        print('*', end = ' ')
    print()

for c in range(ord('A'), ord('a')+1):
    print(chr(c), end=' ')
    # ord('A') -> start, ord('a') -> end로 설정된다.
    # end에서 ord('a')라고만 되어있다면 a전 까지만 출력된다.
    # 즉 a까지 나오도록 하려면 +1을 주어 해당 전까지 출력되라 설정해야 한다.

