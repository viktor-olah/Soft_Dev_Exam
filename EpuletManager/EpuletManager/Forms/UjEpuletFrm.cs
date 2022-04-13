using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpuletManager.Classes;

namespace EpuletManager.Forms
{
    enum epuletvalaszto
    {
        Családiház,
        Tömbház
    }
    public partial class UjEpuletFrm : Form
    {
        internal Epulet Epulet { get; set; }

        public UjEpuletFrm()
        {
            InitializeComponent();
            ResolutionCtrl();
            FixScreenResolution();
            comboBox1.DataSource = Enum.GetValues(typeof(epuletvalaszto));
            comboBox2.DataSource = Enum.GetValues(typeof(epitesianyag));
            comboBox3.DataSource = Enum.GetValues(typeof(tetotipusa));
            comboBox4.DataSource = Enum.GetValues(typeof(LakasfenntartasTipusa));
        }

        internal UjEpuletFrm(Epulet modosit):this()
        {
            Epulet = modosit;
            textBox1.Text = modosit.Cim;
            numericUpDown1.Value = (int)modosit.Alapterulet;
            comboBox2.SelectedIndex = (int)modosit.Epitesianyagok;
            dateTimePicker1.Value = modosit.MunkavégzésKezdete;
            dateTimePicker2.Value = modosit.MunkavégzésVége;
            if (modosit is Csaladihaz)
            {
                numericUpDown2.Value = (modosit as Csaladihaz).OttelokSzama;
                checkBox1.Checked = (modosit as Csaladihaz).GarazsVanE;
                comboBox3.SelectedIndex = (int)(modosit as Csaladihaz).Tetok;
                comboBox1.SelectedIndex = (int)epuletvalaszto.Családiház;

            }
            else
            {
                numericUpDown3.Value = (modosit as Tombhaz).LakasokSzama;
                comboBox4.SelectedIndex = (int)(modosit as Tombhaz).FenntartasiTipus;
                checkBox2.Checked = (modosit as Tombhaz).LiftVanE;
                comboBox1.SelectedIndex = (int)epuletvalaszto.Tömbház;
            }
            numericUpDown3.Enabled = false;
            checkBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            comboBox2.Enabled = false;

        }


        #region Screen
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Epulet == null)
                {
                    switch ((epuletvalaszto)comboBox1.SelectedIndex)
                    {
                        case epuletvalaszto.Családiház:
                            Epulet = new Csaladihaz(textBox1.Text, (int)numericUpDown1.Value, dateTimePicker1.Value, dateTimePicker2.Value, (epitesianyag)(int)comboBox2.SelectedIndex, (int)numericUpDown2.Value, checkBox1.Checked, (tetotipusa)(int)comboBox3.SelectedIndex);
                            break;
                        case epuletvalaszto.Tömbház:
                            Epulet = new Tombhaz(textBox1.Text, (int)numericUpDown1.Value, dateTimePicker1.Value, dateTimePicker2.Value, (epitesianyag)(int)comboBox2.SelectedIndex, (int)numericUpDown3.Value, checkBox2.Checked, (LakasfenntartasTipusa)(int)comboBox4.SelectedIndex);
                            break;
                        
                    }
                   
                }
                else
                {
                    Epulet.Alapterulet = (int)numericUpDown1.Value;
                    Epulet.MunkavégzésKezdete = dateTimePicker1.Value;
                    Epulet.MunkavégzésVége = dateTimePicker2.Value;
                    if (Epulet is Csaladihaz)
                    {
                        (Epulet as Csaladihaz).OttelokSzama = (int)numericUpDown2.Value;
                        (Epulet as Csaladihaz).GarazsVanE = checkBox1.Checked;
                        (Epulet as Csaladihaz).Tetok = (tetotipusa)(int)comboBox3.SelectedIndex;
                    }
                    else if (Epulet is Tombhaz)
                    {
                        (Epulet as Tombhaz).FenntartasiTipus = (LakasfenntartasTipusa)(int)comboBox4.SelectedIndex;
                    }
                }
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((epuletvalaszto)comboBox1.SelectedIndex)
            {
                case epuletvalaszto.Családiház:
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    break;
                case epuletvalaszto.Tömbház:
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    break;
               
            }
        }
    }
}
