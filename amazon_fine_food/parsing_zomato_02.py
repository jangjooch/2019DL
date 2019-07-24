# -*- coding: utf-8 -*-
"""
Created on Wed Jul 24 16:03:48 2019

@author: Jang
"""


import pandas as pd # 데이터 분석 라이브러리. 데이터 객체를 다루는 행위를 보조
import numpy as np # 벡터, 메트릭스, 
import openpyxl # 엑셀파일 관리
import csv

odf = pd.read_csv('./input/zomato.csv',low_memory=False)
#odf['Helpful %'] = np.where(odf['HelpfulnessDenominator'] > 0,
 #  odf['HelpfulnessNumerator'] / odf['HelpfulnessDenominator'], -1)
X = odf["Score"]
#print("Score")
#print(X)

y = odf["reviews_list"]
#print("reviews_list")
#print(y)

"""
y_list = []
for i in y:
    y_list.append(i)

rate_list = []
review_list = []

split_y = y_list[0].split(',')

total_rate = split_y[0]
total_review = split_y[1]

print("=========")
print(total_rate)
print(total_review)
print("=========")
print("=== total rate===")
rate = total_rate.split()
print(rate)
print("=== total review===")
review = total_review.split('\\n')
print(review)
"""
#==============================

y_list = []
for i in y:
    y_list.append(i)
    
num_of_y = len(y_list)
rate_list = []
review_list = []

for i in range(0,num_of_y):
    get_total = y_list[i].split(',')
    total_rate = get_total[0]
    if len(get_total)<2:
        continue
    total_review = get_total[1]
    rate = total_rate.split()
    rate =rate
    review = total_review.split('\\n')
    #print("======")
    #print(rate[1])
    str_num = rate[1]
    #print(str_num[0:3])
    #print(review[1])
    rate_list.append(str_num[0:3])    
    review_list.append(review[1])

print(len(rate_list))
print(len(review_list))
long_review = []
long_rate = []

for i in range(0,len(review_list)):
     if len(review_list[i])<40:
         continue
     long_review.append(review_list[i])
     long_rate.append(rate_list[i])

print(len(long_review))
print(len(long_rate))


df = pd.DataFrame(long_review,long_rate)
print(df)
print("========")

# df.to_excel("parse.xlsx") -> 이건 정상적으로 rate까지 저장됨.
df.to_csv("parsed.csv",mode = 'w',header=False)
#--이거도 잘됨 ㅋㅋ.
"""
for i in y_list:
    get_total = i.split(',')
    total_rate = get_total[0]
    total_review = get_total[1]
    rate = total_rate.split()
    review = total_review.split('\\n')
    rate_list.append(rate[1])
    review_list.append(review[1])

print(rate_list)
"""














