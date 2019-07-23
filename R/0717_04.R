
no = c(1,2,3)
name = c('apple','banana','peach')
price = c(100, 200, 300)
df01 = data.frame(No = no,Name = name, Price = price)
no = c(10,20,30)
name = c('train','car','ship')
price = c(1000, 2000, 3000)
df02 = data.frame(No = no,Name = name, Price = price)

df03 = cbind(df01,df02)
# 이렇게하면 열이 매우 길게나오는 듯하게 나온다. 즉 컬럼이 추가된다.
df03 = rbind(df01,df02)
# 단 이렇듯 행을 행으로 붙이는 경우에는 각기 동일한 컬럼명을 가져야한다.
df03

df01 = data.frame(name = c('apple','banana','peach'),
                  price = c(300,200,100))
df02 = data.frame(name=c('apple','peach','cherry'),
                  qty = c(10,20,30))
merge(df01, df02)
# 컬럼에서 공통적인 것만 합쳐진다. 나머지는 없어짐.
merge(df01,df02,all=T)
# 하지만 all=T 를 주는 경우, 그대로 합치는 대신 비어있는 공간은 NA가 된다.
cbind(df01,df02)
# 이렇게하면 혼종

new01 = data.frame(name='mango',price=400)
df01 = rbind(df01,new01)
df01 = rbind(df01,data.frame(name='berry',price=600))
# 이렇게 2가지 방법으로 열을 추가할 수 있다.
df01
df01 = cbind(df01,data.frame(qty=c(10,20,30,40,50)))
# df01 = cbind(df01,data.frame(etc=c(150,250,350)))
# 이러한 방법으로는 들어가지 않는다. matrix에서는 모자라는 경우
# loop를 돌리면서 채우지만 data frame에서는 그러하지 않는다.
# 다시 rbind는 열추가. cbind는 행추가.
df02 = subset(df01,select = c(name,qty))
df02
df03 = subset(df01,select =- c(name))
# df01에서 colume Name을 제외한 나머지를 df03에 저장
names(df03) = c("가격","비용")
# 타이틀 설정.
df03







