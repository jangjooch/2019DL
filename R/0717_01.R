# 한줄 명령어 혹은 블록 명령어 실행은 ctrl + enter
# 혹은 Histroy에서 블록을 지정하여 실행할 수 있다.
setwd("h\\r_work\\data")
# 불러올 데이터 경로 설정.
getwd()
print(1)
print('a')
mode(1)
mode("a")
class("A")
# 객체까지 표현이 가능하다.
print(pi)
print(pi,digits = 3)
# pi는 기본적인 설정인 float이다.
# 하지만 기본저그올 7번째자리까지 출력이 되기에
# digit=3으로 3번째 자릿수까지만 출력토록 한다.
print(1,2)
# output = 1. 기본적으로ㅓ print에서는 1개만 출력된다.
#print('a','b')
# string 형같은 경우에는 아예 오류가 뜬다.
# 그렇기에 cat을 사용한다.

cat(1,2,3,4)
cat('a','b','c')
cat(1, ":",'a','\n',5)

1;2;3;4;
# 구분하여 출력한듯
5+5
5%/%2
# 나눈것의 정수값.
5%%2
# 나눈것의 나머지값.
3^2
# ^n 은 n승한다는 것.
3**2
# 이것도 n승한다는 것.
10000
100000
# 0이 5개 이상부터는 지수형태로 출력.
1e2
3e2
3e-2
# 지수형태 예제.
'1'
#'1'+'2'
# string 형에 대한 연산자 안됨.
as.numeric('1') + as.numeric('2')
# as.xxx() 내부의 것을 강제 형변환 한것.
'first'
class('first')

first <- 0
class(first)
# first <- 0이 실행 됨으로서 first라는 변수가 생성되고 초기화 되는 것이다.
# 그렇기에 초기화 과정이 실행되지않고 class(first)를 한다면 오류남.
first <- 'a'
class(first)
# NA 는 잘못된 값이 들오온 경우. Not Applicable, Not Available
# NULL 은 값이 없을 경우.

sum(1,NA,2)
# output이 NA가 나온다. 요소에 잘못된 값이 있으므로.
sum(1,NULL,2)
sum(1,NA,2,na.rm = T)
# na.rm = T 로 인하여 NA가 잘못된 값이라도 True로 인식하여 일시적으로 NULL로 인식토록 한다.









