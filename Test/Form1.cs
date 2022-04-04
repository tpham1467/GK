using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
       
        QL q = new QL();
        public Form1()
        {
            InitializeComponent();
            comboBox_loaitapchi.Items.Add("All");
            foreach (string i in q.GetListLoai_Tap_Chi().Distinct())
            {
                comboBox_loaitapchi.Items.Add(i);
            }
            comboBox_loaitapchi.SelectedIndex = 0;
            comboBox_Namxuatban.Items.Add("All");
            foreach (string i in q.GetListNam_Xuat_Ban().Distinct())
            {
                comboBox_Namxuatban.Items.Add(i);
            }
            comboBox_Namxuatban.SelectedIndex = 0;
            comboBox_nhaxuatban.Items.Add("All");
            foreach (string i in q.GetListNha_Xuat_Ban().Distinct())
            {
                comboBox_nhaxuatban.Items.Add(i);
            }
            comboBox_nhaxuatban.SelectedIndex = 0;
            Load_Column();
            Load_Rows(q.GetAll());
        }
        private void Load_Column()
        {
            dataGridView1.Columns.Add("stt", "STT");
            dataGridView1.Columns.Add("Ma_Bai_Bao", "Ma Bai Bao");
            dataGridView1.Columns.Add("Ten_Bai_Bao", "Ten Bai Bao");
            dataGridView1.Columns.Add("Ten_Tac_Gia", "Ten Tac Gia");
            dataGridView1.Columns.Add("Ten_Tap_Chi", "Ten Tap Chi");

            List<BaiBao> bb = q.GetAll();
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "Loai Tap Chi";
            dgvCmb.Name = "Loai_Tap_Chi";
            foreach (string i in q.GetListLoai_Tap_Chi())
            {
                dgvCmb.Items.Add(i);
            }
            dataGridView1.Columns.Add(dgvCmb);
            dgvCmb.ReadOnly = true;
            dataGridView1.Columns.Add("Nam_Xuat_Ban", "Nam Xuat Ban");
            dataGridView1.Columns.Add("Nha_Xuat_Ban", "Nha Xuat Ban");
        }
        private void Load_Rows(List<BaiBao> b)
        {
            int j = 0;
            foreach(BaiBao i in b)
            {
                dataGridView1.Rows.Add(j, i.Ma_Bai_Bao, i.Ten_Bai_Bao, i.Ten_Tac_Gia, i.Ten_Tap_Chi, i.Loai_Tap_Chi, i.Nam_Xuat_Ban,
                    i.Nha_Xuat_Ban);
                    j++;
            }
           
        }
        public void Reload()
        {
            dataGridView1.Rows.Clear();
            Load_Rows(q.GetAll());
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            DentailForm detail = new DentailForm("");
            detail.d = new DentailForm.Mydel(Reload);
            detail.Show();
           


        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==1)
            {
                string s = dataGridView1.SelectedRows[0].Cells["Ma_Bai_Bao"].Value.ToString();
                DentailForm detail = new DentailForm(s);
                detail.d  = new DentailForm.Mydel(Reload);
                detail.Show();
             

            }
        }
        
        private void button_Search_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<BaiBao> b = q.Search( textBoxSerach.Text , comboBox_loaitapchi.SelectedItem.ToString(),
                comboBox_Namxuatban.SelectedItem.ToString(),comboBox_nhaxuatban.SelectedItem.ToString());
            Load_Rows(b);
        }
    }
}
