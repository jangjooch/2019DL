
title = c('qwe','asd','zxc','qaz')
number = c(1,2,3,4)
pages = c(200,300,400,500)

books = data.frame(Title = title, Number = number, Pages = pages)
books

buy01 = data.frame(Title = 'dom',Number=6,Pages=100)
books = rbind(books,buy01)
books

#newFeature01 = data.frame('06-08','07-08','01-30','03-04','09-13')
#books = cbind(books,newFeature01)
# 그냥주면 ㅈ대요.
#books

books = cbind(books,Date = c('06-08','07-08','01-30','03-04','09-13'))
books
# colume추가는 안전하게. data frame으로 주면 망가진다.