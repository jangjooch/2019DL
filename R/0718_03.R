
Fruits

# sweep() : 한번에 차이를 구하는 함수
# 여러데이터에게 일괄적 기준을 적용.
# 벡터, 메트릭스, 배열, 데이터프레임으로 구성된 여러 데이터들에 동일한
# 기준을 적용시켜서 차이나는 부분을 보여준다.
mat01 = matrix(c(1,2,3,4,5,6), nrow = 2, byrow = T)
mat01
a = c(1,1,1)
sweep(mat01,2,a)

# length(). 열의 수.
length(Fruits)
Fruits

# abs(). 절댓값.
abs(-1)

# ceiling(). 소수점이하 올림.
v03 = c(1.2,1.9,2.1,11.1)
ceiling(v03)

# choose(). 5 conbination 3. 5C3 = (5*4*3)/(3*2*1)
choose(5,3)

# cos(). 코사인.
cos(1)

# exp() 지수함수.
exp(5)

# factorial(). 펙토리얼

# floor(). 소수점이하 내림.
floor(v03)

#trunc(). 0와 인자사이에서 가장 큰 정수.
trunc(-8.9)
trunc(2.5)

# log(), log10()

# sqrt(). 스퀘어 루트

# 사용자정의 함수
# 함수명 = function(인수 또는 입려값)
#{
#   계산식1; 계산식2; Return(반환될 값);
#}
myfunc01 = function(){
  return(10)
}
myfunc01()
myfunc01
# ()없이 호출하면 함수의 모양 출력.
myfunct02 = function(a){
  b = a^2
  return(b)
}
myfunct02(10)

ggplot2::geom_bar
# ::을 통하여 library 내부의 함수를 찾을 수 있다.

sort01 = Fruits$Sales
sort01
sort(sort01)
# 올림차순
sort(sort01,decreasing = T)
# 내림차순.

# plyr() 패키지 : 원본데이터를 분석하기 쉬운형태로
# 나누어서 다시 새로운 형태로 만드러주는 패키지.

# apply함수를 확장.
# XXply() : 첫번째, X은 입력될 데이터의 유형.
# 두번째 X는 출력될 데이터의 유형.
# d : data_frame
# a : array(matrix까지 포함.)
# l : list
# ex) daplt : 데이터 프레임으로 입력받아 array로 반환.
# ex) aaply : array로 입력받아 array로 반환.

install.packages("plyr")
library(plyr)
fruits = read.csv("fruits_10.csv", header = T) # csv는 header디폴트가 T이다.
fruits
# ddply(data, 기준컬럼, 적용 함수 및 결과 들)
ddply(fruits,'name',summarise,sum_qty = sum(qty), sum_price = sum(price))
# summarise는 기존 컬럼의 데이터끼리 모은 함수를 적용해서 출력해 준다(group by).
# 동일한 name끼리 모은후 max(qty), min(price) 함수를 적용시켜 출력.
ddply(fruits,'name',summarise,max_qty = max(qty),min_price = min(price))
# 기준이 2개일 경우.
# year별, name별 최대 판매량과 최저가격.
ddply(fruits,c('year','name'),summarise,max_qty = max(qty),min_price = min(price))

# transform : 만약 동일한 값의 합계가 아닌 각 행별로
# 연산을 수행애서 해당 값을 함께 출력할 경우
# pct_qty는 해당 과일의 판매수량이 기준 컬럼으로
# 합계한 총 판매 개수대비 몇 %를 차지하는 가.
ddply(fruits,'name',transform,sum_qty=sum(qty),pct_qty=(100*qty)/sum(qty))

# dplyr() 패키지
# 특징
# 1. filter : 조건을 주어서 필터링.
# 2. select : 여러 컬럼이 있는 데이터 셋에서 특정 컬럼만 선택해서 사용.
# 3. arrange : 오름/내림차순 정렬.
# 4. mutate : 기존의 변수를 활용해서 새로운 변수 생성.
# 5. summarise : 주어진 데이터를 집계(min, max, mean, count)
library(dplyr)
data01 = read.csv("2013년_프로야구선수_성적.csv")
data01
# filter
# 경기수가 120이상인 선수.
data02 = filter(data01,경기>120)
data02
# 경기수가 120이상이면서, 득점도 80점 이상인 선수.
filter(data01, 경기>120 , 득점>80)
filter(data01, 경기>120 & 득점>80)
# 포지션이 1루수와 3루수인 선수.
filter(data01, 포지션%in% c("1루수","3루수"))
# Colume%in% Value를 이용한 필터링.

# 선수명, 포지션, 팀 컬럼만 조회
select(data01, 선수명, 포지션, 팀)
# 순위 ~ 타수 컬럼까지 출력. 컬럼의 범위를 연속적으로 지정.
select(data01,순위:타수)
# 특정 컬럼만 제외하고 출력.
select(data01, -홈런, - 도루)

# 여러 명령어들을 조합해서 사용하는 경우. %>%
# 선수명, 팀, 경기, 타수를 조회하되, 타수가 400이상인 선수들을 타수로 정렬.
data01%>%select(선수명,팀,경기,타수)%>%filter(타수>400)%>%arrange(타수)
# data01을 부르되 칼럼을 특정(select)하고 조건(filter)를 붙인다.
data01%>%select(선수명,팀,경기,타수)%>%mutate(경기X타수 = 경기*타수)%>%arrange(타수)
# 타수 400 이상이 아닌, [경기X타수]라는 새로운 컬럼을 생성.
# 
data01%>%select(선수명,팀,경기,타수,안타)%>%mutate(안타율 = 안타/타수)%>%arrange(타수)
# 단 mutate에 사용될 변수들은 select에 포함되어야 잘리지 않고 사용될 수 있다.
data01%>%select(선수명,팀,경기,타수,안타)%>%mutate(안타율 = round(안타/타수,3))%>%arrange(타수)
# round를 통한 할푼리 표현.
# 팀별로 평균 경기 횟수.
data01%>%group_by(팀)%>%summarise(average = mean(경기,na.rm = T))
# 팀 이라는 칼럼으로 그룹 생성 -> average라는 컬럼은 경기의 mean이고 na값은 없앤다.
# 여러 컬럼을 대상으로 집계
# 팀별로 경기와 타수의 평균을 각각 구하라.
data01%>%group_by(팀)%>%summarise_each(funs(mean,n()),경기, 타수)
# summerise_each는 각각. funs는 function

# reshape2() 패키지.
install.packages("reshape2")
library(reshape2)
fruits
# melt() : wide->long
melt(fruits,id = 'year')
# 년도를 기준으로 가격 수량을 따로 가져옴.
melt(fruits,id = c('year','name'))
# year와 name이 묶여 출력.
melt(fruits,id = c('year','name'),variable.name = 'var_name', value.name = 'var_name')
# 출력될 컬럼의 이름을 특정함.
# cast() : long->wide
mtest = melt(fruits,id = c('year','name'),variable.name = 'var_name', value.name = 'val_name')
mtest
# dcast과정을 통해 원래 모양으로 돌아옴.
dcast(mtest,year+name~var_name)
# year와 name 은 그대로 두고 이후부터 var_name까지를 decast한다.
# mtest 데이터 셋에 함수를 적용해서 name별 qty합계 수량과 price합계금액을 출력.
dcast(mtest,name~var_name,sum)
# decast(data, 기준컬럼 ~ 대상컬럼, 적용함수)
dcast(mtest,name~var_name,sum,subset = .(name=='apple'))
# subset = .(name=='apple') 을 통하여 출력되는 것을 filter함.

# stringr() 패키지 : 작업할 대상 데이터가 문자일 경우.
install.packages("stringr")
library(stringr)
fruits
fruits = c('Apple','banana','pineapple')
str_detect(fruits,'A')
# 문자에 대문자 A가 속하여있나.
str_detect(fruits,'^a')
# 첫글자가 소문자 a인 경우
str_detect(fruits,'e$')
# 글자의 끝이 소문자 e가 있나.
str_detect(fruits,'^[aA]')
# 첫글자가 a혹은 A인가
str_detect(fruits,fixed(('Apple'),ignore_case = T))
str_detect(c('abb','a.b'),'a.b')
# a와 b가 존재하는 지
str_detect(c('abb','a.b'),fixed('a.b'))
# 정확하게 a.b가 있는지.
str_count(fruits,fixed('a',ignore_case = T))
# a의 카운트. ignore_case는 대소문자 포함.
str_count(fruits,'a')
# 정확히 소문자 a의 수.
str_c('apple','pen')
# string 붙이기.
str_c("Fruits : ",fruits)
# :로 인한 fruits 각각에 붙여짐
str_c(fruits, 'is ', fruits)
str_c(fruits, collapse = " | ")
# collapse는 구분자 설정.
str_dup(fruits,3)
# duplicate. 반복을 통한 설정.
str_length('apple')
# string길이.
str_length(fruits)
# 각 요소에 대한 길이
str_locate(fruits,'banana')
str_locate(fruits,'a')
# 첫번째 있는 것만 출력.
str_replace('apple','p','*')
# 첫번째 p를 *로 바꾼다.
str_replace_all('apple','p','*')
# 모두 바꿈.
# str_split() : 주어진 데이터셋을 지정된 기로호 분리.
fruits = str_c('apple','/','banana','/','pineapple')
fruits
str_split(fruits,'/')
# str_sub : 지정된 길이만큼 문잘르 잘라낸다.
fruits
str_sub(fruits,start = 1, end = 3)
# 1부터 3까지 잘라낸다.
str_sub(fruits,start = -9)
# 뒤에서부터 5개를 잘라낸다.
# str_trim : 문자열의 가장 앞과 가장 뒤에 공백 제거
str_trim('    apple banana pineapple   ')

mf1 = function(x){
  if(x>0){
    x = x*x
  }
  else{
    x = x*0
  }
  return(x)
}
mf1(-9)
mf1(5)

# ifelse(a,b,c) : a가 참이면 b를 출력, 거짓이면 c를 출력.
no = scan()
ifelse(no%%2==0,'짝수','홀수')
no = 0
while(no<5){
  print(no)
  no = no+1
  if(no%%2 == 0){
    next    
  }
  else{
    print(no)
  }
}
for01 = function(x){
  for(i in 1:x){
    print(i)
  }
}
for01(3)

# 사용자에게 정수 n을 입력받은 후 1부터 n까지의 합을 구하라.
fun_input = scan()
for_sum = function(x){
  sum = 0
  for(i in 1:x){
    sum =sum + i
  }
  return(sum)
}
for_sum(fun_input)
