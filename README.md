# HotUpdate
基于Unity平台，tolua架构下的纯lua热更项目框架
## 项目说明
### 功能
1. 纯Lua开发业务逻辑，只要C#底层不改动，直接打AB包导出至服务端即可实现热更新  

2. 可以在线多线程下载、断点续传，大文件资源传输效率、容错率更高  

3. 具备广播、计时器、对象池等常用游戏管理类  

4. 资源加载架构 自动管理资源加载源

5. ui管理架构 自动管理层级、委托事件、AB包加载卸载等功能

6. 包含C#编写的支持异步的http、socket网络模块

7. 无第三方插件，底层均为开源手写

### 工作流
#### lua调用工作流
- 无需依赖某个场景，运行自动通过Unity的特性`RuntimeInitializeOnLoadMethod`自动调用入口函数`Main.cs`中的`main函数`，添加tolua客户端组件`LuaClient.cs`，再通过`LuaClient.cs`加载lua入口文件`main.lua`，开始纯lua调用
- 场景转换将触发`main.lua`内的`OnLevelWasLoaded`函数，通过broadcast广播的形式，在`ui.lua`监听，并创建`scene_[name].lua`实例
- 场景实例中，通过`ui.showUI`的方式再次创建`ui_[name].lua`实例，大部分的游戏逻辑，均写在UI实例中，个别需要绑定在具体物体上的逻辑，可以创建`comp_[name].lua`实例。
#### 热更工作流
详见个人博客文章[Unity资源热更新知识梳理及工作流介绍](http://ggblog.site/2021/06/28/ckra9wmax001b58up30fcfbdc/)
## 入门指南
 
这些说明将为您提供项目的副本，并在您的本地机器上运行，用于开发和测试。有关如何在活动系统上部署项目的说明，请参阅部署。
 
### 环境依赖

- Unity 2020.3.4f1c1
 
### 安装
  
1. 通过github下载项目  
`https://github.com/GrayGuardian/ggb-game-client.git`
2. 修改项目配置
  - 修改`Assets\Resources\AssetBundles\lua\const\GAME_CONST.lua.txt` 的`Api_Url`、`Download_Url`字段值为下载服务器配置
3. 点击菜单栏`Tool - AssetBundle - Build - Build`，导出加密AB包及资源文件至`Build文件夹`
4. 将`Build文件夹`所有的资源文件，放置在下载服务器上
 
## 运行测试
 
- 无需选择场景，直接点击Play启动测试

此处仅展示如何快速启动项目测试，具体配置方式请看下方项目导出
 
## 项目导出APK
1. 点击 `Lua - Clear warp files` 清空文件，等待按提示重新生成

2. 修改 `Assets/Editor/AssetBundles/AssetBundleToolEditor.cs` 中的配置
	- 修改资源版本信息 >>> `VModel vModel = new VModel()`
	- 修改与包体绑定的资源文件 >>> `string[] defaultFiles = new string[] { }` 

3. 点击菜单栏`Tool - AssetBundle - Build - Build`，导出加密AB包及资源文件至`Build文件夹`

4. 将`Build文件夹`所有的资源文件，放置在下载服务器上

5. Unity直接打包APK项目

打包完毕后的apk 若C#底层代码未修改，则无需重新打包，重复2-5步导出资源文件至下载服务器，重开apk即可进行在线热更新。
 
## 内置
 
* [tolua](https://github.com/topameng/tolua) - tolua框架
