using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyBienLaiTienDien
{
    class KhachHang
    {
        public string HoTenChuHo { get; set; }
        public string SoNha { get; set; }
        public string MaCongToDien { get; set; }

        public KhachHang(string tenChuHo, string soNha, string maCongToDien)
        {
            HoTenChuHo = tenChuHo;
            SoNha = soNha;
            MaCongToDien = maCongToDien;
        }

        public void CapNhatThongTin(string tenChuHo, string soNha, string maCongToDien)
        {
            HoTenChuHo = tenChuHo;
            SoNha = soNha;
            MaCongToDien = maCongToDien;
        }

        public void XoaThongTin()
        {
            HoTenChuHo = null;
            SoNha = null;
            MaCongToDien = null;
        }
    }

    class BienLai
    {
        public KhachHang KhachHang { get; set; }
        public int ChiSoDienCu { get; set; }
        public int ChiSoDienMoi { get; set; }
        public int TienPhaiTra { get; set; }

        public BienLai(KhachHang khachHang, int chiSoDienCu, int chiSoDienMoi)
        {
            KhachHang = khachHang;
            ChiSoDienCu = chiSoDienCu;
            ChiSoDienMoi = chiSoDienMoi;
            TienPhaiTra = TinhTienDien();
        }

        private int TinhTienDien()
        {
            return (ChiSoDienMoi - ChiSoDienCu) * 5;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<BienLai> danhSachBienLai = new List<BienLai>();

            KhachHang khachHang1 = new KhachHang("Nguyễn Văn A", "12A", "CT001");
            BienLai bienLai1 = new BienLai(khachHang1, 1000, 1200);

            KhachHang khachHang2 = new KhachHang("Trần Thị B", "20B", "CT002");
            BienLai bienLai2 = new BienLai(khachHang2, 2000, 2500);

            danhSachBienLai.Add(bienLai1);
            danhSachBienLai.Add(bienLai2);

            foreach (var bienLai in danhSachBienLai)
            {
                Console.WriteLine($"Mã công tơ: {bienLai.KhachHang.MaCongToDien}");
                Console.WriteLine($"Họ tên chủ hộ: {bienLai.KhachHang.HoTenChuHo}");
                Console.WriteLine($"Số nhà: {bienLai.KhachHang.SoNha}");
                Console.WriteLine($"Chỉ số điện cũ: {bienLai.ChiSoDienCu}");
                Console.WriteLine($"Chỉ số điện mới: {bienLai.ChiSoDienMoi}");
                Console.WriteLine($"Số tiền phải trả: {bienLai.TienPhaiTra}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
