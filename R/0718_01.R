#rm(dumy01)
# 해당 변수 삭제
rm(list=ls())
# 전체 삭제
# 이렇게 되면 라이브러리까지 없어짐.

setwd("H:\\r_work\\data")
getwd
list.files()
# setwd에서 포함된 파일들 목록들.
list.files(all.files = T)


sales = data.frame(fruit = c('Apple','Berry','Melon'),
                   price = c(1000,2000,3000),
                   volume = c(10,20,30))
sales
mean(sales$price)
# 평균.
mean(sales$volume)
install.packages("dplyr")
library(dplyr)
df_raw = data.frame(var01 = c(1,2,3),
                    var02 = c(10,20,30))
df_new = df_raw
df_raw
df_new
df_new = rename(df_new, v2 = var02)
# colume var02를 v2로 변경.
df_new
df_raw$var_sum = df_raw$var01+df_raw$var02
df_raw
# 이렇게 파생 변수를 통하여 새로운 colume을 생성할 수 있다.
df_raw$mean = df_raw$var_sum/2
df_raw

install.packages("ggplot2")
library(ggplot2)
mpg = as.data.frame(ggplot2::mpg)
# ggplot2 패키지이다.
mpg
# 현재 이 data_set은 미국의 차량 연비에 대한 example자료이다.
mpg_new = mpg
# 데이터를 처리하기 전에 원본말고 사본으로 처리하도록 한다.

mpg_new = rename(mpg_new,city = cty)
mpg_new = rename(mpg_new,highway = hwy)
# colume 이름 변경.
head(mpg_new)
# 상위 6개 출력.
tail(mpg_new)
# 하위 6개 출력.

scan01 = scan("scan_1.txt")
# 텍스트파일을 불러 배열에 저장.
# 확장자까지 써야할 것.
scan01
scan02 = scan("scan_2.txt")
# 실제 scan_2.txt에는 실수값이 저장되어 있다.
# 하지만 scan02의 출력은 정수값이 출력된다.
# 그렇기에 데이터 형에 저장되는 값에 대한 옵숀 what을 준다.
scan02
scan02 = scan("scan_2.txt",what="")
scan02
scan03 = scan("scan_3.txt",what="")
# scan_3은 string 형이지만 what을 주어야 정상적으로 받아 올 수 있다.
scan03
scan04 = scan("scan_4.txt",what="")
# scan_4.txt는 또한 복합적인 데이터 형을 가진다.
scan04

input01 = scan()
# 콘솔창에서 입력받아 배열로 저장한다.
# 입력 중지는 연속적으로 enter하면 된다.
input01 = scan(what="")
# 하지만 what을 사용하지 않으면 Array에 저장되기 때문에 정상적으로 저장되지 않는다.
input02 = readline("Message : ")
input02
# 띄어쓰기까지 입력 가능.
input03 = readLines("scan_4.txt")
input03
# 줄단위로 읽어내어 저장.
fruits = read.table("fruits.txt")
# read.table은 테이블 단위로 읽어낼 수 있지만,
# colume들까지 데이터로 인식하여 저장하므로 옵션을 주어야 한다.
fruits = read.table("fruits.txt", header = T)
fruits
# 이렇게 header 옵션을 통해 가장 윗줄을 colume으로 인식하여 저장한다.
# read.table의 특징 중 하나는 주석은 알아서 없애고 저장한다.
fruits = read.table("fruits.txt", header = T,nrows = 2)
fruits
# nrows를 통한 특정 줄까지만 저장.
fruits = read.table("fruits_2.txt",skip = 2)
fruits
# skip을 통하여 특정 줄의 것을 무시하고 저장이 가능하다.
# 하지만 주석까지 포함한 2번째 줄이라는 것을 명심해라.

fruits = read.table("fruits.txt", header = T, nrows = 2,skip = 2)
fruits
# 이렇게 되는 경우 skip = 2로 인하여 colume이 사라지고 진행됨으로
# 그 다음의 데이터가 header로 인식하게 된다.
# 즉 skip과 header는 같이 사용하기에는 문제가 있다.
fruits = read.table("fruits.txt", nrows = 2,skip = 2)
fruits

fruits = read.csv("fruits_3.csv")
# csv는 , 로 구분자로 가지는 것에 대한 파일을 저장.
# 기본적으로 read.table과 달리 header를
# 기본적으로 있다는 전제하에 진행하므로 header = T 가 필요없다.
fruits
fruits = read.csv("fruits_4.csv")
fruits
fruits = read.csv("fruits_4.csv", header = F)
fruits
# 하지만 기본적으로 header를 가지기에 colume을 가지지 않은
# csv를 처리할 경우 header옵션을 꺼야한다.
label = c("No1","Name","Price","Qty")
fruits = read.csv("fruits_4.csv", header = F, col.names = label)
fruits
# 이러한 방식으로 csv에 대한 저장에 colume을 추가할 수 잇다.









