# Lab 11 MNIST and Convolutional Neural Network
import tensorflow as tf
import random
# import matplotlib.pyplot as plt

from tensorflow.examples.tutorials.mnist import input_data

tf.set_random_seed(777)  # reproducibility

mnist = input_data.read_data_sets("./samples/MNIST_data/", one_hot=True)
# beware the path. the path above it means sample file must be stay in
# the same directory. otherwise just wirte absolute path.
# Check out https://www.tensorflow.org/get_started/mnist/beginners for
# more information about the mnist dataset

# hyper parameters
learning_rate = 0.001
# 0.01xx, 0.001xx
training_epochs = 20
batch_size = 200
# 100 ~ 200

# input place holders
X = tf.placeholder(tf.float32, [None, 784])
# NONE은 얼마나의 차원이(경우의 수) 있을 지 확실치 못하는 것이다
# 784는 특징이 될 픽셀의 수 이다.
X_img = tf.reshape(X, [-1, 28, 28, 1])   # img 28x28x1 (black/white)
# 28*28은 원본 데이터의 크기임으로 임의로 변경하지 못한다.
# X의 모양을 변형시긴 것이다.즉 28*28의 형태로 변형시킨 것이다.
# -1은 n개의 수, 즉 NONE과 같은 뜻이다. 얼마나 쓰일지 모르니 정한다.
# 1은 채널의 수. 어차피 글자에서 색은 의미 없으니 1가지의 단색으로만 한다는 뜻.
# CNN의 C. 컨버리션을 하기 위한 과정이다. 즉 필터를 형성할 마스크를 뜻한다.
# 고로 데이터를 정제하는 경우 이때 사용할 마스크의 규격을 정한 것이다.
# 즉 단층 레이어 형태의 X를 마스크화 하여 X_로 저장한다.
Y = tf.placeholder(tf.float32, [None, 10])
# 경우의 수, 0 ~ 9 까지이니 10개 임을 정한다.
#=============================================================
# 필터 사이즈와 레이어 계산 단위를 바꿀 수 있다.
#=============================================================
# L1 ImgIn shape=(?, 28, 28, 1)
# convolution & max pooling 1
# convolution 은 마스크와 실제 이미지를 통한 과정의 결과를 전한다.
# max pooling은 각 특정 픽셀단위에서 가장 강한 값을 남긴다.
# 즉 다수의 후보순위를 최종으로 하나의 후보수위를 뽑는 것이다.
W1 = tf.Variable(tf.random_normal([3, 3, 1, 32], stddev=0.01))
# 3*3은 해당 단위만큼 마스크를 씌운다는 것이다.
# 1은 하나의 변형된 이미지 밖에 없으니 1개의 필터만 있으므로 1인 것이다.
# 32는 convolution한 결과를 32개의 필터로 낸다는 것이다.
#    Conv     -> (?, 28, 28, 32)
# Conv하기 전에 변형하였으니 28*28이고 결과적으로 필터를 32개를 낸다고 했다.
#    Pool     -> (?, 14, 14, 32)
# 변형된 이미지를 2*2단위로 평가한다고 하였으니 14*14로 변경된다. 필터는 변하지 않는다.
L1 = tf.nn.conv2d(X_img, W1, strides=[1, 1, 1, 1], padding='SAME')
# X_로 바꾼 이미지를 W1규칙으로 convolution한다는 뜻이다.
# padding='SAME'은 convolution은 여분의 이미지를 서로 같도록 한다는 것이다.
# 즉 여분 없이 실행토록 한다는 것이다.
L1 = tf.nn.relu(L1)
L1 = tf.nn.max_pool(L1, ksize=[1, 2, 2, 1],
                    strides=[1, 2, 2, 1], padding='SAME')
# max pooling할 픽셀들의 단위를 정한다. 즉 2*2만큼의 단위로 한다는 것이니
# 28*28에서 2*2는 14*14만큼있으니 그만큼믜 결과로 압축된다.
'''
Tensor("Conv2D:0", shape=(?, 28, 28, 32), dtype=float32)
Tensor("Relu:0", shape=(?, 28, 28, 32), dtype=float32)
Tensor("MaxPool:0", shape=(?, 14, 14, 32), dtype=float32)
'''
#=============================================================
# L2 ImgIn shape=(?, 14, 14, 32)
# convolution & max pooling 2
W2 = tf.Variable(tf.random_normal([3, 3, 32, 64], stddev=0.01))
# 다시 3*3 단위로 마스크를 씌워측정한다.\
# 32는 그 전 단계에서 32개의 필터가 전달되었다.
# 64는 전달된 32개의 필터의 결과를 64개만큼의 필터로 만든다.
#    Conv      ->(?, 14, 14, 64)
#    Pool      ->(?, 7, 7, 64)
L2 = tf.nn.conv2d(L1, W2, strides=[1, 1, 1, 1], padding='SAME')
L2 = tf.nn.relu(L2)
L2 = tf.nn.max_pool(L2, ksize=[1, 2, 2, 1],
                    strides=[1, 2, 2, 1], padding='SAME')
# max pooling할 픽셀의 단위를 2*2만큼 정한다.
L2_flat = tf.reshape(L2, [-1, 7 * 7 * 64])
# 최종적으로 변형될 형태를 뜻한다.
# 14*14에서 2*2단위로 압축시키었으니 7*7이 되고
# 32개의 필터를 64개로 늘린다고하였으니 늘어난다.
# 즉 최종적으로 노드의 갯수는 7*7*64 = 3136 개이다.
'''
Tensor("Conv2D_1:0", shape=(?, 14, 14, 64), dtype=float32)
Tensor("Relu_1:0", shape=(?, 14, 14, 64), dtype=float32)
Tensor("MaxPool_1:0", shape=(?, 7, 7, 64), dtype=float32)
Tensor("Reshape_1:0", shape=(?, 3136), dtype=float32)
3136 = (7 * 7) * 64 즉 모든 경우의 수.
'''
#=============================================================
# Final FC 7x7x64 inputs -> 10 outputs
W3 = tf.get_variable("W3", shape=[7 * 7 * 64, 10],
                     initializer=tf.contrib.layers.xavier_initializer())
# 7*7*64개의 각 노드들의 경우의 수는 10이다. 0 ~ 9
# 이를 W3 이라 칭한다.
b = tf.Variable(tf.random_normal([10]))
logits = tf.matmul(L2_flat, W3) + b

# define cost/loss & optimizer
cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
    logits=logits, labels=Y))
optimizer = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(cost)

# initialize
sess = tf.Session()
sess.run(tf.global_variables_initializer())

# train my model
print('Learning started. It takes sometime.')
for epoch in range(training_epochs):
    avg_cost = 0
    total_batch = int(mnist.train.num_examples / batch_size)

    for i in range(total_batch):
        batch_xs, batch_ys = mnist.train.next_batch(batch_size)
        feed_dict = {X: batch_xs, Y: batch_ys}
        c, _ = sess.run([cost, optimizer], feed_dict=feed_dict)
        avg_cost += c / total_batch

    print('Epoch:', '%04d' % (epoch + 1), 'cost =', '{:.9f}'.format(avg_cost))

print('Learning Finished!')

# Test model and check accuracy
correct_prediction = tf.equal(tf.argmax(logits, 1), tf.argmax(Y, 1))
accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
print('Accuracy:', sess.run(accuracy, feed_dict={
      X: mnist.test.images, Y: mnist.test.labels}))

# Get one and predict
r = random.randint(0, mnist.test.num_examples - 1)
print("Label: ", sess.run(tf.argmax(mnist.test.labels[r:r + 1], 1)))
print("Prediction: ", sess.run(
    tf.argmax(logits, 1), feed_dict={X: mnist.test.images[r:r + 1]}))

# plt.imshow(mnist.test.images[r:r + 1].
#           reshape(28, 28), cmap='Greys', interpolation='nearest')
# plt.show()

'''
Epoch: 0001 cost = 0.340291267
Epoch: 0002 cost = 0.090731326
Epoch: 0003 cost = 0.064477619
Epoch: 0004 cost = 0.050683064
Epoch: 0005 cost = 0.041864835
Epoch: 0006 cost = 0.035760704
Epoch: 0007 cost = 0.030572132
Epoch: 0008 cost = 0.026207981
Epoch: 0009 cost = 0.022622454
Epoch: 0010 cost = 0.019055919
Epoch: 0011 cost = 0.017758641
Epoch: 0012 cost = 0.014156652
Epoch: 0013 cost = 0.012397016
Epoch: 0014 cost = 0.010693789
Epoch: 0015 cost = 0.009469977
Learning Finished!
Accuracy: 0.9885
'''

