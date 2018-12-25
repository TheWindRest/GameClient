using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public enum ServerType
{
    LoginServer = 0,
    GateServer = 1,
    CenterServer,
}

public class NetworkManager : Singleton<NetworkManager>
{
    private TcpClient m_Client = null;
    private TcpClient m_Connecting = null;
    private string m_IP = "127.0.0.1";
    private Int32 m_Port = 40001;
    private Int32 m_n32ConnectTimes = 0;
    private ServerType serverType = ServerType.LoginServer;
    private float m_CanConnectTime = 0f;
    private float m_RecvOverTime = 0f;
    private float mRecvOverDelayTime = 2f;
    private Int32 m_ConnectOverCount = 0;
    private float m_ConnectOverTime = 0f;
    private Int32 m_RecvOverCount = 0;
    public bool canReconnect = false;
    public byte[] m_RecvBuffer = new byte[2 * 1024 * 1024];
    public Int32 m_RecvPos = 0;
    IAsyncResult mRecvResult;
    IAsyncResult mConnectResult;
    //接收数据stream
    public List<int> mReceiveMsgIDs = new List<int>();
    public List<MemoryStream> mReceiveStreams = new List<MemoryStream>();
    public List<MemoryStream> mReceiveStreamsPool = new List<MemoryStream>();

    public QKEvent HandleNetMsg = new QKEvent();
    public QKEvent HandleConnect = new QKEvent();
    public QKEvent HandleDisConnect = new QKEvent();

    public NetworkManager()
    {
        for (int i = 0; i < 50; ++i)
        {
            mReceiveStreamsPool.Add(new MemoryStream());
        }
    }

    ~NetworkManager()
    {
        foreach (System.IO.MemoryStream one in mReceiveStreams)
        {
            one.Close();
        }
        foreach (System.IO.MemoryStream one in mReceiveStreamsPool)
        {
            one.Close();
        }

        if (m_Client != null)
        {
            m_Client.Client.Shutdown(SocketShutdown.Both);
            m_Client.GetStream().Close();
            m_Client.Close();
            m_Client = null;
        }
    }

    public void Init(string ip, Int32 port, ServerType type)
    {
        Debug.Log("set network ip:" + ip + " port:" + port + " type:" + type);
        m_IP = ip;
        m_Port = port;
        serverType = type;
        m_n32ConnectTimes = 0;
        canReconnect = true;
        m_RecvPos = 0;

        mRecvOverDelayTime = 20000f;
    }

    public void Connect()
    {
        if (!canReconnect) return;

        if (m_CanConnectTime > Time.time) return;

        if (m_Client != null)
            throw new Exception("fuck, The socket is connecting, cannot connect again!");

        if (m_Connecting != null)
            throw new Exception("fuck, The socket is connecting, cannot connect again!");

        Debug.Log("IClientSession Connect");

        IPAddress ipAddress = IPAddress.Parse(m_IP);

        try
        {
            m_Connecting = new TcpClient();

            mConnectResult = m_Connecting.BeginConnect(m_IP, m_Port, null, null);

            m_ConnectOverCount = 0;

            m_ConnectOverTime = Time.time + 2;
        }
        catch (Exception exc)
        {
            Debug.LogError(exc.ToString());

            m_Client = m_Connecting;

            m_Connecting = null;

            mConnectResult = null;

            OnConnectError(m_Client, null);
        }
    }

    public void Close()
    {
        if (m_Client != null)
        {
            OnClosed(m_Client, null);
        }
    }

    public void Update(float fDeltaTime)
    {
        if (m_Client != null)
        {
            DealWithMsg();

            if (mRecvResult != null)
            {
                if (m_RecvOverCount > 200 && Time.time > m_RecvOverTime)
                {
                    Debug.LogError("recv data over 200, so close network.");
                    Close();
                    return;
                }

                ++m_RecvOverCount;

                if (mRecvResult.IsCompleted)
                {
                    try
                    {
                        Int32 n32BytesRead = m_Client.GetStream().EndRead(mRecvResult);
                        m_RecvPos += n32BytesRead;

                        if (n32BytesRead == 0)
                        {
                            Debug.LogError("can't recv data now, so close network 2.");
                            Close();
                            return;
                        }
                    }
                    catch (Exception exc)
                    {
                        Debug.LogError(exc.ToString());
                        Close();
                        return;
                    }

                    OnDataReceived();

                    if (m_Client != null)
                    {
                        try
                        {
                            mRecvResult = m_Client.GetStream().BeginRead(m_RecvBuffer, m_RecvPos, m_RecvBuffer.Length - m_RecvPos, null, null);
                            m_RecvOverTime = Time.time + mRecvOverDelayTime;
                            m_RecvOverCount = 0;
                        }
                        catch (Exception exc)
                        {
                            Debug.LogError(exc.ToString());
                            Close();
                            return;
                        }
                    }
                }
            }

            if (m_Client != null && m_Client.Connected == false)
            {
                Debug.LogError("client is close by system, so close it now.");
                Close();
                return;
            }
        }
        else if (m_Connecting != null)
        {
            if (m_ConnectOverCount > 200 && Time.time > m_ConnectOverTime)
            {
                Debug.LogError("can't connect, so close network.");

                m_Client = m_Connecting;

                m_Connecting = null;

                mConnectResult = null;

                OnConnectError(m_Client, null);

                return;
            }

            ++m_ConnectOverCount;

            if (mConnectResult.IsCompleted)
            {
                m_Client = m_Connecting;

                m_Connecting = null;

                mConnectResult = null;

                if (m_Client.Connected)
                {
                    try
                    {
                        m_Client.NoDelay = true;

                        m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 2000);

                        m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 2000);

                        m_Client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                        mRecvResult = m_Client.GetStream().BeginRead(m_RecvBuffer, 0, m_RecvBuffer.Length, null, null);

                        m_RecvOverTime = Time.time + mRecvOverDelayTime;

                        m_RecvOverCount = 0;

                        OnConnected(m_Client, null);
                    }
                    catch (Exception exc)
                    {
                        Debug.LogError(exc.ToString());
                        Close();
                        return;
                    }
                }
                else
                {
                    OnConnectError(m_Client, null);
                }
            }
        }
        else
        {
            Connect();
        }
    }

    public void OnConnected(object sender, EventArgs e)
    {
        if(HandleConnect != null)
        {
            HandleConnect.Call(new object[] { serverType, m_n32ConnectTimes });
        }
    }

    public void DealWithMsg()
    {
        while (mReceiveMsgIDs.Count > 0 && mReceiveStreams.Count > 0)
        {
            int type = mReceiveMsgIDs[0];
            MemoryStream iostream = mReceiveStreams[0];
            mReceiveMsgIDs.RemoveAt(0);
            mReceiveStreams.RemoveAt(0);

            try
            {
                if(HandleNetMsg != null)
                {
                    HandleNetMsg.Call(new object[] { new LuaByteBuffer(iostream), type });
                }
                if (mReceiveStreamsPool.Count < 100)
                {
                    mReceiveStreamsPool.Add(iostream);
                }
                else
                {
                    iostream = null;
                }
            }
            catch (Exception ecp)
            {
                Debug.LogError("Handle Error msgid: " + type);
                Debug.Log(ecp.ToString());
            }
        }
    }

    public void OnDataReceived()
    {
        int m_CurPos = 0;
        while (m_RecvPos - m_CurPos >= 8)
        {
            int len = BitConverter.ToInt32(m_RecvBuffer, m_CurPos);
            int type = BitConverter.ToInt32(m_RecvBuffer, m_CurPos + 4);
            if (len > m_RecvBuffer.Length)  //数据超出范围
            {
                Debug.LogError("can't pause message" + "type=" + type + "len=" + len);
                break;
            }
            if (len > m_RecvPos - m_CurPos) //接收数据不完整
            {
                break;//wait net recv more buffer to parse.
            }
            //获取stream
            MemoryStream tempStream;
            if (mReceiveStreamsPool.Count > 0)
            {
                tempStream = mReceiveStreamsPool[0];
                tempStream.SetLength(0);
                tempStream.Position = 0;
                mReceiveStreamsPool.RemoveAt(0);
            }
            else
            {
                tempStream = new System.IO.MemoryStream();
            }
            tempStream.Write(m_RecvBuffer, m_CurPos + 8, len - 8);
            tempStream.Position = 0;
            m_CurPos += len;
            mReceiveMsgIDs.Add(type);
            mReceiveStreams.Add(tempStream);
        }
        if (m_CurPos > 0)
        {
            m_RecvPos = m_RecvPos - m_CurPos;

            if (m_RecvPos < 0)
            {
                Debug.LogError("m_RecvPos < 0");
            }

            if (m_RecvPos > 0)
            {
                Buffer.BlockCopy(m_RecvBuffer, m_CurPos, m_RecvBuffer, 0, m_RecvPos);
            }
        }
    }

    public void SendMsg(LuaByteBuffer pMsg, Int32 n32MsgID)
    {
        Debug.Log("发送消息：<color=#9400D3>" + n32MsgID + "</color>");
        if (m_Client != null)
        {
            CMsg pcMsg = new CMsg(pMsg.Length);
            pcMsg.SetProtocalID(n32MsgID);
            pcMsg.Add(pMsg.buffer, 0, pMsg.Length);
            try
            {
                m_Client.GetStream().Write(pcMsg.GetMsgBuffer(), 0, (int)pcMsg.GetMsgSize());
            }
            catch (Exception exc)
            {
                Debugger.LogError(exc.ToString());
                Close();
            }
        }
    }

    public void OnConnectError(object sender, ErrorEventArgs e)
    {
        Debug.Log("OnConnectError begin");

        try
        {
            m_Client.Client.Shutdown(SocketShutdown.Both);
            m_Client.GetStream().Close();
            m_Client.Close();
            m_Client = null;
        }
        catch (Exception exc)
        {
            Debug.Log(exc.ToString());
        }
        mRecvResult = null;
        m_Client = null;
        m_RecvPos = 0;
        m_RecvOverCount = 0;
        m_ConnectOverCount = 0;

        if (HandleDisConnect != null)
        {
            HandleDisConnect.Call(new object[] { serverType });
        }

        Debug.Log("OnConnectError end");
    }

    public void OnClosed(object sender, EventArgs e)
    {
        if (HandleDisConnect != null)
        {
            HandleDisConnect.Call(new object[] { serverType });
        }

        try
        {
            m_Client.Client.Shutdown(SocketShutdown.Both);
            m_Client.GetStream().Close();
            m_Client.Close();
            m_Client = null;
        }
        catch (Exception exc)
        {
            Debug.Log(exc.ToString());
        }

        mRecvResult = null;
        m_Client = null;
        m_RecvPos = 0;
        m_RecvOverCount = 0;
        m_ConnectOverCount = 0;
        mReceiveStreams.Clear();
        mReceiveMsgIDs.Clear();
    }
}
