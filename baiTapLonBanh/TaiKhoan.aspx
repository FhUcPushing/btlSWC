<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="baiTapLonBanh.TaiKhoan" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/TaiKhoan.css?v=1" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
<header class="site-header">
            <div class="nav-container">

                <div class="mobile-left-controls">
    <button type="button"
            class="menu-toggle"
            aria-label="Mở menu"
            aria-expanded="false"
            onclick="toggleMobileMenu()">
        <i class="fa-solid fa-bars"></i>
    </button>
</div>


                <a href="TrangChu.aspx"
                   class="brand"
                   aria-label="SweetCake - Trang chủ">
                    <span class="brand-icon">
                        <i class="fa-solid fa-cake-candles"></i>
                    </span>
                    <span class="brand-name">SweetCake</span>
                </a>


                <nav class="main-nav" id="mainNav">

                    <div id="vungTaiKhoanNav" runat="server"></div>

                    <a href="TrangChu.aspx">
                        <i class="fa-solid fa-house"></i>
                        <span>Trang chủ</span>
                    </a>
                    <a href="SanPham.aspx">
                        <i class="fa-solid fa-cake-candles"></i>
                        <span>Sản phẩm</span>
                    </a>
                    <a href="GioiThieu.aspx">
                        <i class="fa-solid fa-store"></i>
                        <span>Giới thiệu</span>
                    </a>
                    <a href="TinTuc.aspx">
                        <i class="fa-regular fa-newspaper"></i>
                        <span>Tin tức</span>
                    </a>
                    <a href="TuVan.aspx">
                        <i class="fa-solid fa-headset"></i>
                        <span>Tư vấn</span>
                    </a>

                </nav>


                <div class="header-right">
                    <div class="header-search" id="headerSearch">
    <input type="search"
           id="txtTimKiem"
           placeholder="Tìm bánh..."
           autocomplete="off"
           enterkeyhint="search"
           aria-label="Tìm kiếm bánh" />

    <button type="button"
            onclick="xuLyTimKiem()"
            aria-label="Tìm kiếm">
        <i class="fa-solid fa-magnifying-glass"></i>
    </button>
</div>
                    <div class="header-account">
                        <a href="GioHang.aspx"
                           class="cart-link"
                           aria-label="Giỏ hàng"
                           title="Giỏ hàng">
                            <i class="fa-solid fa-bag-shopping"></i>
                        </a>

                        <div id="vungTaiKhoanHeader" runat="server" style="display: contents;"></div>
                    </div>
                </div>
            </div>
        </header>

        <main>
            <div class="container product-page tai-khoan-page">
        <h1>Tài khoản của tôi</h1>

        <div class="tk-luoi">
            <!-- ===== MENU TRÁI ===== -->
            <aside class="tk-menu">
                <div class="tk-chao">
                    <i class="fa-solid fa-circle-user"></i>
                    <strong><span ID="litHoTen" runat="server"></span></strong>
                    <span>@<span ID="litTenDN" runat="server"></span></span>
                </div>
                <a id="lnkTabThongTin" runat="server" href="TaiKhoan.aspx?tab=thongtin">
                    <i class="fa-regular fa-id-card"></i> Thông tin tài khoản
                </a>
                <a id="lnkTabDonHang" runat="server" href="TaiKhoan.aspx?tab=donhang">
                    <i class="fa-solid fa-receipt"></i> Đơn hàng của tôi
                </a>

<div ID="pnlMenuQuanTri"
    runat="server"
    Visible="false">

    <a ID="lnkMenuQuanLySanPham"
        runat="server" href="QuanLySanPham.aspx">

        <i class="fa-solid fa-cake-candles"></i>
        Quản lý sản phẩm

    </a>

    <a ID="lnkMenuQuanLyDonHang"
        runat="server" href="QuanTri.aspx">

        <i class="fa-solid fa-clipboard-list"></i>
        Quản lý đơn hàng

    </a>

    <a href="QuanLyNguoiDung.aspx">
        <i class="fa-solid fa-users"></i>
        Quản lý thành viên
    </a>

</div>
                <a href="DangNhap.aspx?dangxuat=1" class="tk-dang-xuat">
                    <i class="fa-solid fa-right-from-bracket"></i> Đăng xuất
                </a>
            </aside>


            <div class="tk-noi-dung">


              <div ID="pnlThongTin" runat="server">
    <section class="tk-khoi">
        <h2>Thông tin tài khoản</h2>
        <div id="msgCapNhat" runat="server" visible="false"></div>

        <div class="tk-hang">
            <div class="tk-truong">
                <label class="tk-nhan" for="txtHoTen">Họ và tên</label>
                <input ID="txtHoTen" runat="server" class="tk-o" maxlength="50"  type="text" ClientIDMode="Static" />
                <span id="loiHoTen" runat="server" class="tk-loi"></span>
            </div>
            <div class="tk-truong">
                <label class="tk-nhan" for="txtTenMoi">Tên đăng nhập</label>
                <input ID="txtTenMoi" runat="server" class="tk-o" maxlength="20"  type="text" ClientIDMode="Static" />
                <span id="loiTenDN" runat="server" class="tk-loi"></span>
            </div>
        </div>

        <p class="tk-tieu-de-nho">Đổi mật khẩu <span>(bỏ trống nếu không muốn đổi)</span></p>
        <div class="tk-hang tk-ba">
            <div class="tk-truong">
                <label class="tk-nhan" for="txtMkCu">Mật khẩu hiện tại</label>
                <input ID="txtMkCu" runat="server" class="tk-o"  type="password" ClientIDMode="Static" />
                <span id="loiMkCu" runat="server" class="tk-loi"></span>
            </div>
            <div class="tk-truong">
                <label class="tk-nhan" for="txtMkMoi">Mật khẩu mới</label>
                <input ID="txtMkMoi" runat="server" class="tk-o"  type="password" ClientIDMode="Static" />
                <span id="loiMkMoi" runat="server" class="tk-loi"></span>
            </div>
            <div class="tk-truong">
                <label class="tk-nhan" for="txtMkLai">Nhập lại mật khẩu mới</label>
                <input ID="txtMkLai" runat="server" class="tk-o"  type="password" ClientIDMode="Static" />
                <span id="loiMkLai" runat="server" class="tk-loi"></span>
            </div>
        </div>

        <button ID="btnCapNhat" runat="server" class="tk-nut" onserverclick="btnCapNhat_Click" >Cập nhật</button>
    </section>
</div>



                <div ID="pnlDonHang" runat="server">
                    <section class="tk-khoi">
                        <h2>Lịch sử đơn hàng</h2>

                        <div ID="pnlDonRong" runat="server" Visible="false" class="tk-rong">
                            <p>Bạn chưa có đơn hàng nào.</p>
                            <a href="SanPham.aspx" class="tk-nut">Mua sắm ngay</a>
                        </div>

                        <div ID="pnlCoDon" runat="server" Visible="false" class="tk-bang-khung">
                           <table class="tk-bang tk-bang-don">
                                <thead>
                                    <tr><th>Mã đơn</th><th>Ngày đặt</th><th>Số bánh</th><th>Tổng tiền</th><th>Trạng thái</th><th></th></tr>
                                </thead>
                                <tbody id="tbodyDonHang" runat="server"></tbody>
                            </table>
                        </div>
                    </section>
                </div>

            </div>
        </div>
    </div>
    <script src="JS/TaiKhoan.js"
        defer="defer"></script>
        </main>

        <footer class="footer">
    <div class="container footer-ba-cot">


        <div class="fc fc-trai">
            <h4>Thông tin liên hệ</h4>
            <p>Hotline tư vấn: 0901 234 567</p>
            <p>Địa chỉ: 123 Đường ABC, Bắc Ninh</p>
            <p>Email: hello@sweetcake.vn</p>
            <p>Giờ mở cửa: 8:00 – 21:00 mỗi ngày</p>
        </div>


<div class="fc fc-giua">
    <p class="footer-brand">
        <i class="fa-solid fa-cake-candles"></i> SweetCake
    </p>
    <p class="footer-khau-hieu">Ngọt ngào trong từng chiếc bánh.</p>

</div>

        <div class="fc fc-phai">
            <h4>Liên kết</h4>
            <div class="footer-mxh">
                <a href="#" aria-label="Facebook"><i class="fa-brands fa-facebook"></i></a>
                <a href="#" aria-label="Instagram"><i class="fa-brands fa-instagram"></i></a>
                <a href="#" aria-label="TikTok"><i class="fa-brands fa-tiktok"></i></a>
            </div>
            <div class="footer-menu">
                <a href="SanPham.aspx">Sản phẩm</a>
                <a href="TinTuc.aspx">Tin tức</a>
                <a href="TuVan.aspx">Tư vấn</a>
            </div>
        </div>

    </div>
    <div class="footer-ban-quyen">© 2026 SweetCake. Bảo lưu mọi quyền.</div>
</footer>
    </form>

    <script src="JS/Site.js"></script>
</body>
</html>
