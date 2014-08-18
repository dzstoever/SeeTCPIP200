using System;
using System.Data;
using System.Collections;

namespace csi.see.classlib1
{
    public delegate void EmptyDelegate();
    public delegate void ObjectDelegate(object o);
    public delegate void StringDelegate(string s);
    public delegate void StringStringDelegate(string s1, string s2);
    public delegate void BooleanDelegate(bool b);
    public delegate void IntegerDelegate(int i);    
    public delegate void DateTimeDelegate(DateTime dt);
    //public delegate void DataRowDelegate(DataRow drow);
    //public delegate void DataTableDelegate(DataTable dtable); 
    //public delegate void DataSetDelegate(DataSet dset, DateTime dt);    
    public delegate void UdpDelegate(UdpMessage message);    
        
    public enum UdpTypes : int
    {
        //From service To all clients
        Control = 0,
        ServiceStarted = 1,
        ServiceStopped = 2,
        InitNoSystems = 10,
        InitOpenSys = 11,
        
        //From service To client - Data
        SysDisconnected = 100,
        SysStat1 = 101,//Poll Status
        SysStat2 = 102,//Console Status
        SysReady = 110,       
        SysRcvdMessage = 120,
        SysCommandNotSent = 121,
        SysCommandProcRcvd = 122,
        SysRcvdPollData = 130,
        SysRcvdConnectRec = 131,
        SysRcvdFtpTermRec = 132,
        SysRcvdJobStepRec = 133,
        SysRcvdTraceData = 140,
        //SysTraceError = 141,
        SqlCreateError = 151,
        SqlRenameError = 152,
        SqlDropError = 153,                
        //SysGenericError = 1000,
        //SysLoginError = 1001,
        //SysPollError = 1002,
        //SysSqlError = 1003,        
       
        //From client To service - Control
        AppStarted = 200,
        AppClosed = 201,        
        SysAdded = 210,
        SysDeleted = 211,
        SysModified = 212,
        TryStartup = 300,
        SendCommand = 301,
        GetTraceData = 302,
    }

    public enum CommErrorType : int
    {
        Generic =       10000,
        Port1 =         10001,//Command - connect failed
        Port2 =         10002,//Data - connect failed
        Port3 =         10003,//Console - connect failed
        Port1Disc =     10004,//Command - unexpected disconnect
        Port2Disc =     10005,//Data - unexpected disconnect
        Port3Disc =     10006,//Console - unexpected disconnect
        Init =          10010,//LOGIN - TIMEOUT, OPENDATA or HARTBEAT - FAIL or TIMEOUT
        Login =         10011,//LOGIN - FAIL
        AllIpSkipped =  10012,//The server was busy
        Poll =          10020,//TIMEOUT or Data Overflow
        PollSkipped =   10021,//The server was busy     
        PollCommand =   10022,//Poll Command - FAIL
        TraceError =    10030,//Trace Command - FAIL or TIMEOUT      
        TraceSkipped =  10031,//The server was busy      
        ConsoleComm =   10040,//Console Command - TIMEOUT
    }

    /*
    public enum SqlErrors : int
    {
        Generic = 0,
        CreateFailed = 1,
        RenameFailed = 2,
        DropFailed = 3,        
    }*/
    
}