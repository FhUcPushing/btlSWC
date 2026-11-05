<%@ Page Title="Trang chủ" Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="baiTapLonBanh.TrangChu" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/TrangChu.css"
      rel="stylesheet" type="text/css" />
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
            <div id="thongBaoGioHang"
         class="thong-bao-gio-hang an-thong-bao"
         role="status"
         aria-live="polite"
         data-url='ThemGioHang.ashx'></div>


    <section class="cake-hero">
        <img class="hero-bg" src="product-banner.png"
             alt="Bộ sưu tập bánh ngọt SweetCake" />

        <div class="hero-overlay"></div>

        <div class="hero-inner">
            <div class="hero-copy">

                <div class="hero-actions">
                    <a href="#san-pham" class="btn-primary">
                        <i class="fa-solid fa-cake-candles"></i>
                        Khám phá ngay
                        <i class="fa-solid fa-arrow-right"></i>
                    </a>
                </div>

                <div class="hero-points">
                    <div>
                        <i class="fa-solid fa-leaf"></i>
                        <span>Nguyên liệu chọn lọc</span>
                    </div>
                    <div>
                        <i class="fa-solid fa-heart"></i>
                        <span>Làm bánh bằng yêu thương</span>
                    </div>
                    <div>
                        <i class="fa-solid fa-gift"></i>
                        <span>Quà tặng ngọt ngào</span>
                    </div>
                </div>

            </div>
        </div>
    </section>


    <section class="products section-wrap" id="san-pham">
        <div class="section-title">
            <div>
                <h2>Sản phẩm nổi bật <i class="fa-solid fa-heart"></i></h2>
                <p>Những chiếc bánh ngọt ngào được yêu thích tại SweetCake.</p>
            </div>
            <a href="SanPham.aspx" class="view-all">
                Xem tất cả <i class="fa-solid fa-arrow-right"></i>
            </a>
        </div>

        <div class="product-list">

            <div id="rptSanPhamNoiBat" runat="server"></div>

        </div>
    </section>



    <section class="benefits">
        <div class="benefits-intro">
            <span class="section-kicker">DỊCH VỤ CỦA CHÚNG TÔI</span>
            <h2>Ngọt ngào trọn vẹn hơn</h2>
            <p>Chăm chút từng chiếc bánh để niềm vui của bạn thêm trọn vẹn.</p>
        </div>

        <div class="benefit-item">
            <i class="fa-solid fa-leaf"></i>
            <h3>Nguyên liệu chọn lọc</h3>
            <p>Chú trọng chất lượng trong từng chiếc bánh.</p>
        </div>

        <div class="benefit-item">
            <i class="fa-solid fa-cake-candles"></i>
            <h3>Bánh tươi mỗi ngày</h3>
            <p>Đa dạng hương vị cho mọi dịp đặc biệt.</p>
        </div>

        <div class="benefit-item">
            <i class="fa-solid fa-truck-fast"></i>
            <h3>Giao hàng tiện lợi</h3>
            <p>Giúp món quà ngọt ngào đến gần bạn hơn.</p>
        </div>

        <div class="benefit-item">
            <i class="fa-solid fa-headset"></i>
            <h3>Tư vấn tận tâm</h3>
            <p>Cùng bạn chọn chiếc bánh phù hợp.</p>
        </div>
    </section>



    <section class="products fresh-section section-wrap" id="banh-tuoi">
        <div class="section-title">
            <div>
                <span class="section-kicker">TƯƠI NGON MỖI NGÀY</span>
                <h2>Bánh tươi <i class="fa-solid fa-bread-slice"></i></h2>
                <p>Món ngon nhỏ xinh cho bữa sáng và giờ nghỉ ngọt ngào.</p>
            </div>
            <a href="SanPham.aspx" class="view-all">
                Xem tất cả <i class="fa-solid fa-arrow-right"></i>
            </a>
        </div>

        <div class="product-list">

            <div id="rptBanhTuoi" runat="server"></div>

        </div>
    </section>



    <section class="story-section">
        <div class="story-card">
            <div class="story-photo">
                <img src="image/TrangChu/cacloai_TC.jpg" alt="Những chiếc bánh ngọt SweetCake" />
            </div>
            <div class="story-copy">
                <span class="section-kicker">VÌ SAO CHỌN SWEETCAKE?</span>
                <h2>Hơn cả một chiếc bánh</h2>
                <p>
                    Chúng tôi tin rằng những điều nhỏ bé có thể tạo nên
                    niềm vui lớn. Mỗi chiếc bánh là một lời chúc ngọt ngào
                    dành cho những người bạn yêu quý.
                </p>
                <a href="GioiThieu.aspx" class="text-link">
                    Tìm hiểu về chúng tôi
                    <i class="fa-solid fa-arrow-right"></i>
                </a>
                <div class="story-icons">
                    <span><i class="fa-solid fa-leaf"></i> Chọn lọc</span>
                    <span><i class="fa-solid fa-heart"></i> Tận tâm</span>
                    <span><i class="fa-solid fa-gift"></i> Ý nghĩa</span>
                </div>
            </div>
        </div>

        <div class="testimonial-card">
            <span class="section-kicker">LỜI YÊU THƯƠNG</span>
            <h2>Khách hàng nói gì?</h2>
            <div class="quote-icon"><i class="fa-solid fa-quote-left"></i></div>
            <p class="quote-text">
                Bánh rất đẹp, vị ngọt vừa phải và được chuẩn bị chỉn chu.
                Mình rất thích phong cách nhẹ nhàng của SweetCake!
            </p>
            <div class="customer">
                <span class="customer-avatar">
                    <i class="fa-solid fa-user"></i>
                </span>
                <div>
                    <strong>Khách hàng SweetCake</strong>
                    <div class="stars">
                        <i class="fa-solid fa-star"></i>
                        <i class="fa-solid fa-star"></i>
                        <i class="fa-solid fa-star"></i>
                        <i class="fa-solid fa-star"></i>
                        <i class="fa-solid fa-star"></i>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="news" id="bai-viet">
        <div class="section-title">
            <div>
                <span class="section-kicker">CHUYỆN NHÀ SWEETCAKE</span>
                <h2>Bài viết mới nhất <i class="fa-regular fa-newspaper"></i></h2>
                <p>Tin tức, bộ sưu tập bánh và những ưu đãi dành cho bạn.</p>
            </div>
        </div>

        <div class="news-list">


<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=7">
            <img src="image/TrangChu/baiviet4_TC.jpg" alt="Ngọt ngào gửi trao" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-heart"></i> Câu chuyện ngọt ngào
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=7" class="news-title-link">
                NGỌT NGÀO GỬI TRAO BÁNH KEM CHO NGÀY ĐẶC BIỆT
            </a>
        </h3>

        <p>Một chiếc bánh kem có thể trở thành món quà yêu thương dành cho những người thân yêu.</p>
    </div>
</article>



<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=8">
            <img src="image/TrangChu/banhtrungthu_TC.jpg"
                 alt="Mua 1 tặng 1 bánh Trung Thu" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-gift"></i> Ưu đãi
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=8" class="news-title-link">
                MUA 1 TẶNG 1 BÁNH TRUNG THU SWEETCAKE
            </a>
        </h3>

        <p>Chương trình từ 25/09 đến 10/10/2026 theo nội dung ưu đãi của cửa hàng.</p>
    </div>
</article>


<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=9">
            <img src="image/TrangChu/banhtrungthu2_TC.jpg"
                 alt="Bánh Trung Thu ưu đãi 15%" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-tag"></i> Khuyến mãi
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=9" class="news-title-link">
                BÁNH TRUNG THU SWEETCAKE 2026 - ƯU ĐÃI 15%
            </a>
        </h3>

        <p>Khám phá bộ sưu tập bánh Trung Thu với chương trình ưu đãi đặc biệt.</p>
    </div>
</article>


<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=10">
            <img src="image/TrangChu/hop_TC.jpg"
                 alt="Ưu đãi hộp quà Trung Thu" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-gift"></i> Quà tặng
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=10" class="news-title-link">
                ƯU ĐÃI 20% HỘP QUÀ TRUNG THU
            </a>
        </h3>

        <p>Hộp quà đẹp mắt và sang trọng để gửi trao lời chúc đến gia đình, bạn bè.</p>
    </div>
</article>


<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=11">
            <img src="image/TrangChu/baiviet5_TC.jpg"
                 alt="Mua 3 tính tiền 2" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-percent"></i> Ưu đãi đặc biệt
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=11" class="news-title-link">
                MUA 3 TÍNH TIỀN 2
            </a>
        </h3>

        <p>Thêm niềm vui với chương trình ưu đãi dành cho khách hàng.</p>
    </div>
</article>



<article class="news-item">
    <div class="news-image">
        <a href="ChiTietTinTuc.aspx?id=12">
            <img src="image/TrangChu/banhtrungthu3_TC.jpg"
                 alt="12 hương vị cao cấp" />
        </a>
    </div>

    <div class="news-content">
        <span class="news-category">
            <i class="fa-solid fa-moon"></i> Bộ sưu tập
        </span>

        <h3>
            <a href="ChiTietTinTuc.aspx?id=12" class="news-title-link">
                12 HƯƠNG VỊ CAO CẤP TUYỂN CHỌN
            </a>
        </h3>

        <p>Khám phá những hương vị bánh Trung Thu đặc biệt dành cho mùa trăng.</p>
        </div>
</article>

</div>
</section>


<section class="member-banner">
        <div class="member-icon">
            <i class="fa-solid fa-gift"></i>
        </div>
        <div class="member-copy">
            <span>ĐẶC QUYỀN DÀNH RIÊNG CHO BẠN</span>
            <h2>Tham gia gia đình SweetCake</h2>
            <p>Cùng khám phá những chiếc bánh yêu thích và ưu đãi mới.</p>
        </div>
        <a href="DangKy.aspx" class="member-button">
            Đăng ký ngay
            <i class="fa-solid fa-arrow-right"></i>
        </a>
    </section>

    <script src="JS/TrangChu.js"></script>
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
