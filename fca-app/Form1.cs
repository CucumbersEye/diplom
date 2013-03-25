using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fca_app.src;

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
            FcaMatrix obj = new FcaMatrix();
            FcaObjectSet set = new FcaObjectSet();
            string[] text = textBox.Lines;
            int[][] matrix = new int[text.Length][];
            int i, j;
            i = 0;
            bool t = false;
            foreach (string line in text) {
                j = 0;
                string[] numbers = line.Split();
                matrix[i] = new int[numbers.Length];
                FcaObject el = new FcaObject();
                el.setName(i.ToString());
                el.setId(i);
                foreach (string num in numbers) {
                    matrix[i][j] = int.Parse(num);
                    if (t == false)
                    {
                        FcaAttribute atr = new FcaAttribute();
                        atr.setName(j.ToString());
                        atr.setId(j);
                        obj.addAttribute(atr);
                    }
                    j++;
                }
                el.setAttributes(matrix[i]);
                obj.addObject(el);
                i++;
                t = true;
            }
            obj.setMatrix(matrix);
            obj.sortMatrix();
            set.closure(obj.getElemById(2), obj);
            
        }
    }
}
