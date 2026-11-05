using baiTapLonBanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
namespace baiTapLonBanh
{
    public partial class DangKy : SweetCakePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["dangky"] == "thanhcong")
                {
                    divThongBao.InnerHtml = "<div class='message success'>Đăng ký thành công!Vui lòng đăng nhập.</div>";
                }
                return;
            }
            loiFullname.InnerText = "";
            loiUsername.InnerText = "";
            loiPassword.InnerText = "";
            loiConfirmPassword.InnerText = "";
            string fullname = (Request.Form["fullname"] ?? "").Trim();
            string username = (Request.Form["username"] ?? "").Trim();
            string password = Request.Form["password"] ?? "";
            string confirmPassword = Request.Form["confirm_password"] ?? "";

            bool duLieuHopLe = true;
            if (fullname == "")
            {
                loiFullname.InnerText = "Vui lòng nhập họ và tên.";
                duLieuHopLe = false;
                return;
            }
            else if (fullname.Length < 2 || fullname.Length > 50)
            {
                loiFullname.InnerText = "Họ và tên phải có từ 2 đến 50 ký tự.";
                duLieuHopLe = false;
            }
            if (username == "")
            {
                loiUsername.InnerText = "Vui lòng nhập tên đăng nhập.";
                duLieuHopLe = false;
            }
            else if (!Regex.IsMatch(username, @"^[A-Za-z0-9_]{4,20}$"))
            {
                loiUsername.InnerText =
                    "Tên đăng nhập phải có 4–20 ký tự, chỉ gồm chữ không dấu, số và dấu gạch dưới.";
                duLieuHopLe = false;
            }
            if (password.Length < 8)
            {
                loiPassword.InnerText = "Mật khẩu phải có ít nhất 8 ký tự.";
                duLieuHopLe = false;
            }
            if (confirmPassword == "")
            {
                loiConfirmPassword.InnerText = "Vui lòng xác nhận mật khẩu.";
                duLieuHopLe = false;
            }
            else if (password != confirmPassword)
            {
                loiConfirmPassword.InnerText = "Mật khẩu xác nhận không khớp.";
                duLieuHopLe = false;
            }
            if (!duLieuHopLe)
            {
                return;
            }

            NguoiDung userMoi = null;
            string loi = null;
            Application.Lock();
            try
            {
                List<NguoiDung> dsTaiKhoan = Application["DanhSachNguoiDung"] as List<NguoiDung>;

                if (dsTaiKhoan == null)
                {
                    dsTaiKhoan = new List<NguoiDung>();
                }

                if (dsTaiKhoan.Exists(u => u.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    loi = "Tên đăng nhập này đã được sử dụng!";
                }
                else
                {
                    userMoi = new NguoiDung
                    {
                        HoTen = fullname,
                        TenDangNhap = username,
                        MatKhau = password,
                        VaiTro = "KhachHang"
                    };

                    dsTaiKhoan.Add(userMoi);
                    Application["DanhSachNguoiDung"] = dsTaiKhoan;
                }
            }
            finally
            {
                Application.UnLock();
            }

            if (loi != null)
            {
                loiUsername.InnerText = loi;
                return;
            }
            divThongBao.InnerHtml =
                "<div class='message success'>" +
                "Đăng ký thành công! " +
                "<a href='DangNhap.aspx'>Đăng nhập ngay</a>" +
                "</div>";

            return;
        }
    }
}