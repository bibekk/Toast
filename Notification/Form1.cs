using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notification
{
    public partial class Form1 : Form
    {
        public int progress = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressLoad.Value = 0;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            timer2.Tick += Timer2_Tick;

            if (!Cef.IsInitialized)
            {
                Cef.Initialize();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            progressLoad.Value = 0;
            progressLoad.Hide();
            timer2.Stop();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressLoad.Value = progress;
            progress += 1;
        }

        public void GetPdf(string url)
        {
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
                
            };

            chrome.Parent = viewPanel;
            chrome.LoadingStateChanged += Chrome_LoadingStateChanged;
            chrome.LoadError += Chrome_LoadError;
        }

        private void Chrome_LoadError(object sender, LoadErrorEventArgs e)
        {
            MessageBox.Show("Error while loading.","Error loading",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void Chrome_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        progressLoad.Value = 0;
                        progressLoad.Show();
                    }));
                }
            }
            else
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        timer1.Stop();
                        progressLoad.Value = 100;
                        timer2.Start();
                    }));
                }
            }
           
            Console.WriteLine(e.IsLoading.ToString());
        }
    }
}
