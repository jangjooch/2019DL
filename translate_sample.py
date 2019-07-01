# -*- coding: utf-8 -*-

from googletrans import Translator
translator = Translator()

print(translator.translate("음식은 좋았어요."))

review01 = translator.translate("침대가 매우 별로 였어.")
review02 = translator.translate("침대가 매우 나빳어.")

print(review01.text)
print(review02.text)

"""
Created on Fri Jun 28 14:32:22 2019

@author: Jang
"""

