﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_lab4
{
    public partial class Form1 : Form
    {
        Number num = new Number();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>() { "Старорусская (аршин)", "Американская (ярд)", "СИ (метр)" };
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i]);
                listBox2.Items.Add(list[i]);
            }
        }
    }

    public class Number
    {
        private double _current;
    }
 }
