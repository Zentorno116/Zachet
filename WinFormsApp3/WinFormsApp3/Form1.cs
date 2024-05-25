using System.Text;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        List<string[]> animals;
        List<string> types;
        string directory = "../../../";
        FolderBrowserDialog folderBrowserDialog1;
        public Form1()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(directory);
            
            animals = new List<string[]>();
            types = new List<string>();
            StreamReader file = new StreamReader(directory + "/“ËÔ˚ ∆Ë‚ÓÚÌ˚ı.txt");
            while (!file.EndOfStream)
            {
                string s = file.ReadLine();
                string[] parts = s.Split(';');
                types.Add(parts[1]);
            }
            StreamReader f = new StreamReader(directory + "/∆Ë‚ÓÚÌ˚Â.txt");
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                string[] parts = s.Split(';');
                dataGridView1.Rows.Add(parts[0], parts[2], parts[3]);
                animals.Add(new string[2] { parts[4] + ".jpg", types[int.Parse(parts[1])] });
            }
            f.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex;
            int x = e.ColumnIndex;
            if (y < animals.Count && x < 3)
            {
                pictureBox1.Image = new Bitmap(directory + "/»ÁÓ·‡ÊÂÌËˇ/" + animals[y][0]);
                comboBox1.Text = animals[y][1];
                textBox1.Text = dataGridView1.Rows[y].Cells[1].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ù‡ÈÎToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ÓÚÍ˚Ú¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                directory = folderBrowserDialog1.SelectedPath;
                animals = new List<string[]>();
                types = new List<string>();
                StreamReader file = new StreamReader(directory + "/“ËÔ˚ ∆Ë‚ÓÚÌ˚ı.txt");
                while (!file.EndOfStream)
                {
                    string s = file.ReadLine();
                    string[] parts = s.Split(';');
                    types.Add(parts[1]);
                }
                StreamReader f = new StreamReader(directory + "/∆Ë‚ÓÚÌ˚Â.txt");
                dataGridView1.Rows.Clear();
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    string[] parts = s.Split(';');
                    dataGridView1.Rows.Add(parts[0], parts[2], parts[3]);
                    animals.Add(new string[2] { parts[4] + ".jpg", types[int.Parse(parts[1])] });
                }
                f.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
