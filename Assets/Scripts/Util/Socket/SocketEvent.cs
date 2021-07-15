/// <summary>
/// 网络事件协议ID枚举
/// </summary>
public enum SocketEvent
{
    sc_head = 0x0001,   //心跳包
    sc_disconn = 0x0002,   //客户端主动断开
    sc_kickout = 0x0003,    //服务端踢出

    sc_test = 0x1001,   //测试用
}
