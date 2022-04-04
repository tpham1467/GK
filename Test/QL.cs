using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test
{
    class QL
    {
        List<BaiBao> _Search = new List<BaiBao>();
        public List<BaiBao> GetAll()
        {
            List<BaiBao> data = new List<BaiBao>();
            foreach(DataRow i in Data.Instance.data.Rows)
            {
                data.Add(Convert_BaiBao(i));
            }
            return data;
        }
        public BaiBao Convert_BaiBao(DataRow r)
        {
            return new BaiBao
            {
                Ma_Bai_Bao = r["Ma_Bai_Bao"].ToString(),
                Ten_Bai_Bao = r["Ten_Bai_Bao"].ToString(),
                Ten_Tac_Gia = r["Ten_Tac_Gia"].ToString(),
                Ten_Tap_Chi = r["Ten_Tap_Chi"].ToString(),
                Loai_Tap_Chi = r["Loai_Tap_Chi"].ToString(),
                Nam_Xuat_Ban = r["Nam_Xuat_Ban"].ToString(),
                Nha_Xuat_Ban = r["Nha_Xuat_Ban"].ToString()

            };
        }
        public List<String> GetListLoai_Tap_Chi()
        {
            List<string> data = new List<string>();
            foreach(BaiBao i in GetAll())
            {
                data.Add(i.Loai_Tap_Chi);
            }
            return data;
        }
        public List<String> GetListNam_Xuat_Ban()
        {
            List<string> data = new List<string>();
            foreach (BaiBao i in GetAll())
            {
                data.Add(i.Nam_Xuat_Ban);
            }
            return data;
        }
        public List<String> GetListNha_Xuat_Ban()
        {
            List<string> data = new List<string>();
            foreach (BaiBao i in GetAll())
            {
                data.Add(i.Nha_Xuat_Ban);
            }
            return data;
        }
        public List<String> GetListTen_Tap_Chi()
        {
            List<string> data = new List<string>();
            foreach (BaiBao i in GetAll())
            {
                data.Add(i.Ten_Tap_Chi);
            }
            return data;
        }
        public BaiBao GetBaiBao(string mabaibao)
        {
            foreach(BaiBao i in GetAll())
            {
                if (i.Ma_Bai_Bao == mabaibao) return i;
            }
            return null;
        }
        public void UpdateAdd(BaiBao b)
        {
            bool add=true;
            foreach(BaiBao i in GetAll())
            {
                if(i.Ma_Bai_Bao==b.Ma_Bai_Bao)
                {
                    add = false;
                    break;
                }

            }
            if (add == true)
            {
                Data.Instance.Add(b);
            }
            else Data.Instance.UpDate(b);

        }
       

        public List<BaiBao> Search(string txtsearch, string loaitapchi, string nam_xuat_ban, string nhaxb)
        {
            _Search = GetAll();
            if(loaitapchi!=null&& loaitapchi!="All")
            {
                for (int i=0;i< _Search.Count;i++ )
                {
                    if (_Search[i].Loai_Tap_Chi == loaitapchi)
                    {
                        _Search.Remove(_Search[i]);
                    }
                }
            }
            if(nam_xuat_ban!=null&& nam_xuat_ban!="All")
            {
                for (int i = 0; i < _Search.Count; i++)
                {
                    if (_Search[i].Nam_Xuat_Ban == nam_xuat_ban)
                    {
                        _Search.Remove(_Search[i]);
                    }
                }
            }
            if(nhaxb!= null&& nhaxb!="All")
            {
                for (int i = 0; i < _Search.Count; i++)
                {
                    if (_Search[i].Nha_Xuat_Ban == nhaxb)
                    {
                        _Search.Remove(_Search[i]);
                    }
                }
            }
            if (txtsearch != null)
            {
                for (int i = 0; i < _Search.Count; i++)
                {
                    if (!(_Search[i].Ma_Bai_Bao == txtsearch || _Search[i].Ten_Bai_Bao.Contains(txtsearch) ||
                        _Search[i].Ten_Tac_Gia.Contains(txtsearch) || _Search[i].Ten_Tap_Chi.Contains(txtsearch)))
                    {
                        _Search.Remove(_Search[i]);
                    }

                }
            }
            return _Search;
        }
    }
    
}
