using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class QuanLyNguoiDung : SweetCakePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NguoiDung taiKhoan = Session["TaiKhoan"] as NguoiDung;
            if (taiKhoan == null)
            {
                Response.Redirect(ResolveUrl("~/DangNhap.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (taiKhoan.VaiTro != "Admin")
            {
                Response.Redirect(ResolveUrl("~/TrangChu.aspx"), false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (Request.HttpMethod == "POST")
            {
                string tenCanXoa = Request.Form["xoaNguoiDung"];
                if (!string.IsNullOrWhiteSpace(tenCanXoa))
                {
                    XuLyXoaThanhVien(tenCanXoa);
                }
                else if (Request.Form["capNhatNguoiDung"] == "1")
                {
                    if (XuLyCapNhatThanhVien())
                    {
                        Response.Redirect(ResolveUrl("~/QuanLyNguoiDung.aspx?capnhat=thanhcong"), false);
                        Context.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
            }
            else
            {
                string thongBao = Request.QueryString["capnhat"];
                if (thongBao == "thanhcong")
                {
                    HienThongBao("Cập nhật thông tin thành viên thành công!", true);
                }
            }

            HienThiDanhSachThanhVien();
            HienThiChiTietThanhVien();
        }

        private void HienThongBao(string noiDung, bool thanhCong)
        {
            divThongBao.InnerText = noiDung;
            divThongBao.Attributes["class"] = thanhCong
                ? "admin-message thanh-cong"
                : "admin-message that-bai";
        }

        private List<NguoiDung> LayDanhSachThanhVien()
        {
            List<NguoiDung> ketQua = new List<NguoiDung>();

            Application.Lock();
            try
            {
                List<NguoiDung> danhSachGoc = Application["DanhSachNguoiDung"] as List<NguoiDung>;
                if (danhSachGoc != null)
                {
                    foreach (NguoiDung nguoi in danhSachGoc)
                    {
                        if (nguoi != null && nguoi.VaiTro == "KhachHang")
                        {
                            ketQua.Add(new NguoiDung
                            {
                                HoTen = nguoi.HoTen,
                                TenDangNhap = nguoi.TenDangNhap,
                                VaiTro = nguoi.VaiTro
                            });
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

        private Dictionary<string, int> DemDonHangTheoThanhVien()
        {
            Dictionary<string, int> ketQua = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            Application.Lock();
            try
            {
                List<DonHang> danhSachDon = Application["DanhSachDonHang"] as List<DonHang>;
                if (danhSachDon != null)
                {
                    foreach (DonHang don in danhSachDon)
                    {
                        if (don == null || string.IsNullOrWhiteSpace(don.TenDangNhap)) continue;

                        if (!ketQua.ContainsKey(don.TenDangNhap))
                        {
                            ketQua[don.TenDangNhap] = 0;
                        }
                        ketQua[don.TenDangNhap]++;
                    }
                }
            }
            finally
            {
                Application.UnLock();
            }

            return ketQua;
        }

        private void HienThiDanhSachThanhVien()
        {
            List<NguoiDung> danhSach = LayDanhSachThanhVien();
            Dictionary<string, int> soDonHang = DemDonHangTheoThanhVien();
            string tuKhoa = (txtTimThanhVien.Value ?? "").Trim();

            // Tìm không phân biệt chữ hoa/chữ thường, có thể nhập một phần họ hoặc tên.
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                List<NguoiDung> danhSachLoc = new List<NguoiDung>();
                foreach (NguoiDung nguoi in danhSach)
                {
                    if ((nguoi.HoTen ?? "").IndexOf(tuKhoa, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        danhSachLoc.Add(nguoi);
                    }
                }
                danhSach = danhSachLoc;
            }

            soLuongThanhVien.InnerText = danhSach.Count + " thành viên";
            if (danhSach.Count == 0)
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    divDanhSachNguoiDung.InnerHtml = "<p class='admin-empty-message'>Chưa có thành viên nào đăng ký tài khoản.</p>";
                }
                else
                {
                    divDanhSachNguoiDung.InnerHtml = "<p class='admin-empty-message'>Không tìm thấy thành viên có họ tên phù hợp với từ khóa <strong>" + HttpUtility.HtmlEncode(tuKhoa) + "</strong>.</p>";
                }
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='admin-order-table admin-member-table'><thead><tr>")
              .Append("<th>Họ và tên</th><th>Tên đăng nhập</th><th>Vai trò</th><th>Số đơn hàng</th><th>Thao tác</th>")
              .Append("</tr></thead><tbody>");

            foreach (NguoiDung nguoi in danhSach)
            {
                int soDon = 0;
                if (soDonHang.ContainsKey(nguoi.TenDangNhap)) soDon = soDonHang[nguoi.TenDangNhap];

                string tenDangNhap = nguoi.TenDangNhap ?? "";
                string urlXem = ResolveUrl("~/QuanLyNguoiDung.aspx?xem=" + HttpUtility.UrlEncode(tenDangNhap));
                string urlSua = ResolveUrl("~/QuanLyNguoiDung.aspx?sua=" + HttpUtility.UrlEncode(tenDangNhap));

                sb.Append("<tr><td>").Append(HttpUtility.HtmlEncode(nguoi.HoTen)).Append("</td>")
                  .Append("<td>").Append(HttpUtility.HtmlEncode(tenDangNhap)).Append("</td>")
                  .Append("<td><span class='admin-role-badge'>Khách hàng</span></td>")
                  .Append("<td>").Append(soDon).Append("</td><td class='admin-member-actions'>")
                  .Append("<a class='admin-detail-link' href='").Append(HttpUtility.HtmlAttributeEncode(urlXem)).Append("'><i class='fa-regular fa-eye'></i> Xem</a> ")
                  .Append("<a class='admin-detail-link' href='").Append(HttpUtility.HtmlAttributeEncode(urlSua)).Append("'><i class='fa-solid fa-pen'></i> Sửa</a> ")
                  .Append("<button type='submit' class='admin-delete-btn' name='xoaNguoiDung' value='")
                  .Append(HttpUtility.HtmlAttributeEncode(tenDangNhap))
                  .Append("' onclick=\"return confirm('Bạn có chắc chắn muốn xóa tài khoản này không? Lịch sử đơn hàng cũ sẽ được giữ lại.');\"><i class='fa-solid fa-trash'></i> Xóa</button>")
                  .Append("</td></tr>");
            }

            sb.Append("</tbody></table>");
            divDanhSachNguoiDung.InnerHtml = sb.ToString();
        }

        private NguoiDung TimThanhVien(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return null;

            NguoiDung ketQua = null;
            Application.Lock();
            try
            {
                List<NguoiDung> danhSach = Application["DanhSachNguoiDung"] as List<NguoiDung>;
                if (danhSach != null)
                {
                    foreach (NguoiDung nguoi in danhSach)
                    {
                        if (nguoi != null && nguoi.VaiTro == "KhachHang" &&
                            string.Equals(nguoi.TenDangNhap, tenDangNhap, StringComparison.OrdinalIgnoreCase))
                        {
                            ketQua = new NguoiDung
                            {
                                HoTen = nguoi.HoTen,
                                TenDangNhap = nguoi.TenDangNhap,
                                VaiTro = nguoi.VaiTro
                            };
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

        private void HienThiChiTietThanhVien()
        {
            string tenXem = Request.QueryString["xem"];
            string tenSua = Request.QueryString["sua"];
            if (Request.HttpMethod == "POST" && Request.Form["capNhatNguoiDung"] == "1")
            {
                tenSua = Request.Form["tenDangNhapCu"];
            }

            if (!string.IsNullOrWhiteSpace(tenSua))
            {
                NguoiDung nguoi = TimThanhVien(tenSua);
                divChiTietNguoiDung.Visible = true;
                if (nguoi == null)
                {
                    divChiTietNguoiDung.InnerHtml = "<p class='admin-empty-message'>Không tìm thấy thành viên cần sửa.</p>";
                    return;
                }

                string hoTen = Request.HttpMethod == "POST" ? (Request.Form["hoTenMoi"] ?? nguoi.HoTen) : nguoi.HoTen;
                string tenDangNhap = Request.HttpMethod == "POST" ? (Request.Form["tenDangNhapMoi"] ?? nguoi.TenDangNhap) : nguoi.TenDangNhap;
                divChiTietNguoiDung.InnerHtml = TaoFormSua(nguoi.TenDangNhap, hoTen, tenDangNhap);
                return;
            }

            if (!string.IsNullOrWhiteSpace(tenXem))
            {
                NguoiDung nguoi = TimThanhVien(tenXem);
                divChiTietNguoiDung.Visible = true;
                if (nguoi == null)
                {
                    divChiTietNguoiDung.InnerHtml = "<p class='admin-empty-message'>Không tìm thấy thành viên cần xem.</p>";
                    return;
                }
                divChiTietNguoiDung.InnerHtml = TaoChiTietThanhVien(nguoi);
            }
        }

        private string TaoChiTietThanhVien(NguoiDung nguoi)
        {
            Dictionary<string, int> soDonHang = DemDonHangTheoThanhVien();
            int soDon = soDonHang.ContainsKey(nguoi.TenDangNhap) ? soDonHang[nguoi.TenDangNhap] : 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='admin-member-detail-heading'><h2>Thông tin thành viên</h2>")
              .Append("<a class='admin-detail-link' href='QuanLyNguoiDung.aspx'>Quay lại danh sách</a></div>")
              .Append("<dl class='admin-member-info'>")
              .Append("<dt>Họ và tên</dt><dd>").Append(HttpUtility.HtmlEncode(nguoi.HoTen)).Append("</dd>")
              .Append("<dt>Tên đăng nhập</dt><dd>").Append(HttpUtility.HtmlEncode(nguoi.TenDangNhap)).Append("</dd>")
              .Append("<dt>Vai trò</dt><dd>Khách hàng</dd>")
              .Append("<dt>Số đơn hàng</dt><dd>").Append(soDon).Append("</dd>")
              .Append("</dl><p class='admin-member-note'>Vì lý do bảo mật, mật khẩu không được hiển thị.</p>")
              .Append("<a class='admin-btn-link' href='QuanLyNguoiDung.aspx?sua=")
              .Append(HttpUtility.UrlEncode(nguoi.TenDangNhap)).Append("'><i class='fa-solid fa-pen'></i> Sửa thông tin</a>");
            return sb.ToString();
        }

        private string TaoFormSua(string tenCu, string hoTen, string tenMoi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='admin-member-detail-heading'><h2>Sửa thông tin thành viên</h2>")
              .Append("<a class='admin-detail-link' href='QuanLyNguoiDung.aspx'>Quay lại danh sách</a></div>")
              .Append("<div class='admin-member-form'>")
              .Append("<input type='hidden' name='tenDangNhapCu' value='").Append(HttpUtility.HtmlAttributeEncode(tenCu)).Append("' />")
              .Append("<div class='admin-form-group'><label for='hoTenMoi'>Họ và tên</label>")
              .Append("<input type='text' id='hoTenMoi' name='hoTenMoi' maxlength='50' required value='")
              .Append(HttpUtility.HtmlAttributeEncode(hoTen)).Append("' /></div>")
              .Append("<div class='admin-form-group'><label for='tenDangNhapMoi'>Tên đăng nhập</label>")
              .Append("<input type='text' id='tenDangNhapMoi' name='tenDangNhapMoi' minlength='4' maxlength='20' required value='")
              .Append(HttpUtility.HtmlAttributeEncode(tenMoi)).Append("' />")
              .Append("<small>4–20 ký tự, chỉ gồm chữ không dấu, số và dấu gạch dưới.</small></div>")
              .Append("<div class='admin-form-group'><label for='matKhauMoi'>Mật khẩu mới (không bắt buộc)</label>")
              .Append("<input type='password' id='matKhauMoi' name='matKhauMoi' minlength='8' autocomplete='new-password' />")
              .Append("<small>Để trống nếu không muốn thay đổi mật khẩu. Nếu nhập, mật khẩu phải có ít nhất 8 ký tự.</small></div>")
              .Append("<div class='admin-product-actions'>")
              .Append("<button type='submit' class='admin-btn' name='capNhatNguoiDung' value='1'><i class='fa-solid fa-floppy-disk'></i> Lưu thay đổi</button>")
              .Append("<a class='admin-detail-link' href='QuanLyNguoiDung.aspx'>Hủy</a>")
              .Append("</div></div>");
            return sb.ToString();
        }

        private bool XuLyCapNhatThanhVien()
        {
            string tenCu = (Request.Form["tenDangNhapCu"] ?? "").Trim();
            string hoTenMoi = Regex.Replace((Request.Form["hoTenMoi"] ?? "").Trim(), @"\s+", " ");
            string tenMoi = (Request.Form["tenDangNhapMoi"] ?? "").Trim();
            string matKhauMoi = Request.Form["matKhauMoi"] ?? "";

            if (string.IsNullOrWhiteSpace(tenCu))
            {
                HienThongBao("Không xác định được thành viên cần cập nhật.", false);
                return false;
            }
            if (hoTenMoi.Length < 2 || hoTenMoi.Length > 50 || Regex.IsMatch(hoTenMoi, @"\d"))
            {
                HienThongBao("Họ và tên phải từ 2 đến 50 ký tự và không chứa chữ số.", false);
                return false;
            }
            if (!Regex.IsMatch(tenMoi, @"^[A-Za-z0-9_]{4,20}$"))
            {
                HienThongBao("Tên đăng nhập phải có 4–20 ký tự, chỉ gồm chữ không dấu, số và dấu gạch dưới.", false);
                return false;
            }
            if (matKhauMoi != "" && matKhauMoi.Length < 8)
            {
                HienThongBao("Mật khẩu mới phải có ít nhất 8 ký tự.", false);
                return false;
            }

            bool daCapNhat = false;
            bool biTrungTen = false;
            bool khongTimThay = false;

            Application.Lock();
            try
            {
                List<NguoiDung> dsNguoiDung = Application["DanhSachNguoiDung"] as List<NguoiDung>;
                if (dsNguoiDung != null)
                {
                    NguoiDung thanhVien = null;
                    foreach (NguoiDung nguoi in dsNguoiDung)
                    {
                        if (nguoi != null && nguoi.VaiTro == "KhachHang" &&
                            string.Equals(nguoi.TenDangNhap, tenCu, StringComparison.OrdinalIgnoreCase))
                        {
                            thanhVien = nguoi;
                            break;
                        }
                    }

                    if (thanhVien == null)
                    {
                        khongTimThay = true;
                    }
                    else
                    {
                        foreach (NguoiDung nguoi in dsNguoiDung)
                        {
                            if (nguoi != null && !object.ReferenceEquals(nguoi, thanhVien) &&
                                string.Equals(nguoi.TenDangNhap, tenMoi, StringComparison.OrdinalIgnoreCase))
                            {
                                biTrungTen = true;
                                break;
                            }
                        }

                        if (!biTrungTen)
                        {
                            thanhVien.HoTen = hoTenMoi;
                            thanhVien.TenDangNhap = tenMoi;
                            if (matKhauMoi != "") thanhVien.MatKhau = matKhauMoi;

                            if (!string.Equals(tenCu, tenMoi, StringComparison.Ordinal))
                            {
                                List<DonHang> dsDon = Application["DanhSachDonHang"] as List<DonHang>;
                                if (dsDon != null)
                                {
                                    foreach (DonHang don in dsDon)
                                    {
                                        if (don != null && string.Equals(don.TenDangNhap, tenCu, StringComparison.OrdinalIgnoreCase))
                                        {
                                            don.TenDangNhap = tenMoi;
                                        }
                                    }
                                }
                            }
                            daCapNhat = true;
                        }
                    }
                }
                else
                {
                    khongTimThay = true;
                }
            }
            finally
            {
                Application.UnLock();
            }

            if (biTrungTen)
            {
                HienThongBao("Tên đăng nhập này đã được sử dụng bởi tài khoản khác.", false);
                return false;
            }
            if (khongTimThay || !daCapNhat)
            {
                HienThongBao("Không tìm thấy thành viên cần cập nhật.", false);
                return false;
            }

            return true;
        }

        private void XuLyXoaThanhVien(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                HienThongBao("Tên đăng nhập không hợp lệ.", false);
                return;
            }

            bool daXoa = false;
            bool khongDuocPhep = false;

            Application.Lock();
            try
            {
                List<NguoiDung> dsNguoiDung = Application["DanhSachNguoiDung"] as List<NguoiDung>;
                if (dsNguoiDung != null)
                {
                    NguoiDung canXoa = null;
                    foreach (NguoiDung nguoi in dsNguoiDung)
                    {
                        if (nguoi != null && string.Equals(nguoi.TenDangNhap, tenDangNhap, StringComparison.OrdinalIgnoreCase))
                        {
                            canXoa = nguoi;
                            break;
                        }
                    }

                    if (canXoa != null)
                    {
                        if (canXoa.VaiTro != "KhachHang")
                        {
                            khongDuocPhep = true;
                        }
                        else
                        {
                            dsNguoiDung.Remove(canXoa);
                            Application["DanhSachNguoiDung"] = dsNguoiDung;
                            daXoa = true;
                        }
                    }
                }
            }
            finally
            {
                Application.UnLock();
            }

            if (daXoa)
            {
                HienThongBao("Đã xóa tài khoản thành viên. Lịch sử đơn hàng cũ vẫn được giữ lại.", true);
            }
            else if (khongDuocPhep)
            {
                HienThongBao("Không thể xóa tài khoản quản trị viên.", false);
            }
            else
            {
                HienThongBao("Không tìm thấy thành viên cần xóa.", false);
            }
        }
    }
}
