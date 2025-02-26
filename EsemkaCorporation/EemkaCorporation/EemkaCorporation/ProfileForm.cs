using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EemkaCorporation
{
    public partial class ProfileForm : Form
    {
        private employee employer;
        public ProfileForm(int user_id)
        {
            InitializeComponent();

            Init(user_id);
        }

        private void Init(int user_id)
        {
            using (EsemkaCorporationEntities emply = new EsemkaCorporationEntities())
            {
                employer = emply.employee.FirstOrDefault(x=>x.id == user_id);

                NameBox.Text = employer.name;
                EmailBox.Text = employer.email;
                PhoneNumberBox.Text = employer.phone_number;
                HireDateBox.Text = employer.hire_date.ToString();

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

                PositionBox.Text = string.Join(",", positions.Select(x=>x.positionName));
                JobLevelBox.Text = string.Join(",", positions.Select(x=>x.jobLevelName));
                DepatmentBox.Text = string.Join(",", positions.Select(x=>x.departmentName));

                var jobHistory = (from p in emply.position
                                  join j in emply.job on p.job_id equals j.id
                                  join d in emply.department on j.department_id equals d.id
                                  orderby j.job_level_id descending
                                  select new
                                  {
                                      department = d.name,
                                      position = j.name
                                  }).ToList();

                dataGridView1.DataSource = jobHistory;


                var subordinate = (from p in emply.position
                                   join j in emply.job on p.job_id equals j.id
                                   join e in emply.employee on p.employee_id equals e.id
                                   where p.employee_id == user_id
                                   select new
                                   {
                                        Name = e.name,
                                        Position = j.name
                                    }).ToList();


                dataGridView2.DataSource = subordinate;

                var supervisor = positions.Select(x => x.supervisor).First();


                var workwith = (from j in emply.job
                                join p in emply.position on j.id equals p.job_id
                                join e in emply.employee on p.employee_id equals e.id
                                where j.supervisor_job_id == supervisor
                                select new
                                {
                                    Name = e.name,
                                    Position = j.name
                                }).ToList();

                dataGridView3.DataSource = workwith;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm(employer.id);
            frm.Show();
            this.Hide();
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DepatmentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DirectSupervisor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (EsemkaCorporationEntities db = new EsemkaCorporationEntities())
            {
                ProfileForm profileForm = new ProfileForm(db.job.FirstOrDefault(y => y.id == db.position.FirstOrDefault(x => x.employee_id == employer.id).job_id).supervisor_job_id.Value);
                profileForm.Show();
                this.Hide();
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
