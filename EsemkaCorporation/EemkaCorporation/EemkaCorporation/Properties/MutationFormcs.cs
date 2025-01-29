using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EemkaCorporation.Properties
{
    public partial class MutationFormcs : Form
    {
        employee employer;
        public MutationFormcs(int user_id)
        {
            InitializeComponent();

            Init(user_id);
        }

        private void Init(int user_id)
        {
            using (EsemkaCorporationEntities emply = new EsemkaCorporationEntities())
            {
                employer = emply.employee.FirstOrDefault(x => x.id == user_id);

                nameBox.Text = employer.name;

                var positions = (from p in emply.position
                                 join j in emply.job on p.job_id equals j.id
                                 join d in emply.department on j.department_id equals d.id
                                 join jl in emply.job_level on j.job_level_id equals jl.id
                                 where p.employee_id == user_id
                                 select new
                                 {
                                     positionName = j.name,
                                     jobLevelName = jl.name,
                                     departmentName = d.name,
                                     supervisor = j.supervisor_job_id
                                 }).ToList();

                positionBox.Text = string.Join(",", positions.Select(x => x.positionName));
                jobBox.Text = string.Join(",", positions.Select(x => x.jobLevelName));
                departmentBox.Text = string.Join(",", positions.Select(x => x.departmentName));
                var jb_name = positions.Select(x => x.jobLevelName).First();

                var availableJob = (from p in emply.position
                                    join j in emply.job on p.job_id equals j.id
                                    join jl in emply.job_level on j.job_level_id equals jl.id
                                    join d in emply.department on j.department_id equals d.id
                                    where j.name == jb_name && jl.name == jb_name
                                    select new
                                    {
                                        department = d.name,
                                        position = j.name
                                    }).ToList();

                dataGridView1.DataSource = availableJob;

                DataGridViewButtonColumn applybtn = new DataGridViewButtonColumn();
                applybtn.Name = "apply";
                applybtn.HeaderText = "Action";
                applybtn.Text = "Apply";
                applybtn.UseColumnTextForButtonValue = true;

                dataGridView1.Columns.Add(applybtn);

            }
        }

        private void MutationFormcs_Load(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(employer.id);
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "apply")
            {
                dataGridView1.Rows[e.RowIndex].Cells["apply"] = new DataGridViewTextBoxCell { Value = "Pending" };
            }
        }
    }
}
