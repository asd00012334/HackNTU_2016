using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread portThread;
        Thread petThread;
        delegate void VoidDelegate();
        delegate void EventDelegate(object sender, EventArgs e);
        float diagLen;
        bool onTrial;
        bool timeTrig;
        bool close;
        int hr, min, sec, milli;
        int hrAll, minAll, secAll, milliAll;
        int level;

        Thread clkThread;
        SerialPort ardPort;
        
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            diagLen = -1;
            level = 1;
            switcherButton.Enabled = false;
            resetButton.Text = "Enter";
            close = false;
            onTrial = timeTrig = false;
            switcherButton.Click += switcherButtonClick;
            resetButton.Click += resetButtonClick;
            loadButton.Click += loadButtonClick;
            saveButton.Click += saveButtonClick;
            portThread = new Thread(new ThreadStart(portThreadMethod));
            clkThread = new Thread(new ThreadStart(clkThreadMethod));
            petThread = new Thread(new ThreadStart(petThreadMethod));
            portThread.IsBackground = clkThread.IsBackground = petThread.IsBackground = true;
            dialog.Enabled = false;
            clkThread.Start();
            portThread.Start();
            petThread.Start();
        }

        private void switcherButtonClick(object sender, EventArgs e)
        {
            onTrial = !onTrial;
            resetButton.Enabled = !resetButton.Enabled;
            if (onTrial)
            {
                switcherButton.Text = "Stop";
                loadButton.Enabled = saveButton.Enabled = false;
            }
            else
            {
                loadButton.Enabled = saveButton.Enabled = true;
                switcherButton.Enabled = true;

                switcherButton.Text = "Start";
                dialog.Text = hr + " hr " + min + " min " + sec + "." + milli / 100 + "sec\r\n";
                dialog.Text += hrAll + " hr " + minAll + " min " + secAll + "." + milliAll / 100 + "sec\r\n";
                dialog.Text += "Eye Care Pet lv." + level + "\r\n";
                dialog.Text += "   / \\__\r\n  (    @\\___\r\n  /         O\r\n /   (_____/\r\n/_____/   U\r\n\r\n";
            }
        }

        private void resetButtonClick(object sender, EventArgs e)
        {
            hr = min = sec = milli = 0;
            hrAll = minAll = secAll = milliAll = 0;
            switcherButton.Enabled = false;
            diagBox.Enabled = !diagBox.Enabled;
            if (resetButton.Text == "Reset")
            {
                resetButton.Text = "Enter";
                switcherButton.Enabled = false;
                level = 1;
                diagLen = -1;
                ardPort.Write("r\n");
                diagBox.Text = "";
                dialog.Text = "";
            }
            else if(resetButton.Text == "Enter")
            {
                try {
                    diagLen = float.Parse(diagBox.Text);
                    resetButton.Text = "Reset";
                    switcherButton.Enabled = true;
                    ardPort.Write(diagBox.Text + "\n");
                    diagBox.Text += " inch";
                }
                catch (Exception)
                {
                    diagBox.Enabled = !diagBox.Enabled;
                    MessageBox.Show("Please enter a positve real number.");
                }
            }
            
        }

        private void clkThreadMethod()
        {
            clocking();
        }

        private void portThreadMethod()
        {
            
            ardPort = new SerialPort();
            ardPort.BaudRate = 9600;
            ardPort.PortName = "COM4";
            ardPort.Open();
            ardPort.DataReceived += new SerialDataReceivedEventHandler(ardPortInput);
            while (true)
            {
                
            }
        }


        delegate void ButtonSetTruthDelegate(Button sender, bool truth);
        void buttonSetTruth(Button sender, bool truth)
        {
            sender.Enabled = truth;
        }

        bool resting;
        private void clocking()
        {
            resting = false;
            int milliDist = 100;
            while (true)
            {
                
                while (onTrial||resting)
                {
                    System.Threading.Thread.Sleep(milliDist);
                    if(timeTrig)
                    {
                        milli += milliDist;
                        sec += milli / 1000;
                        milli %= 1000;
                        min += sec / 60;
                        sec %= 60;
                        hr += min / 60;
                        min %= 60;
                        if (sec >= 10 && level < 6)
                        {
                            level++;
                            ardPort.Write("l" + level + "\n");
                            sec = 0;
                        }
                    }
                    milliAll += milliDist;
                    secAll += milliAll / 1000;
                    milliAll %= 1000;
                    minAll += secAll / 60;
                    secAll %= 60;
                    hrAll += minAll / 60;
                    minAll %= 60;
                    if(onTrial) update();
                    if (resting && secAll >= 7)
                    {
                        resting = false;
                        hrAll = minAll = secAll = milliAll = 0;
                        MessageBox.Show("You can resume now.");
                        this.Invoke(new ButtonSetTruthDelegate(buttonSetTruth),switcherButton,true);
                        this.Invoke(new ButtonSetTruthDelegate(buttonSetTruth), resetButton, true);
                        this.Invoke(new ButtonSetTruthDelegate(buttonSetTruth), loadButton, true);
                    }
                    else if (secAll >= 30)
                    {
                        resting = true;
                        this.Invoke(new VoidDelegate(stoppingSet));
                    }
                }
            }
        }

        void stoppingSet()
        {
            hrAll = minAll = secAll = milliAll = 0;
            switcherButton.Enabled = false;
            resetButton.Enabled = false;
            dialog.Enabled = false;
            saveButton.Enabled = true;
            dialog.Text = "";
            switcherButton.Text = "Start";
            onTrial = false;
            MessageBox.Show("Rest for 10 min.");
            
            
        }

        private void update()
        {
            VoidDelegate upDelegate = new VoidDelegate(update);
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(upDelegate);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                /**To Do**/
                dialog.Text = hr + " hr " + min + " min " + sec + "." + milli / 100 + "sec\r\n";
                dialog.Text += hrAll + " hr " + minAll + " min " + secAll + "." + milliAll / 100 + "sec\r\n";
                dialog.Text += "Eye Care Pet lv." + level + "\r\n";
                dialog.Text += "   / \\__\r\n  (    @\\___\r\n  /         O\r\n /   (_____/\r\n/_____/   U\r\n\r\n";
                if (timeTrig)
                {
                    dialog.Text += "Right Distance";
                }
                else if (close)
                {
                    dialog.Text += "Too close";
                }
                else
                {
                    dialog.Text += "Too far";
                }

            }
        }

        void ardPortInput(object sender, EventArgs e)
        {
            EventDelegate ardPortInputDelegate = new EventDelegate(ardPortInput);
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(ardPortInputDelegate, sender, e);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                String str = ((SerialPort)sender).ReadLine();
                if (str=="1") timeTrig = true;
                else timeTrig = false;
                if (str == "2") close = true;
                else close = false;
                
            }
        }

        Bitmap[] opening = new Bitmap[24];
        Bitmap[,] media = new Bitmap[7,20];
        void petThreadMethod()
        {
            level = 1;
            for (int cnt = 1; cnt <= 23; cnt++)
                opening[cnt] = new Bitmap("../Pet/0/" + cnt + ".png");
            for(int lv = 1; lv <= 6; lv++)
            {
                for(int cnt=1; File.Exists("../Pet/" + lv + "/lv" + lv + "-" + cnt + ".JPG"); cnt++)
                {
                    media[lv, cnt] = new Bitmap("../Pet/" + lv + "/lv" + lv + "-" + cnt + ".JPG");
                }
            }


            while (true)
            {
                for (int cnt = 1; !onTrial||File.Exists("../Pet/" + level + "/lv" + level + "-" + cnt + ".JPG"); cnt++)
                {
                    if (onTrial)
                    {
                        updateImg(level, cnt);
                        Thread.Sleep(125);
                    }
                    else
                    {
                        if (cnt>23) break;
                        updateImg(0, cnt);
                        Thread.Sleep(150);
                    }
                }
            }
        }

        delegate void UpdateImg(int level, int cnt);
        void updateImg(int level, int cnt)
        {
            UpdateImg updateImgDelegate = new UpdateImg(updateImg);
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(updateImgDelegate, level, cnt);
                }
                catch (Exception)
                {
                    
                }
            }
            else if (level == 0)
            {
                pictureBox.Image = opening[cnt];
            }
            else
            {
                pictureBox.Image = media[level,cnt];
            }
        }

        private void loadButtonClick(object sender, EventArgs e)
        {
            StreamReader loadFile;
            try
            {
                loadFile = new StreamReader("../Save/saving.ep");
                level = int.Parse(loadFile.ReadLine());
                diagLen = float.Parse(loadFile.ReadLine());
                hr = min = sec = milli = hrAll = minAll = secAll = milliAll = 0;
                dialog.Text = "";
                if (diagLen < 0)
                {
                    resetButton.Text = "Enter";
                    switcherButton.Enabled = false;
                    ardPort.Write("r\n");
                    diagBox.Text = "";
                    diagBox.Enabled = true;
                }
                else
                {
                    resetButton.Text = "Reset";
                    diagBox.Text = (diagLen).ToString() + " inch";
                    diagBox.Enabled = false;
                    switcherButton.Enabled = true;
                    ardPort.Write(diagBox.Text + "\n");
                }
                MessageBox.Show("Loaded from lv."+level);
                loadFile.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No previous record detected.");
            }
        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            StreamWriter saveFile;
            try
            {
                saveFile = new StreamWriter("../Save/saving.ep");
                saveFile.WriteLine((level).ToString());
                saveFile.WriteLine(diagLen);
                saveFile.Close();
            }
            catch
            {
                MessageBox.Show("Saving Failure.");
            }
        }
        
    }
}
