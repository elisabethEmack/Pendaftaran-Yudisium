using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendaftar_Yudisium.Model
{
    class PendaftarYudisium
    {
        public string Name { set; get; }
        public string NIM { set; get; }
        public string NoHp { set; get; }
        public DateTime PeriodeYudisium { set; get; }
        public DateTime TanggalDaftar { set; get; }
        public bool DaftarNilai { set; get; }
        public bool NaskahTA { set; get; }
        public bool BebasPinjamLab { set; get; }
        public bool BebasPinjamDosen { set; get; }
        public bool LaporanKP { set; get; }
        public bool SuratKeteranganKKL_KI { set; get; }
        public override string ToString()
        {
            return Name + " :" + PeriodeYudisium + "\n";
        }
    }
}

