<%@ Page Language="C#" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true"
    CodeBehind="ChiTietTinTuc.aspx.cs"
    Inherits="baiTapLonBanh.ChiTietTinTuc" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/ChiTietTinTuc.css" rel="stylesheet" type="text/css" />
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
            <div class="news-detail-page">


        <section id="thongTinTinTuc" runat="server"
            visible="false" class="chi_tiet_tin_tuc">


            <div class="khung_anh_tin_tuc">
                <img id="anhTinTuc"
                     runat="server"
                     class="anh_tin_tuc_chinh"
                     src="images/baiviet1.jpg"
                     alt="Ảnh bài viết"
                     onerror="this.parentNode.classList.add('khong-anh');" />
            </div>


            <div class="noi_dung_tin_tuc">

                <p id="loaiTinTuc" runat="server" class="loai_tin_tuc"></p>

                <h1 id="tieuDeTinTuc" runat="server"
                    class="tieu_de_tin_tuc"></h1>

                <div class="thong_tin_ngay_dang">
                    <span id="ngayDang" runat="server"></span>
                    <span id="thoiGianDoc" runat="server"></span>
                </div>

                <p id="moTaTinTuc" runat="server"
                    class="mo_ta_tin_tuc"></p>

                <div id="noiDungTinTuc" runat="server"
                    class="noi_dung_chi_tiet">
                </div>

            </div>

        </section>


        <p id="thongBaoLoi" runat="server"
            visible="false" class="thong_bao_loi">
            Không tìm thấy bài viết
        </p>


        <section id="khuVucBaiVietLienQuan" runat="server"
            class="bai-viet-lien-quan">

            <div class="bai-viet-header">
                <h2>CÓ THỂ BẠN CŨNG QUAN TÂM</h2>

                <a href="TinTuc.aspx" class="nut-xem-them">
                    Xem thêm
                    <i class="fa-solid fa-arrow-right"></i>
                </a>
            </div>

            <p id="thongBaoBaiViet" runat="server"
                visible="false" class="thong_bao_gio_hang"></p>

            <div class="danh-sach-bai-viet">

                <div id="rptBaiVietLienQuan" runat="server"></div>

            </div>

        </section>

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
