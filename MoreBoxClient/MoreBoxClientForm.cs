using System;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using XSerialPort;
using System.Text;
using NetSockets;

namespace MoreBoxClient
{
	public partial class MoreBoxClientForm : KryptonForm
	{
        private NetClient client;
		private StringBuilder messages;
		public SerialPort serialPort;
		private delegate void DisplayDelegate(string message);
		private delegate void ChangeBtLabelDelegate(string message);
        const string rtf = @"{{\rtf1\ansi\ansicpg1252\deff0\deflang1033{{\fonttbl{{\f0\fswiss\fprq2\fcharset0 Tahoma;}}{{\f1\fswiss\fprq2\fcharset0 Arial;}}{{\f2\froman\fprq2\fcharset0 Times New Roman;}}{{\f3\fswiss\fcharset0 Arial;}}}}{{\colortbl ;\red255\green0\blue0;\red0\green0\blue255;\red0\green128\blue0;}}{{\*\generator Msftedit 5.41.15.1507;}}{0}}}";
        private int cpt;

		public MoreBoxClientForm()
		{
			InitializeComponent();
		}

		void MoreBoxClientFormLoad(object sender, EventArgs e)
		{
            Config settings=new Config();
			//initialisation du serial port
            serialPort = new SerialPort { BaudRate = settings.BaudRate, 
                DataWidth = settings.DataWidth, 
                StopBits = settings.StopBits,
                ParityBits = settings.ParityBits, 
                Port = settings.Port, 
                Delay = 300 };
			
			serialPort.Received += serialPort_Received;
            serialPort.Connected += serialPort_Connected;
			messages=new StringBuilder();
			
			//initialisation du client
			client = new NetClient();
            client.OnDisconnected += client_OnDisconnected;
            client.OnReceived += client_OnReceived;
            client.OnConnected += client_OnConnected;
		}
		
		private void serialPort_Received(object sender, DataEventArgs e)
		{
			try
			{
                byte[] ECM = new byte[9];
                Array.Copy(e.Buffer,ECM,9);
                client.Send(ECM);
			}
			catch(IOException)
			{
				KryptonMessageBox.Show("Connection is down ", "Error",
				                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                client.Disconnect();
                serialPort.Close();
			}
		}
		
		void ConnectButtonClick(object sender, EventArgs e)
		{
			if(client.IsConnected)
			{
                client.Disconnect();
                serialPort.Close();
				return;
			}
			
			if(string.IsNullOrEmpty(serverTextBox.Text) ||
			   string.IsNullOrEmpty(portNumericUpDown.Text))
			{
				KryptonMessageBox.Show("Vous devez spécifier des informations correctes","Erreur"
				                       ,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			try
			{
                client.Connect(serverTextBox.Text, Int32.Parse(portNumericUpDown.Text));
                connectButton.Text = "Déconnecter";
			}
			catch(Exception ex)
			{
				KryptonMessageBox.Show(ex.Message,"Erreur",MessageBoxButtons.OK,
				                       MessageBoxIcon.Error);
			}
		}

		private void MoreBoxClientForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (client != null)
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                    serialPort.Close();
                }
            }
			System.Environment.Exit(System.Environment.ExitCode);
		}
		
		private void DisplayMessage(string message)
		{
			if (resultRichTextBox.InvokeRequired)
				Invoke( new DisplayDelegate( DisplayMessage ),
				       new object[] { message } );
			else
				resultRichTextBox.Rtf = string.Format(rtf,message);
		}
		
		private void ChangeBtLabel(string label)
		{
			if (connectButton.InvokeRequired)
				Invoke( new ChangeBtLabelDelegate(ChangeBtLabel),
				       new object[] { label } );
			else
				connectButton.Text = label;
		}
		
		void client_OnDisconnected(object sender, NetDisconnectedEventArgs e)
        {
            ChangeBtLabel("Connecter");
            messages.Append(@"\viewkind4\uc1\pard\f0\fs16\fs20\cf1Vous êtes déconnecté\par");
            DisplayMessage(messages.ToString());
        }
		
		void client_OnReceived(object sender, NetReceivedEventArgs<byte[]> e)
        {
            if (e.Data[0] != 0 && e.Data.Length==20)
            {
                serialPort.SendByteArray(e.Data);
                cpt = (cpt + 1) % 50;
                if (cpt == 0)
                    messages = new StringBuilder();
                string key = SerialPortUtils.ByteArrayToHexaString(e.Data).ToUpper();
                key = key.Substring(5).Trim();
                if (key.Equals("0000000000000000"))
                    messages.Append(@"\viewkind4\uc1\pard\f0\fs16\fs20\cf1 scrambled channel\par");
                else
                    messages.Append(string.Format(@"\viewkind4\uc1\pard\f0\fs16\fs20\cf3 {0}\par", key));
                DisplayMessage(messages.ToString());
            }
		}
		
		 void client_OnConnected(object sender, NetConnectedEventArgs e)
		 {
            messages.Append(@"\viewkind4\uc1\pard\f0\fs16\fs20\cf2Vous êtes connecté\par");
            DisplayMessage(messages.ToString());
            serialPort.Open();
		 }

          void serialPort_Connected(object sender, ConnectionEventArgs e) 
          {
             messages.Append(@"\viewkind4\uc1\pard\f0\fs16\fs20\cf2Port ouvert avec succées\par");
             DisplayMessage(messages.ToString());
          }
    }
}
