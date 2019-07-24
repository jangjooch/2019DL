# -*- coding: utf-8 -*-
"""
Created on Wed Jul 24 10:27:24 2019

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
print("Score")
print(X)

y = odf["reviews_list"]
print("reviews_list")
print(y)

print("==========")
print(X[0:1])
print(y[0:5])

y_list = []
for i in y:
    y_list.append(i)

print(y[0])
print("======")
str = y[0]
print(str)
print("======")
str_sp = str.split(',')
print("str_sp[0]")
print(str_sp[0])
print("======")
print("str_sp[1]")
print(str_sp[1])
print("======")
text_rate_sp = str_sp[0].split()
print(text_rate_sp)
print("======")
text_review_sp = str_sp[1].split('\\n')
print(text_review_sp)





"""
f = open('./input/zomato.csv','r')
readings = csv.reader(f)
for i in readings:
    print(i)
f.close()
"""
