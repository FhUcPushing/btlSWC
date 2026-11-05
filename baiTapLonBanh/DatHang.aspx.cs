using baiTapLonBanh;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class DatHang : SweetCakePage
    {
       
        private const decimal PhiShipMacDinh = 30000m;   
        private const decimal MienPhiShipTu = 500000m;   

      
        public class DongGioHang
        {
            public string maBanh { get; set; }
            public string tenBanh { get; set; }
            public string anhBanh { get; set; }
            public decimal giaBanh { get; set; }
            public int soLuong { get; set; }
            public decimal thanhTien { get; set; }
        }

        private class TienDonHang
        {
            public decimal TamTinh;
            public decimal PhiShip;
            public decimal GiamGia;
            public decimal TongCong;
        }

       
        private string MaDangDung
        {
            get { return ViewState["MaGiamGia"] as string ?? ""; }
            set { ViewState["MaGiamGia"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] as NguoiDung == null)
            {
                Response.Redirect("DangNhap.aspx");
                return;
            }
            
            ngayNhan.Attributes["min"] = DateTime.Today.ToString("yyyy-MM-dd");

            if (!IsPostBack)
            {
                
                string maBanh = Request.QueryString["maBanh"];

                if (!string.IsNullOrEmpty(maBanh))
                {
                   
                    List<SanPhamBanh> danhSachSanPham =
                        Application["DanhSachSanPham"] as List<SanPhamBanh>;

                    
                    SanPhamBanh banhDuocChon = null;

                    if (danhSachSanPham != null)
                    {
                        banhDuocChon = danhSachSanPham.Find(
                            p => p.maBanh == maBanh
                        );
                    }

                    if (banhDuocChon != null)
                    {
                       
                        Dictionary<string, int> gioHang =
                            Session["GioHang"] as Dictionary<string, int>;

                        if (gioHang == null)
                        {
                            gioHang = new Dictionary<string, int>();
                        }
                     
                        string khoa = GioHangKey.Tao(maBanh, GioHangKey.LaBanhKem(banhDuocChon) ? "16" : null);

                        if (gioHang.ContainsKey(khoa))
                        {
                            gioHang[khoa] += 1;
                        }
                        else
                        {
                            gioHang.Add(khoa, 1);
                        }

                        Session["GioHang"] = gioHang;
                    }
                
                    Response.Redirect("DatHang.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                if (LayGioHang().Count == 0)
                {
                    Response.Redirect("GioHang.aspx");
                    return;
                }

               
                HienThiTomTat();
            }
        }

       
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HienThiPhuongThucThanhToan();
        }

        private void HienThiPhuongThucThanhToan()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<label class='the-thanh-toan'>")
              .Append("<input type='radio' name='thanhToan' value='cod' ").Append(DaChon("cod")).Append(" />")
              .Append("<span class='tt-bieu-tuong'><i class='fa-solid fa-money-bill-wave'></i></span>")
              .Append("<span class='tt-noi-dung'><strong>Thanh toán khi nhận hàng (COD)</strong><small>Trả tiền mặt khi nhận bánh.</small></span></label>");

            sb.Append("<label class='the-thanh-toan'>")
              .Append("<input type='radio' name='thanhToan' value='chuyenkhoan' ").Append(DaChon("chuyenkhoan")).Append(" />")
              .Append("<span class='tt-bieu-tuong'><i class='fa-solid fa-building-columns'></i></span>")
              .Append("<span class='tt-noi-dung'><strong>Chuyển khoản ngân hàng</strong><small>Thông tin tài khoản sẽ được gửi sau khi xác nhận đơn.</small></span></label>");

            sb.Append("<label class='the-thanh-toan'>")
              .Append("<input type='radio' name='thanhToan' value='momo' ").Append(DaChon("momo")).Append(" />")
              .Append("<span class='tt-bieu-tuong'><i class='fa-solid fa-wallet'></i></span>")
              .Append("<span class='tt-noi-dung'><strong>Ví MoMo</strong><small>Thanh toán nhanh bằng ví điện tử.</small></span></label>");

            khuThanhToan.InnerHtml = sb.ToString();
        }

        protected string DaChon(string giaTri)
        {
            string dangChon = Request.Form["thanhToan"] ?? "cod";
            return dangChon == giaTri ? "checked=\"checked\"" : "";
        }

        // ---------- Lấy giỏ hàng ----------
        private List<DongGioHang> LayGioHang()
        {
            List<DongGioHang> ketQua = new List<DongGioHang>();

            List<SanPhamBanh> danhSachSanPham =
                Application["DanhSachSanPham"] as List<SanPhamBanh>;
            Dictionary<string, int> gioHang =
                Session["GioHang"] as Dictionary<string, int>;

            if (danhSachSanPham == null || gioHang == null)
            {
                return ketQua;
            }

            foreach (KeyValuePair<string, int> kv in gioHang)
            {
                string ma, size;
                GioHangKey.Tach(kv.Key, out ma, out size);

                SanPhamBanh b = null;

              
                foreach (SanPhamBanh sanPham in danhSachSanPham)
                {
                    if (sanPham.maBanh == ma)
                    {
                        b = sanPham;
                        break;
                    }
                }

                if (b == null)
                {
                    continue;
                }

                decimal donGia = GioHangKey.DonGia(b, size);

                ketQua.Add(new DongGioHang
                {
                    maBanh = kv.Key,
                    tenBanh = b.tenBanh + (size != null ? " (" + GioHangKey.TenSize(size) + ")" : ""),
                    anhBanh = b.anhBanh,
                    giaBanh = donGia,
                    soLuong = kv.Value,
                    thanhTien = donGia * kv.Value
                });
            }
            return ketQua;
        }

       
        private TienDonHang TinhTien(
    List<DongGioHang> dong, string maGiamGia)
        {
            TienDonHang t = new TienDonHang();

     
            decimal tamTinh = 0;

            foreach (DongGioHang sanPham in dong)
            {
                tamTinh += sanPham.thanhTien;
            }

            t.TamTinh = tamTinh;


            if (t.TamTinh >= MienPhiShipTu)
            {
                t.PhiShip = 0;
            }
            else
            {
                t.PhiShip = PhiShipMacDinh;
            }


            t.GiamGia = TinhGiamGia(
                maGiamGia, t.TamTinh, t.PhiShip);


            t.TongCong =
                t.TamTinh + t.PhiShip - t.GiamGia;

            if (t.TongCong < 0)
            {
                t.TongCong = 0;
            }

            return t;
        }

        private decimal TinhGiamGia(string ma, decimal tamTinh, decimal phiShip)
        {
            switch (ma)
            {
                case "SWEET10": return Math.Round(tamTinh * 0.10m, 0);
                case "FREESHIP": return phiShip;
                case "CHAO20K": return Math.Min(20000m, tamTinh);
                default: return 0m;
            }
        }


        private string MoTaMa(string ma)
        {
            switch (ma)
            {
                case "SWEET10": return "giảm 10% tiền bánh";
                case "FREESHIP": return "miễn phí vận chuyển";
                case "CHAO20K": return "giảm 20,000đ";
                default: return null;
            }
        }

        private static string Tien(decimal so)
        {
            return so.ToString("N0") + "đ";
        }


        private string TenKhungGio(string giaTri)
        {
            switch (giaTri)
            {
                case "8": return "08:00 - 10:00";
                case "10": return "10:00 - 12:00";
                case "12": return "12:00 - 14:00";
                case "14": return "14:00 - 16:00";
                case "16": return "16:00 - 18:00";
                case "18": return "18:00 - 20:00";
                default: return "";
            }
        }

        private void HienThiTomTat()
        {
            List<DongGioHang> dong = LayGioHang();
            TienDonHang t = TinhTien(dong, MaDangDung);

            rptTomTat.InnerHtml = HtmlRender.OrderSummaryRows(dong);

            litTamTinh.InnerHtml = Tien(t.TamTinh);
            litPhiShip.InnerHtml = t.PhiShip == 0m ? "Miễn phí" : Tien(t.PhiShip);
            litGiamGia.InnerHtml = t.GiamGia > 0m ? "-" + Tien(t.GiamGia) : "0đ";
            litTongCong.InnerHtml = Tien(t.TongCong);

            if (t.PhiShip == 0m)
            {
                ghiChuShip.InnerText = "Đơn của bạn được miễn phí vận chuyển.";
            }
            else
            {
                ghiChuShip.InnerText = string.Format(
                    "Mua thêm {0} để được miễn phí vận chuyển.",
                    Tien(MienPhiShipTu - t.TamTinh));
            }
        }


        protected void btnApDungMa_Click(object sender, EventArgs e)
        {
            string ma = txtMaGiamGia.Value.Trim().ToUpperInvariant();
            txtMaGiamGia.Value = ma;

            if (ma.Length == 0)
            {
                MaDangDung = "";
                thongBaoMa.Visible = false;
            }
            else if (MoTaMa(ma) != null)
            {
                MaDangDung = ma;
                thongBaoMa.InnerHtml = "<i class=\"fa-solid fa-circle-check\"></i> Đã áp dụng mã "
                    + HttpUtility.HtmlEncode(ma) + ": " + MoTaMa(ma) + ".";
                thongBaoMa.Attributes["class"] = "thong-bao-ma thanh-cong";
                thongBaoMa.Visible = true;
            }
            else
            {
                MaDangDung = "";
                thongBaoMa.InnerHtml = "<i class=\"fa-solid fa-circle-exclamation\"></i> Mã giảm giá không hợp lệ.";
                thongBaoMa.Attributes["class"] = "thong-bao-ma loi";
                thongBaoMa.Visible = true;
            }

            HienThiTomTat();
        }


        protected void btnXacNhanDatHang_Click(object sender, EventArgs e)
        {
            List<DongGioHang> dong = LayGioHang();
            if (dong.Count == 0)
            {
                Response.Redirect("GioHang.aspx");
                return;
            }

            List<string> loi = new List<string>();

     
            string hoTen = txtHoTen.Value.Trim();
            string sdt = Regex.Replace(txtSoDienThoai.Value.Trim(), @"[\s\.\-]", "");
            string email = txtEmail.Value.Trim();
            string diaChi = txtDiaChi.Value.Trim();
            string ghiChu = txtGhiChu.Value.Trim();

            if (hoTen.Length < 2)
            {
                loi.Add("Vui lòng nhập họ và tên người nhận.");
            }
            if (!Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                loi.Add("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.");
            }
            if (email.Length > 0 && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                loi.Add("Email chưa đúng định dạng.");
            }
            if (diaChi.Length < 8)
            {
                loi.Add("Vui lòng nhập địa chỉ nhận hàng đầy đủ.");
            }

      
            DateTime ngay;
            bool coNgay = DateTime.TryParseExact(ngayNhan.Value, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay);

            if (!coNgay)
            {
                loi.Add("Vui lòng chọn ngày nhận hàng.");
            }
            else if (ngay.Date < DateTime.Today)
            {
                loi.Add("Ngày nhận hàng không được ở trong quá khứ.");
            }

            int gioBatDau;
            if (!int.TryParse(ddlGio.Value, out gioBatDau))
            {
                loi.Add("Vui lòng chọn khung giờ nhận hàng.");
            }
            else if (coNgay && ngay.Date == DateTime.Today && gioBatDau <= DateTime.Now.Hour)
            {
                loi.Add("Khung giờ nhận hàng đã qua, vui lòng chọn khung giờ khác.");
            }


            string maThanhToan = Request.Form["thanhToan"] ?? "cod";
            string tenThanhToan;
            switch (maThanhToan)
            {
                case "cod": tenThanhToan = "Thanh toán khi nhận hàng (COD)"; break;
                case "chuyenkhoan": tenThanhToan = "Chuyển khoản ngân hàng"; break;
                case "momo": tenThanhToan = "Ví MoMo"; break;
                default:
                    tenThanhToan = "";
                    loi.Add("Vui lòng chọn phương thức thanh toán.");
                    break;
            }

         
            if (loi.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<strong><i class=\"fa-solid fa-circle-exclamation\"></i> Vui lòng kiểm tra lại:</strong><ul>");
                foreach (string s in loi)
                {
                    sb.Append("<li>").Append(HttpUtility.HtmlEncode(s)).Append("</li>");
                }
                sb.Append("</ul>");

                khungLoi.InnerHtml = sb.ToString();
                khungLoi.Visible = true;
                HienThiTomTat();
                return;
            }

            TienDonHang t = TinhTien(dong, MaDangDung);
            string maDon = "DH"
    + DateTime.Now.ToString("yyyyMMddHHmmss")
    + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpperInvariant();

            litMaDon.InnerHtml = maDon;
            litNguoiNhan.InnerHtml = HttpUtility.HtmlEncode(hoTen) + " - " + HttpUtility.HtmlEncode(sdt);
            litDiaChi.InnerHtml = HttpUtility.HtmlEncode(diaChi);
            litThoiGian.InnerHtml = ngay.ToString("dd/MM/yyyy") + ", " + TenKhungGio(ddlGio.Value);
            litThanhToan.InnerHtml = tenThanhToan;
            litTongThanhToan.InnerHtml = Tien(t.TongCong);
           
            List<ChiTietDon> dsChiTiet = new List<ChiTietDon>();

            foreach (DongGioHang sanPham in dong)
            {
                ChiTietDon chiTiet = new ChiTietDon();

                chiTiet.maBanh = sanPham.maBanh;
                chiTiet.tenBanh = sanPham.tenBanh;
                chiTiet.anhBanh = sanPham.anhBanh;
                chiTiet.donGia = sanPham.giaBanh;
                chiTiet.soLuong = sanPham.soLuong;
                chiTiet.thanhTien = sanPham.thanhTien;

                dsChiTiet.Add(chiTiet);
            }
            DonHang don = new DonHang
            {
                MaDon = maDon,
                TenDangNhap = ((NguoiDung)Session["TaiKhoan"]).TenDangNhap,
                NgayDat = DateTime.Now,
                NguoiNhan = hoTen,
                SoDienThoai = sdt,
                DiaChi = diaChi,
                ThoiGianNhan = ngay.ToString("dd/MM/yyyy") + ", " + TenKhungGio(ddlGio.Value),
                ThanhToan = tenThanhToan,
                GhiChu = ghiChu,
                TamTinh = t.TamTinh,
                PhiShip = t.PhiShip,
                GiamGia = t.GiamGia,
                TongCong = t.TongCong,
                TrangThai = "Chờ xác nhận",
                Dong = dsChiTiet
            };

            Application.Lock();

            try
            {
                List<DonHang> dsDon =
                    Application["DanhSachDonHang"] as List<DonHang>;

                if (dsDon == null)
                {
                    dsDon = new List<DonHang>();
                    Application["DanhSachDonHang"] = dsDon;
                }

                dsDon.Add(don);
            }
            finally
            {
                Application.UnLock();
            }
        
            Session["DonHangGanNhat"] = maDon;

            
            Session.Remove("GioHang");
            Session.Remove("TuyChonBanh");
            pnlDatHang.Visible = false;
            pnlThanhCong.Visible = true;
        }
    }
}