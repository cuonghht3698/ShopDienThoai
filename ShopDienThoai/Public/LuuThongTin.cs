using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopQuanAo.Public
{
    public static class LuuThongTin
    {
        public static int id;
        public static string ten;
        public static string ngaysinh;
        public static string sdt;
        public static bool gioitinh;
        public static string diachi;
        public static string taikhoan;
        public static string matkhau;
        public static int roleId;
        public static string role;
    }
    public static class TrangThai
    {
        public static string TaoPhieu = "Đang giao dịch";
        public static string ChoDuyet = "Chờ duyệt";
        public static string DaDuyet = "Đã duyệt";
        public static string GiaoHang = "Giao Hàng";
        public static string HoanThanh = "Hoàn thành";
        public static string DaHuy = "Hủy";
    }

    public static class LoaiPhieu
    {
        public static string NhapKho = "Nhập kho";
        public static string XuatKho = "Xuất kho";
    }

    public static class Role
    {
        public static string admin = "Admin";
        public static string nhanvien = "Nhân viên";
        public static string quanlykho = "Quản lý kho";
        public static string khachhang = "Khách hàng";

    }
}
