using baiTapLonBanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace baiTapLonBanh
{
    public partial class DangNhap : SweetCakePage
    {
        public string savedUser = "";
        public bool isRemembered = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["dangxuat"] == "1")
            {
                Session.Remove("TaiKhoan");
                Session.Remove("TenHienThi");
                Response.Redirect("TrangChu.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (Request.Cookies["SweetCakeUser"] != null)
                {
                    savedUser = Request.Cookies["SweetCakeUser"].Value;
                    isRemembered = true;
                }

                if (Request.Cookies["SweetCakePass"] != null)
                {
                    Response.Cookies["SweetCakePass"].Expires = DateTime.Now.AddDays(-1);
                }

                return;
            }

            savedUser = (username.Value ?? "").Trim();
            isRemembered = chkRemember.Checked;

            loiUsername.InnerText = "";
            loiPassword.InnerText = "";
            divThongBao.InnerHtml = "";

            string tenDangNhap = (username.Value ?? "").Trim();
            string password = Request.Form["password"] ?? "";
            string remember = chkRemember.Checked ? "true" : "";

            bool duLieuHopLe = true;

            if (tenDangNhap == "")
            {
                loiUsername.InnerText = "Tên đăng nhập không được để trống!";
                duLieuHopLe = false;
            }

            if (password == "")
            {
                loiPassword.InnerText = "Mật khẩu không được để trống!";
                duLieuHopLe = false;
            }

            if (!duLieuHopLe)
            {
                return;
            }

            NguoiDung userFound = null;
            List<NguoiDung> dsNguoiDung = Application["DanhSachNguoiDung"] as List<NguoiDung>;

            if (dsNguoiDung != null)
            {
                foreach (NguoiDung u in dsNguoiDung)
                {
                    if (tenDangNhap == u.TenDangNhap && password == u.MatKhau)
                    {
                        userFound = u;
                        break;
                    }
                }
            }

            if (userFound != null)
            {
                Session["TaiKhoan"] = userFound;
                Session["TenHienThi"] = userFound.TenDangNhap;

                if (Request.Cookies["SweetCakePass"] != null)
                {
                    Response.Cookies["SweetCakePass"].Expires = DateTime.Now.AddDays(-1);
                }

                if (remember == "true")
                {
                    Response.Cookies["SweetCakeUser"].Value = tenDangNhap;
                    Response.Cookies["SweetCakeUser"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    if (Request.Cookies["SweetCakeUser"] != null)
                    {
                        Response.Cookies["SweetCakeUser"].Expires = DateTime.Now.AddDays(-1);
                    }
                }

                Response.Redirect("TrangChu.aspx");
                return;
            }

            divThongBao.InnerHtml = "<div class='message error'>Tên đăng nhập hoặc mật khẩu không đúng!</div>";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            username.Value = savedUser ?? "";
            chkRemember.Checked = isRemembered;
        }
    }
}
