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
    public partial class DentailForm : Form
    {
        string m;
        QL q = new QL();
        public delegate void Mydel();
         public Mydel d;
        public DentailForm(string mabaibao)
        {
            InitializeComponent();
            m = mabaibao;
            GUI();
        }
        private void GUI()
        {
            if(m!="")
            {
                BaiBao b = q.GetBaiBao(m);
                textBox_mabaibao.Text = b.Ma_Bai_Bao;
                textBox_tenbaibao.Text = b.Ten_Bai_Bao;
                textBox_tentacgia.Text = b.Ten_Tac_Gia;
                foreach(string i in q.GetListLoai_Tap_Chi().Distinct())
                {
                    comboBox_loaitapchi.Items.Add(i);
                }
                comboBox_loaitapchi.SelectedItem = b.Loai_Tap_Chi;
                foreach (string i in q.GetListTen_Tap_Chi().Distinct())
                {
                    comboBox_tentapchi.Items.Add(i);
                }
                comboBox_tentapchi.SelectedItem = b.Ten_Tap_Chi;
                foreach (string i in q.GetListNam_Xuat_Ban().Distinct())
                {
                    comboBox_namxuatban.Items.Add(i);
                }
                comboBox_namxuatban.SelectedItem = b.Nam_Xuat_Ban;
                foreach (string i in q.GetListNha_Xuat_Ban().Distinct())
                {
                    comboBox_nhaxuatban.Items.Add(i);
                }
                comboBox_nhaxuatban.SelectedItem = b.Nha_Xuat_Ban;

            }
            else
            {
                   foreach(string i in q.GetListLoai_Tap_Chi().Distinct())
                {
                    comboBox_loaitapchi.Items.Add(i);
                }
                comboBox_loaitapchi.SelectedIndex = 0;
                foreach (string i in q.GetListTen_Tap_Chi().Distinct())
                {
                    comboBox_tentapchi.Items.Add(i);
                }
                comboBox_tentapchi.SelectedIndex = 0;
                foreach (string i in q.GetListNam_Xuat_Ban().Distinct())
                {
                    comboBox_namxuatban.Items.Add(i);
                }
                comboBox_namxuatban.SelectedIndex = 0;
                foreach (string i in q.GetListNha_Xuat_Ban().Distinct())
                {
                    comboBox_nhaxuatban.Items.Add(i);
                }
                comboBox_nhaxuatban.SelectedIndex = 0;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            BaiBao b = new BaiBao
            {
                Ma_Bai_Bao = textBox_mabaibao.Text,
                Ten_Bai_Bao = textBox_tenbaibao.Text,
                Ten_Tac_Gia = textBox_tentacgia.Text,
                Loai_Tap_Chi = comboBox_loaitapchi.SelectedItem.ToString(),
                Nam_Xuat_Ban= comboBox_namxuatban.SelectedItem.ToString(),
                Ten_Tap_Chi = comboBox_tentapchi.SelectedItem.ToString(),
                Nha_Xuat_Ban = comboBox_nhaxuatban.SelectedItem.ToString()
            };
            q.UpdateAdd(b);
            d();
            this.Dispose();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
