using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using EntityLogDataBase.Parser;

namespace ParseLogForm
{
    public partial class MainForm : Form
    {
        string directoryFile = "";
        string stringConnection = "";

        // чтение файла со строкой подключения
        public MainForm()
        {
            InitializeComponent();

            string directoryStringConnection = Directory.GetCurrentDirectory() + "\\StringConnection";

            if (File.Exists(directoryStringConnection))
                using (var file = File.OpenText(directoryStringConnection))
                {
                    stringConnection = file.ReadLine();
                }
            else
                File.Create(directoryStringConnection).Close();

            ProgressBar.Step = 0;
            ProgressBar.PerformStep();
        }

        private void ProgressBar_Click(object sender, EventArgs e)
        {

        }

        // выбор директории лог файла
        private void ButtonDirectory_Click(object sender, EventArgs e)
        {
            ProgressBar.Step = 0;
            ProgressBar.PerformStep();

            OpenFileDialog directory = new OpenFileDialog();
            directory.Filter = "Log file (*.*)|*.*";
            directory.FileName = "log";
            if (directory.ShowDialog() == DialogResult.OK)
            {
                directoryFile = directory.FileName;
                State.ForeColor = Color.Black; State.Text = "File opening";
            }            
        }

        // загрузка логов в базу
        private void ButtonRun_Click(object sender, EventArgs e)
        {
            if (stringConnection != "" && stringConnection != null && directoryFile != "" && directoryFile != null)
            {
                State.ForeColor = Color.Black; State.Text = "Please wait";
                ParseLog parseLog = new ParseLog(directoryFile, stringConnection);
                parseLog.ReadLogFile();
                this.UpdateProgress(parseLog);
                State.ForeColor = Color.Green; State.Text = "Complite!";
            }
            else { State.ForeColor = Color.Red; State.Text = "Noncorrect string connection or firectory file!"; }
        }

        // строка подключения
        private void StringConnection_Click(object sender, EventArgs e)
        {
            StringConnectionForm window = new StringConnectionForm();
            window.ShowDialog();

            string directoryStringConnection = Directory.GetCurrentDirectory() + "\\StringConnection";
            if (File.Exists(directoryStringConnection))
                using (var file = File.OpenText(directoryStringConnection))
                {
                    stringConnection = file.ReadLine();
                }
            else
                File.Create(directoryStringConnection).Close();

            ProgressBar.Step = 0;
            ProgressBar.PerformStep();
        }

        // обновление строки прогресса
        private void UpdateProgress(ParseLog parseLog)
        {
            int i = 0;
            while (true)
            {
                ProgressBar.Step = Convert.ToInt32(parseLog.GetProgess()*100);
                ProgressBar.PerformStep(); 
                Thread.Sleep(10);
                if (ProgressBar.Step == Convert.ToInt32(parseLog.GetProgess()*100)) i++;
                else i = 0;
                if (i == 50) break;
            }
            ProgressBar.Step = 100;
            ProgressBar.PerformStep();
        }
    }
}
