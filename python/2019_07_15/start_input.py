str_01 = 'a'
str_02 = 'b'
int_01 = 5
print(str_01+str_02,int_01)
print(str_01+str_02,int_01,sep='')
# sep은 , 를 사용하는 경우 디폴트는 ' ' 이기 때문에
# 공간을 하나 두지만 위의 경우와 같이 ''로 설정한다면
# 붙어서 출력이 이루어 진다.
# 이를 이용하여 여러가지 , 를 사용하는 경우 이를 구분하기 위한
# 것으로 사용될 수 있다. 예로 sep ='$ ' 라고 표현하여
# 모든 , 가 들어가는 위치에 '$ '를 넣을 수 있다.

inputnum01 = input('type num01 : ')
inputnum01 = int(inputnum01)
print("Converted input01 + 10 = ",inputnum01+10)
inputnum02 = int(input("type num02 : "))
# 입력받는 것과 동시에 int형으로 반환.
print("add num01 and num02 = ", inputnum01+inputnum02)
inputnums = str(inputnum01) + str(inputnum02)
# stirng 형으로 변환은 str()
print("connect 2 inputnums by converted to str : "+inputnums)