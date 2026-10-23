# thmonitor

温湿度监测小工具，**WinForms + Modbus RTU**，通过串口从传感器读数据，界面上实时看温湿度。跟着课程做的小项目。

```
温湿度传感器 ──串口（Modbus RTU）──► thmonitor（WinForms）──► 实时显示
```

## 快速开始

### 1. 接线

传感器接电脑串口；没有串口的机器，用 USB 转串口，驱动先装好。

### 2. 打开项目

VS 打开 `THProject.sln`，启动项目选 `THProjectMain`。

### 3. 选串口

界面里选对应的 COM 口，波特率和传感器手册对上，点开串口就开始读数据。

## 目录

```
thmonitor/
├─ THProjectMain/       # 主程序
├─ ModbusBase/          # Modbus 基础库
├─ ModbusRTULib/        # RTU 协议相关
└─ MycontrolsTandHtest/ # 温湿度显示的控件
```

## 常见问题

- **读不到数据**：就三样——COM 口选对、线接好、波特率站号和传感器手册对上。
- **数据乱跳**：多半是波特率不匹配，或者线太长被干扰。
- **打不开串口**：串口被别的程序占着，先把其他串口工具关掉。
