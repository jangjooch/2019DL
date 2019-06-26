
import tensorflow as tf
from tensorflow.examples.tutorials.mnist import input_data

# Dataset loading
mnist = input_data.read_data_sets("./samples/MNIST_data/", one_hot=True)

# Set up model
x = tf.placeholder(tf.float32, [None, 784])
W = tf.Variable(tf.zeros([784, 10]))
b = tf.Variable(tf.zeros([10]))
y = tf.nn.softmax(tf.matmul(x, W) + b)

y_ = tf.placeholder(tf.float32, [None, 10])

cross_entropy = -tf.reduce_sum(y_*tf.log(y))
train_step = tf.train.GradientDescentOptimizer(0.01).minimize(cross_entropy)
# GradientDescentOptimizer(0.01)'s 0.01 is the best that programmer found
# if i change this into 0.1 than result whill be under 0.1, beside it was
# 0.98... give it a try

# Session
init = tf.global_variables_initializer()

sess = tf.Session()
sess.run(init)

"""
# Learning
list = [1000,2000,3000,4000,5000]
for i in list:
    for i in range(i):
        batch_xs, batch_ys = mnist.train.next_batch(100)
        sess.run(train_step, feed_dict={x: batch_xs, y_: batch_ys})
# Validation
    correct_prediction = tf.equal(tf.argmax(y,1), tf.argmax(y_,1))
    accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# Result should be approximately 91%.
    print(sess.run(accuracy, feed_dict={x: mnist.test.images, y_: mnist.test.labels}))
"""    
list = [1000,2000,3000,4000,5000]
max = 0
maxi = 0
for i in range(1000,3000,100):
    for j in range(i):
        batch_xs, batch_ys = mnist.train.next_batch(100)
        sess.run(train_step, feed_dict={x: batch_xs, y_: batch_ys})
# Validation
    correct_prediction = tf.equal(tf.argmax(y,1), tf.argmax(y_,1))
    accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# Result should be approximately 91%.
    acc = sess.run(accuracy, feed_dict={x: mnist.test.images, y_: mnist.test.labels})
    if(acc>max):
        maxi = i
        max = acc
    print(sess.run(accuracy, feed_dict={x: mnist.test.images, y_: mnist.test.labels}))
print(maxi)
print(max)

