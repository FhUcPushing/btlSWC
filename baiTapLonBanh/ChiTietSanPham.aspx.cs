using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace baiTapLonBanh
{
    
    public class SizeBanh
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string SoNguoi { get; set; }
        public long Gia { get; set; }
        public bool DaChon { get; set; }
    }

    public partial class ChiTietSanPham : SweetCakePage
    {
        private static readonly CultureInfo ViVN = new CultureInfo("vi-VN");

        private const int SoLuongToiDa = 99;

        
        private static readonly string[] MaSize = { "16", "20", "24" };
        private static readonly string[] TenSize = { "16cm", "20cm", "24cm" };
        private static readonly string[] SoNguoiSize = { "3–4 người", "6–8 người", "10–12 người" };
        private static readonly decimal[] HeSoGia = { 1m, 1.5m, 2m };

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && !string.IsNullOrEmpty(Request.Form["goiYAction"]))
            {
                XuLyGoiYPost();
            }

            List<SanPhamBanh> danhSachSanPham = LayDanhSach();
            SanPhamBanh banh = TimBanh(Request.QueryString["id"]);

            if (banh == null)
            {
                thongTinBanh.Visible = false;
                thongBaoLoi.Visible = true;
                khuVucGoiY.Visible = false;
                return;
            }

            thongTinBanh.Visible = true;
            thongBaoLoi.Visible = false;

            loaiBanh.InnerText = banh.loaiBanh;
            tenBanh.InnerText = banh.tenBanh;
            
            moTa.InnerText = string.IsNullOrWhiteSpace(banh.moTa)
                ? banh.tenBanh + " được SweetCake làm mới mỗi ngày từ nguyên liệu chọn lọc, giữ trọn hương vị thơm ngon và an toàn cho cả gia đình."
                : banh.moTa;
            thongTinChiTiet.InnerHtml = TaoThongTinChiTiet(banh);
            anhBanh.Src = ResolveUrl("~/" + banh.anhBanh);

            long giaHienTai = (long)banh.giaBanh;
            bool laBanhKem = LaBanhKem(banh);

            khuVucSize.Visible = laBanhKem;

            if (laBanhKem)
            {
                List<SizeBanh> dsSize = TaoDanhSachSize(banh, Request.Form["size"]);
                rptSize.InnerHtml = HtmlRender.SizeOptions(dsSize, DinhDangGia);
                giaHienTai = dsSize.First(s => s.DaChon).Gia;
            }

            giaBanh.InnerText = DinhDangGia(giaHienTai);
            
            giaBanh.Attributes["data-gia"] = ((long)banh.giaBanh).ToString(CultureInfo.InvariantCulture);

            
            List<SanPhamBanh> goiY = danhSachSanPham
                .Where(x => x.maBanh != banh.maBanh && x.loaiBanh == banh.loaiBanh)
                .Take(4).ToList();

            if (goiY.Count < 4)
            {
                goiY.AddRange(danhSachSanPham
                    .Where(x => x.maBanh != banh.maBanh && x.loaiBanh != banh.loaiBanh)
                    .Take(4 - goiY.Count));
            }

            rptDanhSachGoiY.InnerHtml = HtmlRender.SuggestedProducts(goiY, DinhDangGia);
            khuVucGoiY.Visible = goiY.Count > 0;
        }

       
        private List<SanPhamBanh> LayDanhSach()
        {
            List<SanPhamBanh> ds = Application["DanhSachSanPham"] as List<SanPhamBanh>;
            if (ds == null)
            {
                ds = new List<SanPhamBanh>();
            }
            return ds;
        }

        private SanPhamBanh TimBanh(string ma)
        {
            if (string.IsNullOrEmpty(ma))
            {
                return null;
            }
            return LayDanhSach().FirstOrDefault(x => x.maBanh == ma);
        }

        
        protected string DinhDangGia(object gia)
        {
            decimal so = Convert.ToDecimal(gia);
            return so.ToString("N0", ViVN) + "đ";
        }

     
        private static bool LaBanhKem(SanPhamBanh banh)
        {
            return banh.loaiBanh == "Bánh Mousse"
                || banh.loaiBanh == "Bánh Sinh Nhật"
                || banh.loaiBanh == "Bánh Kem";
        }

        private static List<SizeBanh> TaoDanhSachSize(SanPhamBanh banh, string maDaChon)
        {
            List<SizeBanh> ds = new List<SizeBanh>();
            bool coChon = MaSize.Contains(maDaChon);

            for (int i = 0; i < MaSize.Length; i++)
            {
                long gia = (long)(Math.Round(banh.giaBanh * HeSoGia[i] / 1000m, 0) * 1000m);

                ds.Add(new SizeBanh
                {
                    Ma = MaSize[i],
                    Ten = TenSize[i],
                    SoNguoi = SoNguoiSize[i],
                    Gia = gia,
                    DaChon = coChon ? MaSize[i] == maDaChon : i == 0
                });
            }
            return ds;
        }

     
        private static string TaoThongTinChiTiet(SanPhamBanh banh)
        {
            string thanhPhan, huongVi, baoQuan, phuHop;
            string diUng = "Có chứa gluten, trứng, sữa; có thể chứa dấu vết các loại hạt.";

            switch (banh.loaiBanh)
            {
                case "Bánh Mousse":
                    thanhPhan = "Cốt bánh bông lan mềm, lớp mousse làm từ kem tươi, sữa và hương vị chính của bánh, phủ lớp gương hoặc kem trang trí bên ngoài.";
                    huongVi = "Mịn, mát và tan nhẹ trong miệng; vị ngọt vừa phải, hậu vị thơm đặc trưng của nguyên liệu chính.";
                    baoQuan = "Bảo quản ngăn mát tủ lạnh 2–6°C, ngon nhất trong 2 ngày. Nên lấy bánh ra khoảng 10 phút trước khi dùng để mousse mềm mịn hơn.";
                    phuHop = "Sinh nhật, kỷ niệm, tiệc trà hoặc làm quà tặng người thân, bạn bè.";
                    break;

                case "Bánh Sinh Nhật":
                case "Bánh Kem":
                    thanhPhan = "Cốt bánh bông lan mềm xốp, kem tươi béo nhẹ, nhân và phần trang trí từ trái cây, socola hoặc kem bơ tùy mẫu.";
                    huongVi = "Cốt bánh mềm, kem tươi thơm béo, vị ngọt thanh dễ ăn, phù hợp với cả trẻ nhỏ và người lớn.";
                    baoQuan = "Bảo quản ngăn mát 2–6°C, nên dùng trong 24–48 giờ. Tránh để bánh nơi nắng nóng vì kem dễ chảy.";
                    phuHop = "Tiệc sinh nhật, liên hoan gia đình, công ty và các dịp chúc mừng.";
                    break;

                case "Bánh Tươi":
                    thanhPhan = "Bột mì, bơ, trứng, sữa và đường, được làm thủ công mỗi ngày, không dùng chất bảo quản.";
                    huongVi = "Thơm mùi bơ sữa, vị ngọt nhẹ, kết cấu mềm hoặc giòn tùy từng loại bánh.";
                    baoQuan = "Ngon nhất khi dùng trong ngày. Có thể để ngăn mát tối đa 2 ngày, lấy ra trước khi ăn một lúc.";
                    phuHop = "Bữa ăn nhẹ, đồ ăn kèm trà hoặc cà phê, quà tặng nhỏ xinh.";
                    break;

                case "Bánh Mì":
                    thanhPhan = "Bột mì, men nở, bơ, sữa cùng phần nhân (xúc xích, phô mai, trứng hoặc pate) tùy từng loại.";
                    huongVi = "Vỏ thơm, ruột mềm, nhân đậm đà, vừa ăn cho bữa sáng hoặc bữa xế.";
                    baoQuan = "Ngon nhất khi dùng ngay trong ngày. Có thể hâm lại bằng lò nướng hoặc nồi chiên không dầu khoảng 3–5 phút.";
                    phuHop = "Bữa sáng, bữa xế, mang đi học hoặc đi làm.";
                    break;

                default:
                    thanhPhan = "Làm từ nguyên liệu tươi, chọn lọc mỗi ngày.";
                    huongVi = "Thơm ngon, vị ngọt vừa phải.";
                    baoQuan = "Nên dùng trong ngày để có hương vị ngon nhất.";
                    phuHop = "Dùng cho mọi dịp.";
                    break;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<li><strong>Thành phần:</strong> " + thanhPhan + "</li>");
            sb.Append("<li><strong>Hương vị:</strong> " + huongVi + "</li>");
            sb.Append("<li><strong>Bảo quản:</strong> " + baoQuan + "</li>");
            sb.Append("<li><strong>Phù hợp:</strong> " + phuHop + "</li>");
            sb.Append("<li><strong>Lưu ý dị ứng:</strong> " + diUng + "</li>");
            return sb.ToString();
        }

        private void HienThongBao(HtmlGenericControl khung, string noiDung, bool thanhCong)
        {
            string icon = thanhCong
                ? "<i class=\"fa-solid fa-cart-shopping\"></i> "
                : "<i class=\"fa-solid fa-circle-exclamation\"></i> ";

            khung.InnerHtml = icon + HttpUtility.HtmlEncode(noiDung);
            khung.Attributes["class"] = "thong-bao-gio-hang vua-them" + (thanhCong ? "" : " loi");

           
            ClientScript.RegisterStartupScript(GetType(), "an_" + khung.ID,
                "setTimeout(function(){var e=document.getElementById('" + khung.ClientID +
                "');if(e)e.classList.add('an-thong-bao');},2000);", true);

            khung.Visible = true;
        }

        
        private bool ThemBanhVaoGio(string maBanh, string maSize, int soLuong)
        {
            if (TimBanh(maBanh) == null)
            {
                return false;
            }

            Dictionary<string, int> gioHang = Session["GioHang"] as Dictionary<string, int>;
            if (gioHang == null)
            {
                gioHang = new Dictionary<string, int>();
            }

            string khoa = GioHangKey.Tao(maBanh, maSize);   // khóa gồm cả size

            int hienCo;
            gioHang.TryGetValue(khoa, out hienCo);
            gioHang[khoa] = hienCo + soLuong;

            Session["GioHang"] = gioHang;
            return true;
        }

       
        private bool XuLyThemTuTrangChiTiet()
        {
            int soLuong;
            if (!int.TryParse(soLuongBanh.Value, out soLuong) || soLuong < 1 || soLuong > SoLuongToiDa)
            {
                HienThongBao(thongBaoGioHang, "Vui lòng nhập số lượng từ 1 đến " + SoLuongToiDa + ".", false);
                return false;
            }

            SanPhamBanh banh = TimBanh(Request.QueryString["id"]);
            if (banh == null)
            {
                HienThongBao(thongBaoGioHang, "Không tìm thấy sản phẩm!", false);
                return false;
            }

            string maSize = null;
            if (LaBanhKem(banh))
            {
                maSize = TaoDanhSachSize(banh, Request.Form["size"]).First(s => s.DaChon).Ma;
            }

            if (!ThemBanhVaoGio(banh.maBanh, maSize, soLuong))
            {
                HienThongBao(thongBaoGioHang, "Không tìm thấy sản phẩm!", false);
                return false;
            }
            return true;
        }

        protected void btnThemVaoGio_ServerClick(object sender, EventArgs e)
        {
            if (XuLyThemTuTrangChiTiet())
            {
                HienThongBao(thongBaoGioHang, "Bạn đã thêm vào giỏ hàng thành công!", true);
            }
        }

        protected void btnMuaNgay_ServerClick(object sender, EventArgs e)
        {
            if (XuLyThemTuTrangChiTiet())
            {
                Response.Redirect("DatHang.aspx");
            }
        }

       
        private void XuLyGoiYPost()
        {
            string giaTri = Request.Form["goiYAction"];
            string[] tach = giaTri.Split(new char[] { '|' }, 2);
            if (tach.Length != 2) return;

            string lenh = tach[0];
            string maBanh = tach[1];
            SanPhamBanh banh = TimBanh(maBanh);
            string maSize = banh != null && LaBanhKem(banh) ? "16" : null;

            if (banh == null || !ThemBanhVaoGio(maBanh, maSize, 1))
            {
                HienThongBao(thongBaoGoiY, "Không tìm thấy sản phẩm!", false);
                return;
            }

            if (lenh == "muaNgay")
            {
                Response.Redirect("DatHang.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            HienThongBao(thongBaoGoiY, "Đã thêm \"" + banh.tenBanh + "\" vào giỏ hàng!", true);
        }
    }
}