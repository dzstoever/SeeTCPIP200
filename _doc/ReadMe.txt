$README_SeeTCPIP.txt

The VSE component is distributed with TCP/IP 1.5F.

After installing and activating TCP/IP 1.5F

Modify and run the below sample job to startup SeeTCPIP:
// JOB SVSESRVR
// OPTION LOG,PARTDUMP,NOSYSDMP
// OPTION SYSPARM='00' = SysId of TCP/IP partition to be monitored
// LIBDEF PHASE,SEARCH=lib.sublib  TCP/IP lib.sublib
// EXEC SVSESRVR,SIZE=SVSESRVR
SETPORT  5450
SETUSER1 $SEEVSE1 $SEEVSE1
TRACEDSP 64K
/*
/&
The SVSESRVR job will stay up, and can be run in any static or
dynamic partition with a minimum of 8-meg of virtual storage.
The SVSESRVR can be shutdown with a "MSG xx,DATA=SHUTDOWN" command
from the VSE system console.
The following additional commands can be sent to the SVSESRVR partition
with the VSE attention routine MSG xx,DATA=command
xx is the partition id of the partition running the SVSESRVR job.
All commands can also be entered as card input by being placed in the
sysipt after the // EXEC SVSESRVR jcl statement.

SETPORT  nnnnn
Sets the listen port for the PC client to connect into.
The PC client also opens a polling port that is 1 less than the SETPORT number.
The PC client also opens a logging port that is 2 less than the SETPORT number.
The default ports used are 5450, 5449, and 5448.
This may be useful to know when configuring firewall settings.
This command is only valid in the sysipt card input.

SETUSER1 userid password
The SETUSER1 command creates the userid and password that must be
entered when prompted for by the PC login prompt box.
The userid and password are not case sensitive.
Once the userid associated with SETUSER1 is successfully logged in
records will be sent from the VSE SVSESRVR to the PC and stored into a
database on the PC.

SHUTDOWN
Will terminate the SVSESRVR partition.

SETSYSID nn
Sets the TCP/IP sysid (overrides // OPTION SYSPARM= setting).
This command is only valid in the sysipt card input.

CONTROL SEEVSE ATTACH/DETACH
This command will open a control connection with the TCP/IP partition
and send a control command and receive the response from it.
The "CONTROL SEEVSE ATTACH" will attach the SVSEMNTR phase in the TCP/IP
partition.
The "CONTROL SEEVSE DETACH" will detach the SVSEMNTR phase in the TCP/IP
partition.
Both of the above commands are automatically issued during the startup
and shutdown of the SVSESRVR partition and therefore should not be
necessary to issue...
The CONTROL command should only be issued when requested by CSI
technical support.

SEGMENT
This command will cause the VSE/Power syslst output of the SVSESRVR
partition to be segmented.

RESETPCX
This command will abruptly close the current SeeTCPIP client connections.
A new listen will then be issued.
This can be useful when the PC is unable to establish a connection with
the SVSESRVR partition. After the reset occurs a new listen will not be
issued until a 30 seconds quiece timer has expired.
So you should wait about 1 minute after issueing this command before
attempting to reconnect from a PC client.

STATUS
This command will display the PC session currently active with the SVSESRVR partition.
MSG xx
where xx is the partition id of the SVSESRVR partition(with no ,DATA=)
also defaults to issueing the STATUS command.

ABEND
This command will cause the SVSESRVR partition to abend.
This command should only be issued when requested by CSI
technical support when diagnosing a problem with SeeTCPIP.

SETMSG NONE/ALL/UP
This command can be used to control the messages issued.
All messages are always sent to SYSLST.
NONE for no messages to the system console.
ALL  for all messages to the system console.
UP   for translating all messages to upper case.

DISPLAY IPALL
This command can be used to display on the VSE system console
all the foreign IP addresses and activity on them.

DEBUG  ON/OFF
This command can be used to dynamically turn on or off diagnostics.
ON is the same is UPSI 1xxxxxx1 setting, but allows dynamically turning
it on and off. ON also activates all messages to the system console.
OFF is the same as UPSI 0xxxxxx0 setting.
This command should only be issued when requested by CSI
technical support when diagnosing a problem with SeeTCPIP.

MONBSDC xx
This command allows the monitoring of a single partition that is using
the EZA or Basic Socket Application Programming Interface(BSD/C).
xx is the partition id to be used.
F1 or F2 for example would usually be the Power or CICS partitions.
This meant mostly for assistance in monitoring a application that
uses the EZA or BSD/C api's.

TRACEDSP nnnK
This command sets the size of the dataspace that will be created to
capture datagrams. The packet capture button can then be used to create
a .pcap file on the PC and analyzed with the free PC WireShark utility.
This dataspace of captured datagrams is copied into the 31-bit storage
of the SVSESRVR partition at a time interval controlled by the TRACETIM
command(see below). It is basically a sample of datagram activity.

TRACEDMP
This command can be used to dump the contents of th last full dataspace
containing captured datagrams.
This command should only be issued when requested by CSI
technical support when diagnosing a problem with SeeTCPIP.

TRACEMSZ nnnnn
This command sets the maximum size for a single datagram to be captured.
Datagrams that exceed this value will simply be truncated to this size.
Using a value of zero will cause only the IP and TCP headers to be
recorded in the dataspace.

TRACETIM nnnn
This command sets the timer to be used by the SVSESRVR to check and copy
the dataspace containing captured datagrams.
The default is 60 seconds.

TRACESTP
This command(with no operands) will stop/freeze the recording of
datagrams into the dataspace containing captured datagrams.
TRACESTP GO can the be used to restart the recording of datagrams into
the dataspace.

TRACETAB OFF/ON
OFF is the default setting and will cause all
datagrams to be captured if a TRACEDSP command has
been previously issued.
TRACETAB ON will capture only datagrams that match a
DEFINE TRACE (TCP/IP command). In addition, the ID= of
the DEFINE TRACE command must start with the string:
"SEE" for SeeTCP/IP to consider the definition for
filtering.


The SVSESRVR also uses the UPSI jcl statement to activate debugging
options as follows.
// UPSI 1XXXXXXX Issue dump for abends in svsesrvr
// UPSI X1XXXXXX If TCP/IP is not up, wait for it to come up...
// UPSI XX1XXXXX Have SVSEMNTR issue diagnostic msgs
// UPSI XXX1XXXX not used
// UPSI XXXX1XXX not used
// UPSI XXXXX1XX Dump control blocks during initialization
// UPSI XXXXXX1X Activate storage monitoring for svsesrvr
// UPSI XXXXXXX1 Issue lots of sdumps for debugging
The UPSI jcl statements should be added when requested by CSI technical
support.


The SeeTCP/IP packet capture feature stores datagrams
into a dataspace. The PC component's "Packet Capture"
button can then be used to retrieve and store the
datagrams, converting them to the standard "pcap"
format. Analysis can then be performed with a variety
of programs, such as the free "Wireshark" utility.
By default, all packets are captured as a sampling of
activity.

ZP15F257 is a replacement zap for the IPSERVIB.phase
that allows the capture to be restricted to only those datagrams
that match a corresponding DEFINE TRACE command.
In this manner, the DEFINE TRACE command can be used
to limit the datagrams being captured for SeeTCP/IP
processing.

ZP15F258 is a replacement zap for the SVSESRVR.phase that
add a new "TRACETAB OFF/ON" command. It can then be issued
to the SVSESRVR partition --note that this is NOT a TCP/IP
partition command.
TRACETAB OFF is the default setting and will cause all
datagrams to be captured if a TRACEDSP command has
been previously issued.
TRACETAB ON will capture only datagrams that match a
DEFINE TRACE (TCP/IP command). In addition, the ID= of
the DEFINE TRACE command must start with the string:
"SEE" for SeeTCP/IP to consider the definition for
filtering.

For example, if you wanted to capture only datagrams
for IP address 192.168.0.153, issue the following
commands:

MSG xx,DATA=TRACETAB ON ("xx" is the SVSESRVR partition id)

MSG yy ("yy" is the TCP/IP partition id)
DEFINE TRACE,ID=SEE001,IPADDR=192.168.0.153

with the above commands only datagrams for IP address
192.168.0.153 will be captured into the SeeTCPIP packet
capture facility.

SeeTCPIP PC component
On the PC run the SetupSee.msi.

Problems/Questions?
Email support@e-vse.com

