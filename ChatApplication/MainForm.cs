using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkApplication
{

    public delegate void UpdateCurrenChatroomNamesHandler(string[] _chatroomNames);

    public partial class MainForm : Form
    {

        public string START_SERVER_STRING = "Start Server";
        public string STOP_SERVER_STRING = "Stop Server";

        private static MainForm _instance = new MainForm();
        public static MainForm GetInstance { get { return _instance; } }


        private MainForm()
        {
            InitializeComponent();
            Console.WriteLine(GetIP());
        }

        private void ControlServerBtn_Click(object sender, EventArgs e)
        {
            bool isRequestServerListening = RequestServer.IsListening;
            if (!isRequestServerListening)
            {
                RequestServer.StartListener(GetIP(), 1337);
                
                this.controlServerBtn.Text = this.STOP_SERVER_STRING;
            }
            else
            {
                RequestServer.StopListener();
                this.controlServerBtn.Text = this.START_SERVER_STRING;
            }
        }

        private string GetIP(){
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public void PopulateCurrentUsersListView(string[] _chatroomNames)
        {
            if (this.InvokeRequired)
            {
                UpdateCurrenChatroomNamesHandler d = new UpdateCurrenChatroomNamesHandler(PopulateCurrentUsersListView);
                this.Invoke(d, new object[] { _chatroomNames });
            }
            else
            {
                this.currentChatroomsListview.Items.Clear();
                ListViewItem lvi = new ListViewItem(_chatroomNames);
                this.currentChatroomsListview.Items.Add(lvi);
            }
        }


    }
}
