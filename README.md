用户评论分类模型

本模型用于对用户提交的反馈进行分类，预测不同的反馈于相应分类。用户可使用预先训练好的模型进行用户评论分类，或者加载新的用户评论重新训练。
<br> 本文将介绍如何使用训练以及使用模型，相应文件输入类型和输出类型，和安装包需求。
# 目录
- [模型训练](#模型训练)
- [模型加载与使用](#模型加载与使用)
- [运行流程](#运行流程)
- [相关文件](#相关文件)
- [依赖包要求](#依赖包要求)
# 模型训练
## 1.1.1执行命令
可运行下列命令根据输入的文件进行训练，在model/路径下执行
<br>样例:python3 train.py --trainData 1625label.xlsx --saveModel pre-trained.model --c 0.04 --gamma 10 --prob 0.5
<br>--c 自选惩罚系数c参数 --gamma 自选gamma参数 --prob 自选概率参数
<br>(推荐取值范围 c = (0.001, 10000), gamma = [1,10,100,1000], prob概率 = (0.3, 0.7)
## 1.1.2参数解析：
   <br>惩罚系数c：C调大，分类器更不允许误差样本存在，但是会造成过拟合
    <br>gamma：gamma越大，高斯核函数对应的曲线就越尖瘦或决策树深度越深，在训练集上误差会越小，准确率越高，但也会造成过拟合
    <br>prob概率阈值：预测结果的时候，首先得到的是每个分类的预测结果的概率。如果该概率大于设定的prob阈值，则预测为相应分类。
## 1.2数据格式
输入的训练文件应符合以下格式

**--input.xlsx**:  *输入文件名*

    1. 有几类输入数据，xlsl输入文件下就应有几个表
       如空中，营销，地面，其他四个输入类别，即应有四个表
    
    2. 每个表中，每一行是每一条评价文本
       如在空中服务表中，第一行为: 段晓丹空乘小姐姐，服务满分

**--saveModel**: *输出模型名称*

    输出模型即为.model后缀的文件，用于后续预测数据时使用

样例:../data/raw/1625label.xlsx
<br>![image](rawdata.png)

# 模型加载与使用
## 2.1执行命令
可运行下列命令根据输入的文件进行训练，在model/路径下执行
## 2.1.1加载预训练模型
python3 classify.py --model pre-trained.model --data data.xlsx， 结果输出在data.xlsx
## 2.1.2加载训练模型
python3 classify.py --model csa_user_comment.model --data data.xlsx， 结果输出在data.xlsx
## 2.2数据格式
模型的使用需要下列格式的文件
文件尾缀: ".model"

## 2.3待分类文件格式
**--data.xlsx**:  *待分类文件名*

    xlsl文件只有一个表，表名字可以是任何，表中每行数据即是每条需要被分类的数据
    
样例:../data/raw/test.xlsx
<br>![image](test.png)
## 2.4输出文件格式
**输出文件名是prediction.xls，路径在/data/prediction/下**:  

    1. 输出文件只有一个表，表名prediction
    2. 表中有三列，三列名字分别为raw example / segment example / prediction
       raw example中是待分类的原始数据，segment example是待分类经过预处理后的数据,prediction下是分类结果

样例:../data/prediction/prediction.xlsx
<br>![image](prediction.png)

# 运行流程
## 运行流程在model/下有juypter notebook一步一步实现流程
所有命令均在model/路径下执行
## 3.1情景1:客户训练自己的模型
    在命令行中运行命令python3 train.py --trainData input.xlsx  --saveModel “客户自己定义的模型文件名” --c 0.04 --gamma 10 --prob 0.5
    即可得到训练模型于/model/下
## 3.2情景2:使用预先训练好的模型pre-trained.model预测结果
    在命令行中运行命令python3 classify.py --model pre-trained.model --data data.xlsx
    即可得到预测结果prediction.xls于../data/prediction/下
## 3.3情景3:使用客户自行训练的模型预测结果
    在命令行中运行命令python3 classify.py --model “客户定义的训练模型文件名” --data data.xlsx
    即可得到预测结果prediction.xls于../data/prediction/下  
# 相关文件
文件夹data/raw下存放输入训练数据，以及需要测试的数据

文件夹data/prediction下是输出结果

文件夹model下存放预先训练好的model文件以及核心代码

# 依赖包要求
<br>python要求 3.7
<br>scikit learn相关包，mlxtend机器学习包
<br>pkuseg北大中文分词包,zhon中文分词包，jieba分词包，
<br>xlrd,xlwt包

