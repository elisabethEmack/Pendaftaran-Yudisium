using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pendaftar_Yudisium.Model;
using System.IO;
using Newtonsoft.Json;

namespace Pendaftar_Yudisium
{
    public partial class Data_Pendaftar : Form
    {
        public Data_Pendaftar()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pendaftar = new PendaftarYudisium();
            pendaftar.Name = txtNama.Text;
            pendaftar.NIM = txtNIM.Text;
            pendaftar.NoHp = txtNoHp.Text;
            pendaftar.PeriodeYudisium = dtpPeriodeYudisium.Value;
            pendaftar.TanggalDaftar = dtpTanggalDaftar.Value;
            pendaftar.LaporanKP = chkLaporanKP.Checked;
            pendaftar.NaskahTA = chkNaskahTA.Checked;
            pendaftar.SuratKeteranganKKL_KI = chkSuratKI.Checked;
            pendaftar.BebasPinjamDosen = chkBebasDosen.Checked;
            pendaftar.BebasPinjamLab = chkBebasLab.Checked;
            pendaftar.DaftarNilai = chkDaftarNilai.Checked;
            var stream=File.Open("data", FileMode.OpenOrCreate,FileAccess.ReadWrite);
            var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<PendaftarYudisium>>(jsonString);
            Console.WriteLine(list);
            //var list = obj as List<PendaftarYudisium>;
            if (list == null) list = new List<PendaftarYudisium>();
            list.Add(pendaftar);
            reader.Close();
            stream.Close();
            stream = File.Open("data", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamWriter writer= new StreamWriter(stream)) {
                var json = JsonConvert.SerializeObject(list);
                writer.WriteLine(json);
            }
            stream.Close();
            //var writer = new StreamWriter(stream);
        }
    }
}
