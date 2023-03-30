using System;
using System.Collections.Generic;

namespace TuyenSinhDaiHoc
{
    // Lớp để quản lý thông tin của mỗi thí sinh
    class ThiSinh
    {
        public string soBaoDanh;
        public string hoTen;
        public string diaChi;
        public int mucUuTien;
        public string khoiThi;
    }

    // Lớp để quản lý tất cả các thí sinh dự thi
    class QuanLyThiSinh
    {
        public List<ThiSinh> danhSachThiSinh;

        public QuanLyThiSinh()
        {
            danhSachThiSinh = new List<ThiSinh>();
        }

        // Hàm để thêm một thí sinh mới vào danh sách
        public void ThemThiSinh(ThiSinh ts)
        {
            danhSachThiSinh.Add(ts);
        }

        // Hàm để tìm kiếm một thí sinh bằng số báo danh
        public ThiSinh TimKiemThiSinh(string sbd)
        {
            foreach (ThiSinh ts in danhSachThiSinh)
            {
                if (ts.soBaoDanh == sbd)
                {
                    return ts;
                }
            }
            return null;
        }
    }

    // Lớp chứa hàm main để thực hiện các chức năng của chương trình
    class TuyenSinh
    {
        static void Main(string[] args)
        {
            QuanLyThiSinh qlts = new QuanLyThiSinh();

            while (true)
            {
                Console.WriteLine("Vui lòng chọn chức năng:");
                Console.WriteLine("1. Thêm mới thí sinh");
                Console.WriteLine("2. Hiển thị thông tin thí sinh và khối thi");
                Console.WriteLine("3. Tìm kiếm thí sinh theo số báo danh");
                Console.WriteLine("4. Thoát chương trình");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Vui lòng nhập thông tin thí sinh:");

                        ThiSinh ts = new ThiSinh();

                        Console.Write("Số báo danh: ");
                        ts.soBaoDanh = Console.ReadLine();

                        Console.Write("Họ tên: ");
                        ts.hoTen = Console.ReadLine();

                        Console.Write("Địa chỉ: ");
                        ts.diaChi = Console.ReadLine();

                        Console.Write("Mức ưu tiên: ");
                        ts.mucUuTien = int.Parse(Console.ReadLine());

                        Console.Write("Khối thi (A/B/C): ");
                        ts.khoiThi = Console.ReadLine();

                        qlts.ThemThiSinh(ts);

                        Console.WriteLine("Thêm mới thí sinh thành công!");
                        break;

                    case 2:
                        Console.WriteLine("Danh sách thí sinh và khối thi:");

                        foreach (ThiSinh t in qlts.danhSachThiSinh)
                        {
                            Console.WriteLine("Số báo danh: " + t.soBaoDanh);
                            Console.WriteLine("Họ tên: " + t.hoTen);
                            Console.WriteLine("Địa chỉ: " + t.diaChi);
                            Console.WriteLine("Mức ưu tiên: " + t.mucUuTien);
                            Console.WriteLine("Khối thi: " + t.khoiThi);
                            Console.WriteLine();
                            }
                            break;
                    case 3:
                        Console.Write("Vui lòng nhập số báo danh: ");
                        string sbd = Console.ReadLine();

                        ThiSinh tskq = qlts.TimKiemThiSinh(sbd);

                        if (tskq != null)
                        {
                            Console.WriteLine("Thông tin thí sinh:");
                            Console.WriteLine("Số báo danh: " + tskq.soBaoDanh);
                            Console.WriteLine("Họ tên: " + tskq.hoTen);
                            Console.WriteLine("Địa chỉ: " + tskq.diaChi);
                            Console.WriteLine("Mức ưu tiên: " + tskq.mucUuTien);
                            Console.WriteLine("Khối thi: " + tskq.khoiThi);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy thí sinh có số báo danh " + sbd);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        return;

                    default:
                        Console.WriteLine("Vui lòng chọn chức năng đúng!");
                        break;
                }
            }
        }
    }
}
