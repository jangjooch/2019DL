
setwd("H:\\r_work\\data")
getwd()
# read 할 data 경로 설정.


txt01 = read.csv("factor_test.txt")
# 구분자가 , 로 이루어져 있는 데이터 파일.
txt01
# 이렇듯 data를 읽고 저장이 가능.
fact01 <- factor(txt01$name)
# 변수 fact01에 txt01의 name컬럼의 값들을 저장한다.
fact01
summary(fact01)
# fact01에 저장된 name컬럼에 대한 정보를 요약하여 출력한다.
fact02 = factor(txt01$sex)
summary(fact02)

Sys.Date()
Sys.time()
# Sys가 붙으면 작업환경 시스템에 맞추어서
date()
# 일반은 미국 기준
class("2019-07-17")
class(as.Date("2019-07-17"))
# 이러한 방식으로 string형식의 것을 Date화 할 수 있다.
as.Date("17-07-2019")
as.Date("17-07-2019",format("%d-%m-%Y"))
# format을 주지 않으면 미국식 표기법인 것을 인지하지 못하기에 이상한 값이 나온다.
# 그렇기에 format을 주어 구분자는 - 로 하여 day, month, Year을 명시토록 해야한다.
as.Date("2019년 7월 17일",format ="%Y년%m월%d일")
# format에서 구분자에 따라 정해주도록 해야한다.
as.Date("2019-07-19")-as.Date("2018-07-19")
# 차이나는 일자에 대한 값을 준다.
as.Date("2019-07-17")+100
# 이렇게 일자에 +100일을 할 수 있다.

# R에서 날짜를 사용할 때, POSTXlt와 POSTXct 클래스를 많이 사용한다.
# POSTXlt는 날짜를 [년, 월, 일]로 표현하는 리스트형
# POSTXct는 년, 월, 일, 시간 을 연속적인 데이터로 인식하여
# 1970년을 기준으로 초단위로 계산한다.

as.Date("2019-07-19 12:00:00") -as.Date("2019-07-19 11:00:00")
# 기본적으로 시간에 대한 계산은 이루어 지지 않기때문이다.
as.POSIXct("2019-07-19 12:00:00") - as.POSIXct("2019-07-19 11:00:00")
# 시간을 계산한다면 이렇게 POSTXct를 이용해야 한다.

install.packages("lubridate")
# package 다운. 다운시 꼭 " " 해야한다.
library(lubridate)
# 라이브러리 사용.
# 혹은 Packages에서 클릭하여 라이브러리를 사용할 수 있다.
date <- now()
# library(lubridate) 를 함으로서 사용가능한 now()
date
year(date)
month(date,label = F)
day(date)
wday(date,label = F)
wday(date,label = T)
date = date - days(2)
day(date)
date <- date + years(2)
year(date)
date <- date + hours(3)
hour(date)
date <- date + minutes(20)
minute(date)
# 이렇듯 날짜들을 손볼 수 있다.
date = hms("22:30:50")
date
# date의 시간을 재정의 h(hour)m(minute)s(second)

Kor_date = ymd_hms("2021-01-01 13:00:00", tz = "Asia/Seoul")
Par_date = with_tz(Kor_date,"Europe/Paris")
Par_date
Par_date = Par_date + hours(7)
Par_date
Kor_date = with_tz(Par_date,"Asia/Seoul")
Kor_date
#----------------
t_Paris = as.POSIXct("2021-01-01 13:00:00", tz = "Europe/Paris")
t_Paris
t_Seoul = t_Paris
tz(t_Seoul) <- "Asia/Seoul"
t_Seoul
t_Paris <-with_tz(t_Seoul, tzone = "Europe/Paris")
t_Paris <- t_Paris + hours(7)
t_Seoul <- t_Paris
t_Seoul <- with_tz(t_Seoul, tzone = "Asia/Seoul")
t_Seoul
t_Paris
t_Paris == t_Seoul
# 이렇게 시간은 다르더라도 time zone에 대한 계산을 통해 같을 수 있다.



