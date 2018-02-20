using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ParseLogForm
{
    public partial class StringConnectionForm : Form
    {
        string connectionString = "";
        string directory = "";
        // чтение строки подключение
        public StringConnectionForm()
        {
            InitializeComponent();
            directory = Directory.GetCurrentDirectory();
            directory += "\\StringConnection";

            using (var file = File.OpenText(directory))
            {
                connectionString = file.ReadLine();
                TextBoxConnectionString.Text = connectionString;
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // сохрание строки подключения
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            connectionString = TextBoxConnectionString.Text;
            File.WriteAllText(directory, connectionString);
            this.Close();
        }
    }
}
