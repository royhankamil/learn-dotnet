﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodCourt.Resources;

namespace FoodCourt
{
    public partial class memberMainForm : Form
    {
        FoodcourtEntities db = new FoodcourtEntities();
        public memberMainForm(int user_id)
        {
            InitializeComponent();

            
        }

        private void memberMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
