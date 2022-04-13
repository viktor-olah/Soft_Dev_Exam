using System;
using System.Collections;
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
    public partial class Listazas : Form
    {

        ArrayList sortedList;

        internal Listazas(List<Epulet> atvittelemek)
        {
            sortedList = new ArrayList();
            InitializeComponent();
            FixScreenResolution();
            ResolutionCtrl();

            foreach (Epulet item in atvittelemek)
            {
                sortedList.Add(item);
            }
            sortedList.Sort();

            listBox1.Items.AddRange(sortedList.ToArray());
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
    }
}
