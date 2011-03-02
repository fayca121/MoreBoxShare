using System;
using System.Net;
using System.Threading;
using NLog;
using NLog.Config;
using NLog.Targets;
using ZylSerialPort;
using NetSockets;

namespace MoreBoxServer
{
	class Program
	{
		private static NetServer server;
		private static Thread running;
		public static SerialPort serialPort;
		private static Config settings;
		public static Logger logger;
		private static byte[] Key;
		private static bool terminated;
		private readonly static object syncRoot = new object();

		public static void Main(string[] args)
		{
			//chargement de la configuration du server
			settings = new Config();

			//configuration du logging
			InitLogging();

			//configuration du serveur
			server=new NetServer();
			server.OnClientAccepted+=server_OnClientAccepted;
			server.OnClientConnected+= server_OnClientConnected;
			server.OnClientDisconnected+= server_OnClientDisconnected;
			server.OnClientRejected+= server_OnClientRejected;

			server.OnReceived += server_OnReceived;
			server.OnStarted+= server_OnStarted;
			server.OnStopped+=server_OnStopped;

			server.TickRate = 1000;

			// configuration du port
            serialPort = new SerialPort { BaudRate = settings.BaudRate,
                DataWidth = settings.DataWidth, 
                Port = settings.Port, 
                StopBits = settings.StopBits, 
                ParityBits = settings.ParityBits, 
                Priority = ThreadPriority.Highest };

			serialPort.Received += serialPort_Received;
			serialPort.Connected += serialPort_Connected;

			if (!serialPort.Open())
			{
				logger.Error("Le port est occupé");
				Console.Write("Press any key to exit . . . ");
				Console.ReadKey(true);
				return;
			}
			try
			{
				server.Start(IPAddress.Parse(settings.Server),
				             settings.ServerPort,settings.Capacity);
				if(server.IsOnline)
				{
					running=new Thread(Run);
					running.Start();
					running.Join();
				}
			}
			catch(Exception e)
			{
				logger.Error(e.Message);
			}
			finally
			{
				Console.Write("Press any key to exit . . . ");
				Console.ReadKey(true);
			}
		}
		
		private static void serialPort_Received(object sender, DataEventArgs e)
		{
			Key = e.Buffer;
		}
		
		public static void Run()
		{
			while(!terminated)
				Thread.Sleep(2000);
		}
		
		private static void InitLogging()
		{
			//initialisation du loggin
			LoggingConfiguration config = new LoggingConfiguration();
			ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
			config.AddTarget("console", consoleTarget);
			FileTarget fileTarget = new FileTarget();
			config.AddTarget("file", fileTarget);
			consoleTarget.Layout = "${date:format=HH\\:MM\\:ss} ${level}: ${message}";
			fileTarget.FileName = "event.log";
			fileTarget.Layout="${shortdate} ${date:format=HH\\:MM\\:ss} ${level}: ${message}";
			fileTarget.ArchiveAboveSize=3072;
			fileTarget.KeepFileOpen=true;
			LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
			config.LoggingRules.Add(rule1);
			LoggingRule rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
			config.LoggingRules.Add(rule2);
			LogManager.Configuration = config;
			logger = LogManager.GetLogger("event");
		}
		
		static void server_OnClientAccepted(object sender, NetClientAcceptedEventArgs e)
		{
			logger.Info(server.ClientStreams[e.Guid].EndPoint+" Client accepted by server");
			logger.Info("Client(s) connecté(s): "+server.ClientCount);
		}
		
		static void server_OnReceived(object sender, NetClientReceivedEventArgs<byte[]> e)
		{
			lock(syncRoot)
			{
				Key = new byte[20];
				serialPort.SendByteArray(e.Data);
				//wait for key
				Thread.Sleep(600);
				server.DispatchTo(e.Guid,Key);
			}
		}
		
		static void server_OnClientConnected(object sender, NetClientConnectedEventArgs e)
		{
			logger.Info(server.ClientStreams[e.Guid].EndPoint+" Connected to server");
		}
		
		static void server_OnClientDisconnected(object sender, NetClientDisconnectedEventArgs e)
		{
			logger.Info(server.ClientStreams[e.Guid].EndPoint+" Client disconnected from server");
			logger.Info("Client(s) connecté(s): "+server.ClientCount);
		}
		
		static void server_OnClientRejected(object sender, NetClientRejectedEventArgs e)
		{
			logger.Warn(server.ClientStreams[e.Guid].EndPoint+" Client rejected by server");
		}
		
		static void server_OnStarted(object sender, NetStartedEventArgs e)
		{
			logger.Info("Server started");
		}
		
		static void server_OnStopped(object sender, NetStoppedEventArgs e)
		{
			logger.Info("Server stopped");
			if (serialPort != null)
				serialPort.Close();
			terminated=true;
		}

		static void serialPort_Connected(object sender, ConnectionEventArgs e)
		{
			logger.Info("Le port a été ouvert avec succées");
		}
	}
}