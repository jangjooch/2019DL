dumy01 = 1
data01 = seq(as.Date("2019-01-01"),as.Date("2019-02-02"),1)
data01
data01 = seq(as.Date("2019-01-01"),as.Date("2019-12-02"),'month')
# seq(a,b,단위) a부터 b까지 단위만큼 증가하면서 진행.
data01
objects()
# 정보가 저장된 변수들 출력
rm(dumy01)
# 해당 변수 삭제
rm(list=ls())
# 전체 삭제

# 데이터 처리 객체

# -동일 데이터 타입
# 스칼라 : 단일 데이터 처리
# 벡터 : 1차원 배열
# matrix : 2차원 배열 (벡터를 여러개 합친것)
# array(배열) : 3차원 배열. 큐브형태. maatrix를 쌓아올린것.

#-다른 데이터 타입
# list : 벡터와 비슷. BUT (Key, Value) 형태로 저장.
# dataframe : 엑셀의 표나 DB의 데이블과 같음.


# 벡터. -> 1차원 배열
# 1. c() 함수
# 2. 인덱스는 1부터 시작
# 3. 하나의 자료형만 가능
# 4. 결측값은 NA이다.
# 5. NULL은 어떠한 형식도 취하지 않는 특별한 개체.
sc01 <- c(1,2,3,4,5) # 스칼라
vect01<-sc01 # 벡터.
vect01[-2:-4] # 특정 위치의 요소 제외하고 출력
vect01[1:(length(vect01)-2)] # 특정요소부터 얼마만큼 출력
vect01[2] <- 22 # 인덱스 2의 위치의 것을 22로 변경
vect01
vect01 = c(vect01,7) # vect01의 마지막에 7을 추가
vect01
vect01[9]<-9
# vect01의 9번 위치에 9를 삽입. 단 늘어났을 경우 비어있는 공간은 NA로 줌
vect01
vect01 = append(vect01,10,after=3)
# vect01의 인덱스 3 뒤에 10을 삽입. 즉 위치 4에 삽입.
vect01
vect01 = append(vect01,11,after=3)
vect01

vect02 <- c(1,2,3)
vect03 <- c(11,22,33)
vect04 <- vect02 + vect03
vect04
# 같은 자료형일 경우 각 index값에 더해준다. 즉 길이변화가 없다.
# 같은 자료형일 경우 연산자 사용이 가능하다.
vect05 <- c('11','22','33')
vect04 = union(vect02, vect05)
vect04
# 자료형이 다르어 union을 사용했을경우 string형식으로 독립적으로 뒤에 붙는다.
# 즉 길이가 변한다.
setdiff(vect02,vect03) #<- 겹치지 않는것.
intersect(vect02,vect03) # <- 교집합
fruits = c(10,20,30)
names(fruits) = c('Apple','Banana','peach')
# name()으로 인한 벡터에 콜륨생성.
fruits

nums01 = seq(1,5)
nums01
nums01 = seq(-3,2)
nums01
nums01 = seq(1, 10, 2)
nums01
# seq에 의한 증감규칙에 따른 데이터 형성.
nums01 = rep(1:3,2)
nums01
# 위와같은 규칙의 req는 단순히 seq를 반복.
nums01 = rep(1:3,each=2)
nums01
# 위와같은 형식은 each로서 각기 추가될때마다 해당 수 만큼 더 추가.
nums02 = seq(1,10,2)
nums02
length(nums02)
NROW(nums02)
5%in% nums02
# 특정 인자가 해당 벡터에 속해있나. boolean리턴.

# MATRIX
# 1. 벡터를 여러개 합친 형태 : 행렬
# 2. 모든 컬럼과 행은 데이터형이 동일
# 3. 기본적으로 열로 생성
# 4. 다른 데이터 타입의 데이터를 저장하는 경우 데이터 프레임 사용.

mat01 = matrix(c(1,2,3,4))
mat01
mat01 = matrix(c(1,2,3,4),nrow=2)
# nrow는 행의 갯수임. 위처럼 된다면 [1,3][2,4] 처럼 된다.
# 단 nrow가 %가 0이 아니게 된다면 오류뜸. 행 기준으로 삽입되기 때문.
mat01
mat01[1,]
# 모든 열의 1행을 가져와라.
mat01[1,1]
# 1행 1열을 가져와라.
# 새로운 열과 행 추가. rbind(), cbind()
mat04 = matrix(c(1,2,3,
                 4,5,6,
                 7,8,9), nrow = 3)
mat04
mat04 = matrix(c(1,2,3,
                 4,5,6,
                 7,8,9), nrow = 3,byrow = T)
mat04
# byrow를 통한 열기준으로 변경.
mat04 = rbind(mat04,c(11,22,33))
# row 열추가. 단 행의 수에 맞추어 넣어주어야 한다. 그렇지 않으면 짤린다.
mat04
mat04 = rbind(mat04,c(44,55,66))
mat04 = cbind(mat04,c(111,222,333))
mat04
# colume 추가. 행추가.  단 열의 수에 맞추어 넣어주야한다.
# 만약 모자르면 그만큼 반복해서 넣는다.
colnames(mat04) = c("first","second","third","fourth")
mat04
# colume의 이름을 정해줄때는 길이를 정확하게 하여야한다.
# 그렇지 않다면 많든 적든 실행되지 않는다.

# Array
# 3차원 배열.(가로, 세로, 높이)
arr01 = array(c(1:12), dim = c(4,3))
# dimantion으로서 1개 차원의 행과 열을 정한다. 물론 행 기준이다.
arr01
arr01 = array(c(1:12), dim = c(2,2,3))
# dimantion으로서 가로, 세로, 높이를 정한다.
arr01
arr01[1,1,3]
# 1행1렬의 3층의 요소.9

# list
# 벡터와 비슷한 형태로 (키, 값)
list01 = list(name="kim",addr="Seoul",tel = "123",pay=500)
# 위와 같이 데이터 형이 혼합되어 사용할 수 있다.
list01$name
# Key값을 통하여 Value값을 불러올 수 있다.
list01$birth='2019-07-16'
list01
# 없던 Key값과 그에 해당한 Value를 줌으로서 추가할 수 있다.
list01$name=c("lee","park")
list01$name
# 이렇게 name의 value를 변경할 수 있다.
list01$birth=NULL
list01
# 특정 key의 value에 NULL을 줌으로서 해당 Key를 삭제한다.

# 데이터 프레임
# 1. 벡터로부터 데이터 프레임 생성
# 2. 각 컬럼별로 먼저 생성한 data.frame 명령어로 모든 컬럼을 합친다.
no = c(1,2,3,4)
name = c("Apple","Peach","Banana","Grape")
price = c(1000,2000,3000,4000)
qty = c(15,16,17,18)
sales_frame = data.frame(No=no,Name=name,Price=price,QTY=qty)
sales_frame
sales_matrix = matrix(c(1,'apple',1000,15,
                   2,'peach',2000,16,
                   3,'banana',3000,17,
                   4,'grape',4000,18),nrow=4,byrow = T)
sales_matrix
frame01 = data.frame(sales_matrix)
# 하지만 이렇게 생성하면 matrix특성상 데이터 형이 다르면 string으로 통합하기에
# int형이였던 것들을 처리하기 힘들다.

names(frame01) = c('No',"Name",'Price','Qty')
# colume 생성.
frame01
frame01[1,3]
frame01[1, ]
# 1열
frame01[ ,3]
# 3행
frame01[c(1,2),]
# 모든 열의 1행과 2행
frame01[,c(1,2)]
# 모든 행의 1열과 2열
frame01[,c(1,3)]
# 모든 행의 1부터 3까지의 열
subset(frame01,qty<17)
# 조건문을 사용토록 할 수 있다.
# 단 연산자의 경우 matrix는 데이터형이 다랐을면 string으로 통합되기에
# int형이었던 것들을 연산자를 통해 할 수 없다.
# 
colnames(sales_matrix) = c("No",'Name','Price','Qty')
# colume 추가.
sales_matrix$QTY = as.numeric(as.character(sales_matrix$QTY))
# 이러한 형식으로 강제적으로 numeric으로 변환 할 수 있다.
# string을 가져와 형태를 다시 numeric으로 변환한다.
sales_matrix










