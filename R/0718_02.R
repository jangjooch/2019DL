
setwd("H:\\r_work\\data")
getwd

install.packages("googleVis")
library(googleVis)
install.packages("sqldf")
library(sqldf)
Fruits
write.csv(Fruits,"")
write.csv(Fruits,"Dangi_sql.csv",quote=F,row.names = F)
# Fruits를 통한 csv 파일 생성.
fruits = read.csv.sql("Dangi_sql.csv",sql = "select * from file where Year = 2008")
# 위에서 저장한 csv파일을 sql를 통하여 조건을 돌리고 해당 내용을 fruits에 저장.
fruits
txt1 = read.csv("csv_test.txt")
txt1
txt2 = readLines("csv_test.txt")
txt2
# readLine은 단순하게 한개의 배열로 저장ㄹ한다.
txt3 = read.table("csv_test.txt")
txt3
# 구분은 되었지만 colume은 안됨. 그렇기에 구분자를 지정해 준다.
txt3 = read.table("csv_test.txt",sep = ",",header = T)
# 이렇듯 구분자를 지정하고, colume이 있으면 header까지.
txt3
txt1 = readLines("write_test.txt")
txt1
write(txt1,"write_Dangi.txt")
txt2 = readLines("write_Dangi.txt")
txt2
# 이렇듯 WriteLine으로 쓴것은 writeLine으로 읽고
# csv로 쓴것은 csv로 읽어야 한다.

??ggplot2
# 해당 라이브러리를 help에 띄움.
vect01 = c(1,2,3,4,5)
vect02 = c('a','b','c','d','e')
max(vect01)
max(vect02)
min(vect01)
mean(vect01)
var(vect01)
# 적용 함수.

library(googleVis)
Fruits
# Fruits는 googleVis에 있는 것이다.
aggregate(Sales ~ Year, Fruits,sum)
# 문법. (계산될 colume ~ 기준될 colume, 데이터, 함수.)
# 년도 별로 팔린 갯수.
aggregate(Sales ~ Fruit, Fruits,sum)
# 과일 별로 팔린 갯수.
aggregate(Sales ~ Fruit+Year, Fruits,sum)
# 각 과일에 대한 년도별 팔린갯수.

# apply() : 행이나 열을 대상으로 작업을 하기에
# 메트릭스에 사용하기 용이하다.
# 문법 : apply(대상, 행 또는 열, 적용함수)
mat01 = matrix(c(1,2,3,4,5,6), nrow = 2, byrow = T)
# 2행 3열, 행기준으로 데이터 삽입.
mat01
apply(mat01, 1, sum)
# 각 행의 합계를 구하라.
apply(mat01, 2, sum)
# 각 열의 합계를 구하라.
apply(mat01[,c(2,3)],2,sum)
# 모든 행에서 2행과 3행의 열의 합계를 구하라

# lappy/sappy(대상, 적용함수) : list 처리.
list01 = list(Fruits$Sales)
list01
list02 = list(Fruits$Profit)
list02
lapply(c(list01,list02), max)
# 각각 list01과 list02에서 max를 구하고 list형태로 나타내어라.
sapply(c(list01,list02), max) # 리스트 처리
sapply(Fruits[,c(4,5)],max) # 데이터 프레임 처리.

# tapply/mapply : 데이터 셋의 특정 요소(factor)를 처리
# tapply() : 데이터 셋의 특정 요소(factor)를 처리
# 문법: tapply(계산될 컬럼, 기준 컬럼, 적용 함수)
# mapply() : 벡터나 리스트를 데이터 프레임처럼 처리한다.
# 문법 : mapply(함수, 벡터1, 벡터2, ...)
Fruits
tapply(Fruits$Sales,Fruits$Fruit,sum)
# Fruits에서 Sales 출력값을 총합하여 출력.
attach(Fruits) # 변수를 직접적으로 사용하겟다는 설정.
tapply(Sales,Fruit,sum) 
# attach된 변수 Fruits에서의 Sales, Fruit를 사용.
tapply(Sales, Year, max)
# 동일방식.
vect01 = c(1,2,3,4,5)
vect02 = c(10,20,30,40,50)
vect03 = c(100,200,300,400,500)
mapply(sum, vect01,vect02,vect03)
# 이것을 통하면 합치지 않고도 벡터간 계산이 가능하다.
mapply(sum, vect01,vect02,vect03)

data01 = read.csv("data1.csv")
data01
# 년도별 합계
apply(data01[,c(2:15)],2,sum)
# 첫번째 요소는 연령을 표시하니 2부터 15까지 더함.
# 행의 합을 가져와야 함으로 2가 설정
# 연령별 합계
apply(data01[,c(2:15)],1,sum)
# 열의 합을 가져오니 1을 설정.











