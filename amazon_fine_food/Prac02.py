# -*- coding: utf-8 -*-
"""
Created on Tue Jul 23 09:46:48 2019

@author: Jang
"""

# wikidocs/22530 에 관련 라이브러리들에 대한 설명들이 있다.
import pandas as pd # 데이터 분석 라이브러리. 데이터 객체를 다루는 행위를 보조
import numpy as np # 벡터, 메트릭스, 
# import matplotlib.pyplot as plt # 시각화를 위한 라이브러리
# import seaborn as sns
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
from sklearn.dummy import DummyClassifier
from string import punctuation
from sklearn import svm
from nltk.corpus import stopwords
from nltk.stem import WordNetLemmatizer
import nltk
from nltk import ngrams
from itertools import chain
from wordcloud import WordCloud

#nltk.download('wordnet')
#nltk.download('punkt')
#nltk.download('stopwords')
#nltk.download('averaged_perceptron_tagger')
#==============================================
# 데이터 셋 추가 및 '좋아요' 매트릭스 컬륨 생성.
odf = pd.read_csv('./input/Reviews.csv')
odf['Helpful %'] = np.where(odf['HelpfulnessDenominator'] > 0, odf['HelpfulnessNumerator'] / odf['HelpfulnessDenominator'], -1)
odf['% Upvote'] = pd.cut(odf['Helpful %'], bins = [-1, 0, 0.2, 0.4, 0.6, 0.8, 1.0], labels = ['Empty', '0-20%', '20-40%', '40-60%', '60-80%', '80-100%'], include_lowest = True)
odf.head()
# HelpfulnessDenominator'] > 0 : 분모가 0보다 큰 경우만 가능토록 제한을 둠.
# HelpfulnessDenominator : 댓글을 본 사람.
# HelpfulnessNumerator : 댓글을 본 사람 중 도움이 되었다고 한 사람. => odf['HelpfulnessNumerator'] / odf['HelpfulnessDenominator'] = 0 ~ 1
# odf['HelpfulnessNumerator'] / odf['HelpfulnessDenominator'] = 0 ~ 1 의 결과를 범위를 나누어 자르고 각기 label을 단다.
#==========================================
# 시각화 과정. 필요 없음.
#df_s = odf.groupby(['Score', '% Upvote']).agg({'Id': 'count'})
#df_s = df_s.unstack()# 가로 세로를 모두 적용한다.
#df_s.columns = df_s.columns.get_level_values(1)
#fig = plt.figure(figsize=(15,10))
# 각 문항의 사이즈 15 * 10
#sns.heatmap(df_s[df_s.columns[::-1]].T, cmap = 'YlGnBu', linewidths=.5, annot = True, fmt = 'd', cbar_kws={'label': '# reviews'})
# cmap = 'YlGnBu' => 팜플렛의 색깔 설정. 디폴트는 초록.
#plt.yticks(rotation=0)
#plt.title('How helpful users find among user scores')
#==============================================
# 점수 3은 중립적이므로 삭제한다. 그리고 전체적인 데이터드을 좋음(1), 나쁨(0)으로 분할한다.
df = odf[odf['Score'] != 3]
X = df['Text']
y_dict = {1:0, 2:0, 4:1, 5:1}
y = df['Score'].map(y_dict)
#==============================================
#############  Score Prediction     ###############
# 로직에 의한 단어 카운트.
# 실질적인 특정 알고리즘에 따른 정확도 측정.
c = CountVectorizer(stop_words = 'english')
# stop_words는 불용성 단어드을 제외해 버린다.
# 즉 c = 불용성 단어를 countervectorize 하여 c에 저장한다.
def text_fit(X, y, model,clf_model,coef_show=1):    
    X_c = model.fit_transform(X)
    print('# features: {}'.format(X_c.shape[1]))
    X_train, X_test, y_train, y_test = train_test_split(X_c, y, random_state=0)
    # 트레이닝 데이터와 테스트 데이터로 나누는 과정이다.
    # 디폴트로는 7 : 3 으로 나눈다. <- random_state=0
    print('# train records: {}'.format(X_train.shape[0]))
    print('# test records: {}'.format(X_test.shape[0]))
    clf = clf_model.fit(X_train, y_train)
    acc = clf.score(X_test, y_test)
    print ('Model Accuracy: {}'.format(acc))
    
    if coef_show == 1: 
        w = model.get_feature_names()
        coef = clf.coef_.tolist()[0]
        coeff_df = pd.DataFrame({'Word' : w, 'Coefficient' : coef})
        coeff_df = coeff_df.sort_values(['Coefficient', 'Word'], ascending=[0, 1])
        print('')
        print('-Top 20 positive-')
        print(coeff_df.head(20).to_string(index=False))
        print('')
        print('-Top 20 negative-')        
        print(coeff_df.tail(20).to_string(index=False))
    
text_fit(X, y, c, LogisticRegression())
#==============================================
print("자작")
def get_array(X, y, model,clf_model,coef_show=1):
    X_c = model.fit_transform(X)
    X_train, X_test, y_train, y_test = train_test_split(X_c, y, random_state=0)
    clf = clf_model.fit(X_train, y_train)
    acc = clf.score(X_test, y_test)
    print ('Model Accuracy: {}'.format(acc))
    if coef_show == 1: 
        w = model.get_feature_names()
        coef = clf.coef_.tolist()[0]
        coeff_df = pd.DataFrame({'Word' : w, 'Coefficient' : coef})
        coeff_df = coeff_df.sort_values(['Coefficient', 'Word'], ascending=[0, 1])
        return coeff_df.head(20).to_string(index=False)    
good_df = get_array(X, y, c, LogisticRegression())
print(good_df)
print(len(good_df))
print(good_df.split())
words = []
coeff = []
i = 0
for str in good_df.split():
  if i>1:
    if i%2 == 0:
      words.append(str)
    else:
      coeff.append(str)
  i = i+1
print("words")
print(words)
print("coeff")
print(coeff)
print("단순 Word카운트에서 Word랑 Coefficient 추출.")
#==============================================
# 약 93%의 정확도이지만 단순히 워드 카운트이므로 의미가 없다.
# 같은 데이터를 사용하여 DummyClassifier알고리즘으로 실행한다.
text_fit(X, y, c, DummyClassifier(),0)
#==============================================
# TFIDF 모델 사용. 이를 통하여 정확도가 올라가지는 않았지만
# 특정 단어들에 대한 중요성을 파악함.
# tfidf을 text_fit의 model 인자로 전달한다. 이는 기존의 CountVectorizer가 아닌 TfidfVectorizer로 분별하도록 하는 것이다.
tfidf = TfidfVectorizer(stop_words = 'english')
text_fit(X, y, tfidf, LogisticRegression())
#==============================================
# ngram을 사용한 TFIDF 사용
tfidf_n = TfidfVectorizer(ngram_range=(1,2),stop_words = 'english')
text_fit(X, y, tfidf_n, LogisticRegression())
# 데이터를 통해 TFiDF + ngram 을 사용.
# score prediction에서 정확도가 가장 좋은 모델임.
# TFIDF 와 달리 더 많은 gram을 사용하기 때문에 단일 gram인 위의 것과 달리 features가 더 높다.
# 현재 이것은 옵션으로 1, 2이니 최소 1gram 부터 최대 2 gram까지 사용한다는 것이다.
# 만약 1, 3이라면 1gram 부터 3 gram 까지 검색하는 것이다. gram은 단어이다. 즉 단어 조합을 의미한다.
# 즉 그만큼 features도 늘어난다.
#=================================
# TFIDF + ngram 모델 추출해보기.
print()
good_df = get_array(X, y, tfidf_n, LogisticRegression())
print(good_df)
print(len(good_df))
print(good_df.split())
words = []
coeff = []
i = 0
for str in good_df.split():
  if i>1:
    if i%2 == 0:
      words.append(str)
    else:
      coeff.append(str)
  i = i+1
print("words")
print(words)
print("coeff")
print(coeff)
print("TFIDF + ngram 모델을 통한 Words, Coefficient 추출.")
"""
#==============================================
#############  UpVote prediction  ###############
# 이 과정을 통해 '싫어요'에 대한 패턴을 찾는다
# 즉 5점짜리 리뷰에 초점을 맞추고 중립적인 투표를 지운다.
df = df[df['Score'] == 5]
df = df[df['% Upvote'].isin(['0-20%', '20-40%', '60-80%', '80-100%'])]
df.shape

X = df['Text']
y_dict = {'0-20%': 0, '20-40%': 0, '60-80%': 1, '80-100%': 1}
y = df['% Upvote'].map(y_dict)

print('Class distribution:')
print(y.value_counts())
# 60 % 이상은 1. 0 ~ 40 % 는 0으로 판명
# 결과적으로 현재 샘플링 된것은 긍정의 개수와 부정의 개수가 차이가 심하다.
#==============================================
# 그렇기 때문에 긍정의 갯수와 부정의 갯수를 맞도록 하기 위해 이하 과정 수행.
# 위 과정에서 긍정의 수가 너무 크기때문에 긍정의 수를 부정의 수만큼만
# 뽑아서 긍정의 수가 부정의 수와 같도록 하는 것이다.
# 고로 사용될 데이터의 수는 기존 부정의 수의 2배이다. 긍정의 수가 그만큼 줄었으니.
df_s = pd.DataFrame(data = [X,y]).T
# 데이터를 2차원 배열로 변환
Downvote_records = len(df_s[df_s['% Upvote'] == 0])
Downvote_indices = np.array(df_s[df_s['% Upvote'] == 0].index)

Upvote_indices = df_s[df_s['% Upvote'] == 1].index

random_upvote_indices = np.random.choice(Upvote_indices, Downvote_records, replace = False)
# 1 ~ Upvote_indices 까지 랜덤한 샘플을 생성한다.
# Downvote_records는 사이즈가 된다.(int 형이여야 한다.)
# 또한 생성된 샘플을 대체하지 않는다.(default는 True이다.)
random_upvote_indices = np.array(random_upvote_indices)
# 위에서 생성된 랜덤 샘플들로 Numpy 배열을 만든다.
under_sample_indices = np.concatenate([Downvote_indices,random_upvote_indices])
# 2개의 생성된 numpy 배열을 합친다.
under_sample_data = df_s.ix[under_sample_indices, :]
X_u = under_sample_data['Text']
under_sample_data['% Upvote'] = under_sample_data['% Upvote'].astype(int)
y_u = under_sample_data['% Upvote']


print("Percentage of upvote transactions: ", len(under_sample_data[under_sample_data['% Upvote'] == 1])/len(under_sample_data))
print("Percentage of downvote transactions: ", len(under_sample_data[under_sample_data['% Upvote'] == 0])/len(under_sample_data))
print("Total number of records in resampled data: ", len(under_sample_data))
#==============================================
# 모델 wordcount에 대한 로직 형성
c = CountVectorizer(stop_words = 'english')

text_fit(X_u, y_u, c, LogisticRegression())
#==============================================
# TFIFD + ngram 모델에 대한 로직 형성.
tfidf_n = TfidfVectorizer(ngram_range=(1,2),stop_words = 'english')

text_fit(X_u, y_u, tfidf_n, LogisticRegression())
#==============================================
# 비 문맥적 특성에 대한 연구.
# 이 과정은 긍정적 요소['% Upvote']==1] 와 부정적 요소['% Upvote']==0]
# 에 대한 단어들의 예시를 본다.
#pd.set_option('display.max_colwidth', -1)
print('Downvote score 5 comments examples:')
print(under_sample_data[under_sample_data['% Upvote']==0]['Text'].iloc[:100:20])
# 샘플 데이터를 출력
# iloc[:100:20] 은 100개 가져왔는데 그 중에서 20의 단위의 것만 출력한다.
print('Upvote score 5 comments examples')
print(under_sample_data[under_sample_data['% Upvote']==1]['Text'].iloc[:100:20])
#==============================================
# 기능 추출.
under_sample_data['word_count'] = under_sample_data['Text'].apply(lambda x: len(x.split()))
under_sample_data['capital_count'] = under_sample_data['Text'].apply(lambda x: sum(1 for c in x if c.isupper()))
# capital_count 의 값은 대문자인 것들의 갯수이다.
under_sample_data['question_mark'] = under_sample_data['Text'].apply(lambda x: sum(1 for c in x if c == '?'))
under_sample_data['exclamation_mark'] = under_sample_data['Text'].apply(lambda x: sum(1 for c in x if c == '!'))
under_sample_data['punctuation'] = under_sample_data['Text'].apply(lambda x: sum(1 for c in x if c in punctuation))
# 즉 전체적으로 글자 수, 대문자, ?, !, 마침표 의 수를 각기 60% 이상과 40% 이하의 평균들을 나누어 보여준다.

print(under_sample_data.groupby('% Upvote').agg({'word_count': 'mean', 'capital_count': 'mean', 'question_mark': 'mean', 'exclamation_mark': 'mean', 'punctuation': 'mean'}).T)

X_num = under_sample_data[under_sample_data.columns.difference(['% Upvote', 'Text'])]
# X_num 은 Upvote와 Text의 컬럼에 속하는 것을 가져온 것.
y_num = under_sample_data['% Upvote']
#==============================================
# 모델 훈련.
# 정확도는 위에서 시도한 word count보다 낮다.
X_train, X_test, y_train, y_test = train_test_split(X_num, y_num, random_state=0)

clf_lr = LogisticRegression().fit(X_train, y_train)
acc_lr = clf_lr.score(X_test, y_test)
# 디폴트로 훈련데이터와 테스트 데이터를 7 : 3으로 나눈다.
print('Logistic Regression accuracy: {}'.format(acc_lr))

clf_svm = svm.SVC().fit(X_train, y_train)
acc_svm = clf_svm.score(X_test, y_test)
print('SVM accuracy: {}'.format(acc_svm))
#==============================================
#############  In-depth study on user behaviour  ###############
# 특정 유저에 대한 과거 행동에 대한 데이터 확인.
df_user = odf.groupby(['UserId', 'ProfileName']).agg({'Score':['count', 'mean']})
df_user.columns = df_user.columns.get_level_values(1)
df_user.columns = ['Score count', 'Score mean']
df_user = df_user.sort_values(by = 'Score count', ascending = False)
print(df_user.head(10))
# 유저 개개인의 댓글과 평균을 sort하여 10명을 보여준다.
#==============================================
# CFH는 448개의 리뷰와 4.45의 평균점수를 가진다. 그의 자세한 사항을 보자.
# def plot_user(UserId):
    df_1user = odf[odf['UserId'] == UserId]['Score']
    df_1user_plot = df_1user.value_counts(sort=False)
    ax = df_1user_plot.plot(kind = 'bar', figsize = (15,10), title = 'Score distribution of user {} review'.format(odf[odf['UserId'] == UserId]['ProfileName'].iloc[0]))

# plot_user('A3OXHLG6DIBRW8')
# 해당 유저아이디의 리뷰에 대한 그래프를 보여준다.
#==============================================
# 출력상으로는 CFH는 높은 점수를 주는 성향이 있다.
print(df_user[(df_user['Score mean']<3.5) & (df_user['Score mean']>2.5)].head())
# 고로 유저들의 평균 점수가 2.5 ~ 3.5 인 유저들 것만 평가하겠다는 것이다.
#==============================================

# plot_user('A2M9D9BDHONV3Y')
#==============================================
# 그 유저는 좋은 분석 대상이 될것이다.
# 그 유저가 행한 리뷰들에 대하여 집중한다.
def get_token_ngram(score, benchmark, userid='all'):

    if userid != 'all':
        df = odf[(odf['UserId'] == userid) & (odf['Score'] == score)]['Text']
    else:
        df = odf[odf['Score'] == score]['Text']
        
    count = len(df)
    total_text = ' '.join(df)
    total_text = total_text.lower()
    stop = set(stopwords.words('english'))
    total_text = nltk.word_tokenize(total_text)
    total_text = [word for word in total_text if word not in stop and len(word) >= 3]
    # 표재어를 추출하는 함수. 단 스펠링 3개 이상의 것들만
    lemmatizer = WordNetLemmatizer()
    total_text = [lemmatizer.lemmatize(w,'v') for w in total_text]
    # 추출한 단어 중 동사('v')를 추출.
    bigrams = ngrams(total_text,2)
    # 여기서 비교할 gram 중 하나를 2 gram으로 생성
    trigrams = ngrams(total_text, 3)
    # 나머지 하나는 3 gram으로 생성

    # look at 2-gram and 3-gram together
    combine = chain(bigrams, trigrams)
    # 2-gram과 3-gram을 결합.
    text = nltk.Text(combine)
    fdist = nltk.FreqDist(text)
    
    # return only phrase occurs more than benchmark of his reviews
    return sorted([(w,fdist[w],str(round(fdist[w]/count*100,2))+'%') for w in set(text) if fdist[w] >= count*benchmark], key=lambda x: -x[1])
# str(round(fdist[w]/count*100,2))+'%') for w in set(text) if fdist[w] >= count*benchmark]
# ==> 백분위를 표시해준다,
# 하지만 if fdist[w] >= count*benchmark]의 영향으로 benchmark의 값보다 큰것들만 출력되도록 한것이다.
# 즉 0.25는 25% 이므로 25%이상의 것들만 출력된다.

# score 1-5 reviews with this user
index = ['Phrase', 'Count', 'Occur %']

for j in range(1,6):
    test = pd.DataFrame()
    d = get_token_ngram(j, 0.25, 'A2M9D9BDHONV3Y')
    print('score {} reviews most popular 2-gram / 3-gram:'.format(j))
    for i in d:
        test = test.append(pd.Series(i, index = index), ignore_index = True)
    test = test.sort_values('Count', ascending=False)
    print(test)
# 특정 ID A2M9D9BDHONV3Y의 리뷰에 대한 분석을 각 리뷰에 대한 점수에 따라
# 2gram과 동시에 3gram으로 비교하면서 보여주었다.
#==============================================
# score 1-5 reviews with all users
index = ['Phrase', 'Count', 'Occur %']

for j in range(1,6):
    test = pd.DataFrame()
    # easier benchmark since we have many different users here, thus different phrase
    d = get_token_ngram(j, 0.03)
    print('score {} reviews most popular 2-gram / 3-gram:'.format(j))
    for i in d:
        test = test.append(pd.Series(i, index = index), ignore_index = True)
    test = test.sort_values('Count', ascending=False)
    print(test)
#==============================================    
    def get_token_adj(score, benchmark, userid='all'):        
        if userid != 'all':
            df = odf[(odf['UserId'] == userid) & (odf['Score'] == score)]['Text']
        else:
            df = odf[odf['Score'] == score]['Text']
        
        count = len(df)
        total_text = ' '.join(df)
        total_text = total_text.lower()
        stop = set(stopwords.words('english'))
        total_text = nltk.word_tokenize(total_text)
        total_text = [word for word in total_text if word not in stop and len(word) >= 3]
        # 형용사를 기준으로 잡기에 앞서 단어의 기이가 3이상의 것만 뽑아내도록 한다.
        lemmatizer = WordNetLemmatizer()
        total_text = [lemmatizer.lemmatize(w,'a') for w in total_text]
        # 위에서와 달리 동사('V')가 아닌 형용사('A')를 기준으로 측정한다.
        # get adjective only
        total_text = [word for word, form in nltk.pos_tag(total_text) if form == 'JJ']
    
        text = nltk.Text(total_text)
        fdist = nltk.FreqDist(text)
        
        # return only phrase occurs more than benchmark of his reviews
        return sorted([(w,fdist[w],str(round(fdist[w]/count*100,2))+'%') for w in set(text) if fdist[w] >= count*benchmark], key=lambda x: -x[1])
#==============================================
# score 1-5 reviews with this user
index = ['Phrase', 'Count', 'Occur %']

    
for j in range(1,6):
    
    test = pd.DataFrame()
    d = get_token_adj(j, 0.25, 'A2M9D9BDHONV3Y')
    print('score {} reviews most popular adjectives word:'.format(j))
    for i in d:
        
        test = test.append(pd.Series(i, index = index), ignore_index = True)
        test = test.sort_values('Count', ascending=False)
        print(test)
#==============================================  
    # score 1-5 reviews with all users
index = ['Phrase', 'Count', 'Occur %']

for j in range(1,6):
    test = pd.DataFrame()
    d = get_token_adj(j, 0.05)
    print('score {} reviews most popular adjectives word:'.format(j))
    for i in d:
        test = test.append(pd.Series(i, index = index), ignore_index = True)
    test = test.sort_values('Count', ascending=False)
    print(test)
"""
    
"""
Score prediction
Logistic regression model on word count
Logistic regression model on TFIDF
Logistic regression model on TFIDF + ngram

Upvote prediction
Data preview
Resampling due to imbalanced data
Logistic regression model on word count
Logistic regression model on TFIDF + ngram
Study on non-context features
"""

