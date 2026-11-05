using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace baiTapLonBanh
{
    public partial class SuaSanPham : SweetCakePage
    {
        private bool LaAdmin()
        {
            NguoiDung tk = Session["TaiKhoan"] as NguoiDung;

            return tk != null && tk.VaiTro == "Admin";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!LaAdmin())
            {
                string trang = Session["TaiKhoan"] == null
                    ? "~/DangNhap.aspx"
                    : "~/TrangChu.aspx";

                Response.Redirect(ResolveUrl(trang), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (!IsPostBack)
            {
                string ma = Request.QueryString["id"];
                SanPhamBanh banh = TimSanPham(ma);

                if (banh == null)
                {
                    Response.Redirect(
                        ResolveUrl("~/QuanLySanPham.aspx"), false);

                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

       
                lblMaBanh.InnerText = Server.HtmlEncode(banh.maBanh);
                txtTenBanh.Value = banh.tenBanh;
                txtGiaBanh.Value =
                    banh.giaBanh.ToString(CultureInfo.InvariantCulture);
                txtMoTa.Value = banh.moTa ?? "";

                ddlLoaiBanh.Value = banh.loaiBanh;

                imgAnhHienTai.Src =
                    ResolveUrl("~/" + banh.anhBanh);

                imgAnhHienTai.Alt = banh.tenBanh;
            }
        }

        private SanPhamBanh TimSanPham(string ma)
        {
            SanPhamBanh ketQua = null;

            Application.Lock();

            try
            {
                List<SanPhamBanh> ds =
                    Application["DanhSachSanPham"] as List<SanPhamBanh>;

                if (ds != null)
                {
                    foreach (SanPhamBanh banh in ds)
                    {
                        if (banh.maBanh == ma)
                        {
                            ketQua = banh;
                            break;
                        }
                    }
                }
            }
            finally
            {
                Application.UnLock();
            }

            return ketQua;
        }

        private bool LoaiBanhHopLe(string loai)
        {
            return loai == "Bánh Mousse"
                || loai == "Bánh Sinh Nhật"
                || loai == "Bánh Kem"
                || loai == "Bánh Tươi"
                || loai == "Bánh Mì";
        }

        private void XoaLoi()
        {
            loiTenBanh.InnerText = "";
            loiGiaBanh.InnerText = "";
            loiLoaiBanh.InnerText = "";
            loiMoTa.InnerText = "";
            loiAnhBanh.InnerText = "";
            lblThongBao.InnerText = "";
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            
            if (!LaAdmin())
            {
                Response.Redirect(
                    ResolveUrl("~/DangNhap.aspx"), false);

                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            XoaLoi();

            string ma = Request.QueryString["id"];
            SanPhamBanh banhCu = TimSanPham(ma);

            if (banhCu == null)
            {
                lblThongBao.InnerText = "Không tìm thấy sản phẩm cần sửa.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
                return;
            }

            string ten = (txtTenBanh.Value ?? "").Trim();
            string moTa = (txtMoTa.Value ?? "").Trim();
            string loai = ddlLoaiBanh.Value;

            decimal gia;

            bool hopLe = true;

           
            if (ten.Length < 2 || ten.Length > 100)
            {
                loiTenBanh.InnerText =
                    "Tên bánh phải có từ 2 đến 100 ký tự.";
                hopLe = false;
            }

         
            if (!decimal.TryParse(
                    txtGiaBanh.Value.Trim(),
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out gia)
                || gia <= 0
                || gia > 1000000000m)
            {
                loiGiaBanh.InnerText = "Giá bán không hợp lệ.";
                hopLe = false;
            }

        
            if (!LoaiBanhHopLe(loai))
            {
                loiLoaiBanh.InnerText = "Vui lòng chọn loại bánh hợp lệ.";
                hopLe = false;
            }

            
            if (moTa.Length > 500 ||
                (moTa.Length > 0 && moTa.Length < 5))
            {
                loiMoTa.InnerText =
                    "Mô tả để trống hoặc có từ 5 đến 500 ký tự.";
                hopLe = false;
            }

            string duoiAnh = "";

            if ((fuAnhBanh.PostedFile != null && fuAnhBanh.PostedFile.ContentLength > 0))
            {
                duoiAnh = Path.GetExtension(
                    fuAnhBanh.PostedFile.FileName).ToLowerInvariant();

                if (duoiAnh != ".jpg" &&
                    duoiAnh != ".jpeg" &&
                    duoiAnh != ".png" &&
                    duoiAnh != ".webp")
                {
                    loiAnhBanh.InnerText =
                        "Chỉ chấp nhận ảnh JPG, JPEG, PNG hoặc WEBP.";
                    hopLe = false;
                }
                else if (fuAnhBanh.PostedFile.ContentLength <= 0 ||
                         fuAnhBanh.PostedFile.ContentLength >
                         5 * 1024 * 1024)
                {
                    loiAnhBanh.InnerText =
                        "Ảnh phải lớn hơn 0 và không vượt quá 5 MB.";
                    hopLe = false;
                }
            }

            if (!hopLe)
            {
                lblThongBao.InnerText =
                    "Vui lòng kiểm tra lại thông tin sản phẩm.";
                lblThongBao.Attributes["class"] = "admin-message that-bai";
                return;
            }

          
            string anhMoi = banhCu.anhBanh;
            string duongDanAnhMoi = "";

            try
            {
          
                if ((fuAnhBanh.PostedFile != null && fuAnhBanh.PostedFile.ContentLength > 0))
                {
                    string thuMucAnh =
                        Server.MapPath("~/image/SanPham/");

                    if (!Directory.Exists(thuMucAnh))
                    {
                        Directory.CreateDirectory(thuMucAnh);
                    }

                    string tenFile =
                        "sp_" + Guid.NewGuid().ToString("N") + duoiAnh;

                    duongDanAnhMoi =
                        Path.Combine(thuMucAnh, tenFile);

                    fuAnhBanh.PostedFile.SaveAs(duongDanAnhMoi);

                    anhMoi = "image/SanPham/" + tenFile;
                }

                bool daCapNhat = false;

                Application.Lock();

                try
                {
                    List<SanPhamBanh> ds =
                        Application["DanhSachSanPham"]
                        as List<SanPhamBanh>;

                    if (ds != null)
                    {
                       
                        List<SanPhamBanh> dsMoi =
                            new List<SanPhamBanh>(ds);

                        for (int i = 0; i < dsMoi.Count; i++)
                        {
                            if (dsMoi[i].maBanh == ma)
                            {
                                SanPhamBanh banhSua =
                                    new SanPhamBanh
                                    {
                                        maBanh = dsMoi[i].maBanh,
                                        tenBanh = ten,
                                        giaBanh = gia,
                                        anhBanh = anhMoi,
                                        moTa = moTa,
                                        loaiBanh = loai,
                                        ngayTao = dsMoi[i].ngayTao
                                    };

                                dsMoi[i] = banhSua;

                                Application["DanhSachSanPham"] = dsMoi;

                                daCapNhat = true;
                                break;
                            }
                        }
                    }
                }
                finally
                {
                    Application.UnLock();
                }

                if (!daCapNhat)
                {
                    if (!string.IsNullOrEmpty(duongDanAnhMoi) &&
                        File.Exists(duongDanAnhMoi))
                    {
                        File.Delete(duongDanAnhMoi);
                    }

                    lblThongBao.InnerText =
                        "Không tìm thấy sản phẩm cần cập nhật.";

                    lblThongBao.Attributes["class"] = "admin-message that-bai";
                    return;
                }
            }
            catch (Exception)
            {
              
                try
                {
                    if (!string.IsNullOrEmpty(duongDanAnhMoi) &&
                        File.Exists(duongDanAnhMoi))
                    {
                        File.Delete(duongDanAnhMoi);
                    }
                }
                catch
                {
                    
                }

                lblThongBao.InnerText =
                    "Không thể cập nhật sản phẩm. Em hãy kiểm tra lại thư mục ảnh.";

                lblThongBao.Attributes["class"] = "admin-message that-bai";
                return;
            }

        
            Response.Redirect(
                ResolveUrl("~/QuanLySanPham.aspx?sua=thanhcong"),
                false);

            Context.ApplicationInstance.CompleteRequest();
        }
    }
}