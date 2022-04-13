using EpuletManager.Classes;
using EpuletManager.Forms;

namespace EpuletManager
{
    public partial class Main : Form
    {
        List<Epulet> tarolo;
        public Main()
        {
            InitializeComponent();
            ResolutionCtrl();
            FixScreenResolution();

            tarolo = new List<Epulet>();
            
        }

        void FixScreenResolution()
        {
            this.MinimumSize = new Size(800, 600);
            this.MaximumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void ResolutionCtrl()
        {
            if (Screen.PrimaryScreen.WorkingArea.Width < 800 || Screen.PrimaryScreen.WorkingArea.Height < 600)
            {
                MessageBox.Show("Not supported screen resolution!", "Resolution Error", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Epulet.CSVSave(tarolo);

                if (MessageBox.Show("Biztosan bez�rja az ablakot", "Biztos?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UjEpuletFrm newDialog = new UjEpuletFrm();
            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                tarolo.Add(newDialog.Epulet);
                lbUpdate();
                
            }
        }

        private void lbUpdate()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = tarolo;
            lb2Update();
        }

        private void lb2Update()
        {
            listBox2.Items.Clear();
            foreach (Epulet item in tarolo)
            {
                if (item.Munkav�gz�sV�ge == DateTime.Today.Date)
                {
                    listBox2.Items.Add(item);
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex !=-1)
            {
                UjEpuletFrm newDialog = new UjEpuletFrm((Epulet)listBox1.SelectedItem);
                newDialog.ShowDialog();
                lbUpdate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && MessageBox.Show("Biztosan t�rli a kijel�lt �p�letet", "Biztosan?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tarolo.RemoveAt(listBox1.SelectedIndex);
                lbUpdate();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                this.Text = "El�zetes �rkalkul�ci�: " + (listBox1.SelectedItem as Epulet).Arkalkulacio().ToString() + " FT";
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string megjelenit = $"C�m: {(listBox1.SelectedItem as Epulet).Cim}\nAlapter�lete: {(listBox1.SelectedItem as Epulet).Alapterulet}nm\n�p�t�sianyaga: {(listBox1.SelectedItem as Epulet).Epitesianyagok}\nMunkakezd�s: {(listBox1.SelectedItem as Epulet).Munkav�gz�sKezdete.ToString("yyyy.MM.dd")}\nMunkav�ge: {(listBox1.SelectedItem as Epulet).Munkav�gz�sV�ge.ToString("yyyy.MM.dd")}";
                MessageBox.Show(megjelenit, "Adatok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("epuletek.csv"))
                {
                    tarolo = Epulet.CSVLoad();
                    lbUpdate();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                string megjelenit = $"C�m: {(listBox2.SelectedItem as Epulet).Cim}\nAlapter�lete: {(listBox2.SelectedItem as Epulet).Alapterulet}nm\n�p�t�sianyaga: {(listBox2.SelectedItem as Epulet).Epitesianyagok}\nMunkakezd�s: {(listBox2.SelectedItem as Epulet).Munkav�gz�sKezdete.ToString("yyyy.MM.dd")}\nMunkav�ge: {(listBox2.SelectedItem as Epulet).Munkav�gz�sV�ge.ToString("yyyy.MM.dd")}";
                MessageBox.Show(megjelenit, "Adatok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listazas newDialog = new Listazas(tarolo);
            newDialog.ShowDialog();
        }
    }
}