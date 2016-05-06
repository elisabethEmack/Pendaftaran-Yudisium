using Newtonsoft.Json;
using Pendaftar_Yudisium.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendaftar_Yudisium
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var stream = File.Open("data", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<PendaftarYudisium>>(jsonString);
            var dataTable = ToDataTable(list);
            dataGridView1.DataSource = dataTable;
            
        }
        private static DataTable ToDataTable(List<PendaftarYudisium> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(PendaftarYudisium));
            DataTable table = new DataTable();
            //for (int i = 0; i < props.Count; i++)
            //{
            //    PropertyDescriptor prop = props[i];
            //    table.Columns.Add(prop.Name, prop.PropertyType);
            //}
            table.Columns.Add("NIM", typeof(string));
            table.Columns.Add("Nama", typeof(string));
            table.Columns.Add("Tanggal Daftar", typeof(string));
            table.Columns.Add("Periode Yudisium", typeof(string));
            table.Columns.Add("No HP", typeof(string));
            table.Columns.Add("Daftar Nilai", typeof(bool));
            table.Columns.Add("Naskah TA", typeof(bool));
            table.Columns.Add("Bebas Pinjaman Lab", typeof(bool));
            table.Columns.Add("Bebas Pinjaman Dosen", typeof(bool));
            table.Columns.Add("Bukti Laporan KP", typeof(bool));
            table.Columns.Add("Surat Keterangan KI/KKL", typeof(bool));
            object[] values = new object[11];
            foreach (PendaftarYudisium item in data)
            {

                table.Rows.Add(item.NIM,
                    item.Name,
                    item.TanggalDaftar.ToString("d MMM yyyy"),
                    item.PeriodeYudisium.ToString("MMMM yyyy"),
                    item.NoHp,
                    item.DaftarNilai,
                    item.NaskahTA,
                    item.BebasPinjamLab,
                    item.BebasPinjamDosen,
                    item.LaporanKP,
                    item.SuratKeteranganKKL_KI);
            }
            return table;
        }
    }
}
