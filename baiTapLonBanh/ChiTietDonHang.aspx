<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ChiTietDonHang.aspx.cs" Inherits="baiTapLonBanh.ChiTietDonHang" %>
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

        <div ID="pnlKhongTim" runat="server" Visible="false" class="tk-khoi tk-rong">
            <p>Không tìm thấy đơn hàng này.</p>
            <a href="TaiKhoan.aspx?tab=donhang" class="tk-nut">Về danh sách đơn hàng</a>
        </div>

        <div ID="pnlChiTiet" runat="server">


            <div class="ct-dau">
                <a id="lnkQuayLai" runat="server" class="ct-quay-lai">
    <i class="fa-solid fa-arrow-left"></i>
    <span ID="litQuayLai" runat="server"></span>
</a>
                <div class="ct-tieu-de">
                    Đơn <span ID="litMaDon" runat="server"></span>
                    <span class="tk-trang-thai"><span ID="litTrangThai" runat="server"></span></span>
                </div>
            </div>


            <div class="ct-luoi">


                <section class="tk-khoi">
                    <h2>Sản phẩm</h2>
                    <div class="tk-bang-khung">
                        <table class="tk-bang tk-bang-sp">
                            <thead>
                                <tr><th>Sản phẩm</th><th>Đơn giá</th><th>SL</th><th>Thành tiền</th></tr>
                            </thead>
                            <tbody id="tbodyChiTietDonHang" runat="server"></tbody>
                        </table>
                    </div>
                </section>


                <section class="tk-khoi ct-phai">
                    <h2>Thông tin giao hàng</h2>
                    <dl class="tk-thong-tin">
                        <div><dt>Ngày đặt</dt><dd><span ID="litNgayDat" runat="server"></span></dd></div>
                        <div><dt>Người nhận</dt><dd><span ID="litNguoiNhan" runat="server"></span></dd></div>
                        <div><dt>Địa chỉ</dt><dd><span ID="litDiaChi" runat="server"></span></dd></div>
                        <div><dt>Thời gian nhận</dt><dd><span ID="litThoiGian" runat="server"></span></dd></div>
                        <div><dt>Thanh toán</dt><dd><span ID="litThanhToan" runat="server"></span></dd></div>
                        <div><dt>Ghi chú</dt><dd><span ID="litGhiChu" runat="server"></span></dd></div>
                    </dl>

                    <div class="tk-tong">
                        <div><span>Tạm tính</span><span><span ID="litTamTinh" runat="server"></span></span></div>
                        <div><span>Phí vận chuyển</span><span><span ID="litPhiShip" runat="server"></span></span></div>
                        <div><span>Giảm giá</span><span><span ID="litGiamGia" runat="server"></span></span></div>
                        <div class="tk-tong-cong"><span>Tổng cộng</span><span><span ID="litTongCong" runat="server"></span></span></div>
                    </div>
                    <div class="ct-hanh-dong">

    <span ID="lblThongBaoHuy"
        runat="server" class="ct-thong-bao">
    </span>

    <button ID="btnHuyDon"
        runat="server" class="ct-nut-huy" onserverclick="btnHuyDon_Click" onclick="return confirm('Bạn có chắc chắn muốn hủy đơn hàng này không?');"
        Visible="false" >Hủy đơn hàng</button>

</div>
                </section>

            </div>
        </div>
    </div>
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
