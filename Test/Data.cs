using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test
{
    class Data
    {
        private static Data _Instance;
        public DataTable data
        {
            get;
        }
        public static Data Instance
        {

            get
            {
                if (_Instance == null)
                {
                    _Instance = new Data();
                }
                return _Instance;
            }
        }
        private Data()
        {
            data = new DataTable();
            data.Columns.AddRange(new DataColumn[]
               {
                    new DataColumn { DataType =typeof(string) , ColumnName = "Ma_Bai_Bao"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Ten_Bai_Bao"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Ten_Tac_Gia"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Ten_Tap_Chi"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Loai_Tap_Chi"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Nam_Xuat_Ban"},
                new DataColumn { DataType =typeof(string) , ColumnName = "Nha_Xuat_Ban"}
 
               });
            data.Rows.Add(
                 "001", "Bao 1", "Van A", "Tap Chi 1", "Loai 1", "2002", "Nha 1"
                );
            data.Rows.Add(
                 "002", "Bao 2", "Van B", "Tap Chi 2", "Loai 2", "2003", "Nha 2"
                );
            data.Rows.Add(
                 "003", "Bao 1", "Van D", "Tap Chi 4", "Loai 10", "2004", "Nha 1"
                );
            data.Rows.Add(
                 "004", "Bao 1", "Van E", "Tap Chi 4", "Loai 3", "2005", "Nha 2"
                );
            data.Rows.Add(
                 "005", "Bao 1", "Van C", "Tap Chi 5", "Loai 7", "2006", "Nha 1"
                );


        }
        public void Del(BaiBao b)
        {
            foreach (DataRow i in data.Rows)
            {
                if (i["Ma_Bai_Bao"].ToString() == b.Ma_Bai_Bao)
                {
                    data.Rows.Remove(i);
                    break;
                }
            }   
        }
        public void Add(BaiBao b)
        {
            data.Rows.Add(
                b.Ma_Bai_Bao, b.Ten_Bai_Bao, b.Ten_Tac_Gia, b.Ten_Tap_Chi, b.Loai_Tap_Chi, b.Nam_Xuat_Ban,
                 b.Nha_Xuat_Ban
               );
        }
        public void UpDate(BaiBao b)
        {
            foreach (DataRow i in data.Rows)
            {
                if (i["Ma_Bai_Bao"].ToString() == b.Ma_Bai_Bao)
                {
                    i["Ma_Bai_Bao"] = b.Ma_Bai_Bao;
                    i["Ten_Bai_Bao"] = b.Ten_Bai_Bao;
                    i["Ten_Tac_Gia"] = b.Ten_Tac_Gia;
                    i["Ten_Tap_Chi"] = b.Ten_Tap_Chi;
                    i["Loai_Tap_Chi"] = b.Loai_Tap_Chi;
                    i["Nam_Xuat_Ban"] = b.Nam_Xuat_Ban;
                    i["Nha_Xuat_Ban"] = b.Nha_Xuat_Ban;
               
                }
            }
        }
    }
}
