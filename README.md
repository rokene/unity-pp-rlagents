# Hummingbird ML Agents

A simple demonstration on training a hummingbird to play a hummingbird game.

## Prerequisites
* Python 3.10.12
* Unity - ML Agents 3.0.0
* Python - mlagents-1.1.0

## ML Agents

[Project Root](https://github.com/Unity-Technologies/ml-agents/tree/com.unity.ml-agents_3.0.0)

[Docs](https://github.com/Unity-Technologies/ml-agents/tree/com.unity.ml-agents_3.0.0/docs)

[Training ML Agents](https://github.com/Unity-Technologies/ml-agents/blob/develop/docs/Training-ML-Agents.md)

[Trainer Config YAML Docs](https://github.com/Unity-Technologies/ml-agents/blob/com.unity.ml-agents_3.0.0/docs/Training-Configuration-File.md)

# Usage

## Setup

[Anaconda](https://www.anaconda.com/) is used to control python versioning in windows. Download and install.

```bash
# list conda environments
conda env list

# initalizes conda in your current shell if needed
conda init

# update conda
conda update -n base -c defaults conda

conda install numpy

# create env for ml agents if missing
conda create -n ml-agents-1.0 python=3.10.12

# activate ml agent env
conda activate ml-agents-1.0

pip install --upgrade pip
pip install mlagents==1.1.0

# deactivate ml agent env when done
conda deactivate
```

## ML Agents CLI

> Your trained model will be at results/<run-identifier>/<behavior_name>.onnx

Training your agent.

```bash
cd mla
mlagents-learn ./trainer_config.yaml --run-id hummingbird01
```

> You can start this while training to view results in real-time.

View results on tensorboard ui. [Docs](https://github.com/Unity-Technologies/ml-agents/blob/com.unity.ml-agents_3.0.0/docs/Using-Tensorboard.md)

```bash
tensorboard --logdir ./mla/results --port 6006
```

## Configuring Pre-Trained Models

Your trained model will be at results/<run-identifier>/<behavior_name>.onnx where <behavior_name> is the name of the Behavior Name of the agents corresponding to the model. This file corresponds to your model's latest checkpoint. You can now embed this trained model into your Agents by following the steps below, which is similar to the steps described above.

Move your model file into Project/Assets/ML-Agents/Examples/3DBall/TFModels/.
Open the Unity Editor, and select the 3DBall scene as described above.
Select the 3DBall prefab Agent object.
Drag the <behavior_name>.onnx file from the Project window of the Editor to the Model placeholder in the Ball3DAgent inspector window.
Press the Play button at the top of the Editor.
