using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fca_app.src;
using System.IO;

namespace fca_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FcaMatrix matrix = new FcaMatrix();
            FileScanner fscan = new FileScanner();
            String[] processingFiles = Directory.GetFiles(txtSourceDir.Text);

            matrix = fscan.processFiles(processingFiles);

            FcaTree tree = new FcaTree();
            tree.closureOneByOne(matrix,tree);
            FcaObjectSet lattice = new FcaObjectSet();
            lattice.buildLattice(tree, matrix);
            fscan.RefactorHierarchy(lattice);
        }

        private void btnOpenDirDlg(object sender, EventArgs e)
        {
            Button txtBx = (Button)sender;
            if (txtBx.Name.Equals(btnOpenFinishDirDlg.Name))
            {
                fldrBrwsDlg.ShowDialog();
                String path = fldrBrwsDlg.SelectedPath;
                txtFinishDir.Text = path;
            }
            if (txtBx.Name.Equals(btnOpenSourceDirDlg.Name))
            {
                fldrBrwsDlg.ShowDialog();
                String path = fldrBrwsDlg.SelectedPath;
                txtSourceDir.Text = path;
            }
        }
    }
}
