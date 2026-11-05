using System;
using System.Collections.Generic;

namespace baiTapLonBanh
{
    public class ChiTietDon
    {
        public string maBanh { get; set; }
        public string tenBanh { get; set; }   
        public string anhBanh { get; set; }
        public decimal donGia { get; set; }
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
    }

    public class DonHang
    {
        public string MaDon { get; set; }
        public string TenDangNhap { get; set; }  
        public DateTime NgayDat { get; set; }
        public string NguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ThoiGianNhan { get; set; }
        public string ThanhToan { get; set; }
        public string GhiChu { get; set; }
        public decimal TamTinh { get; set; }
        public decimal PhiShip { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongCong { get; set; }
        public string TrangThai { get; set; }
        public List<ChiTietDon> Dong { get; set; }
    }
}