<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GioiThieu.aspx.cs" Inherits="baiTapLonBanh.GioiThieu" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/GioiThieu.css"
          rel="stylesheet"
          type="text/css" />
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
            <div class="gioi-thieu">


        <div class="tieu-de">
            VỀ SWEETCAKE
        </div>



        <div class="mo-dau">

            <p class="doan-dam">
                <span>SweetCake</span> là thương hiệu bánh ngọt mang đến
                những sản phẩm thơm ngon, đẹp mắt và phù hợp với nhiều
                dịp đặc biệt trong cuộc sống.
            </p>

            <p>
                Với mong muốn mang đến những chiếc bánh chất lượng cao,
                SweetCake luôn chú trọng từ khâu lựa chọn nguyên liệu,
                chế biến đến trang trí sản phẩm.
            </p>

            <p>
                Mỗi chiếc bánh được tạo nên bằng sự tỉ mỉ và tâm huyết,
                giúp khách hàng có những trải nghiệm ngọt ngào và đáng nhớ
                trong những dịp đặc biệt.
            </p>

        </div>



        <div class="banner-gioi-thieu">
            <img src="image/GioiThieu/thanh_lap.jpg"
                 alt="SweetCake" />
        </div>



        <section class="noi-dung">

            <h2>THÀNH LẬP</h2>
            <img src="image/GioiThieu/anh3_GT.jpg"
     alt="Quá trình thành lập SweetCake"
     class="anh-gioi-thieu" />
            <p>
                SweetCake được thành lập từ niềm đam mê mãnh liệt với nghệ thuật làm bánh thủ công và mong muốn tạo dựng một địa chỉ tin cậy dành cho những người yêu thích bánh ngọt. Bắt đầu từ những mẻ bánh nhỏ đong đầy tình yêu gửi tới người thân và bạn bè, chúng mình nhanh chóng nhận ra sức mạnh kỳ diệu của từng chiếc bánh trong việc kết nối cảm xúc và lưu giữ những kỷ niệm đẹp.
            </p>

            <p>
               Hành trình của SweetCake bắt đầu từ một căn bếp nhỏ ấm cúng, nơi những mẻ bánh đầu tiên ra đời bằng tất cả tình yêu gửi gắm tới người thân và bạn bè. Chính niềm vui, sự xúc động của người nhận khi cầm trên tay những chiếc bánh thơm nức đã trở thành nguồn động lực to lớn giúp SweetCake không ngừng vươn xa.
            </p>

            <p>
                Trải qua một chặng đường dài nỗ lực nghiên cứu công thức, lắng nghe từng góp ý của khách hàng và hoàn thiện chất lượng dịch vụ, SweetCake đã từng bước khẳng định vị thế của mình. Ngày nay, SweetCake tự hào là thương hiệu bánh tươi uy tín, nơi mỗi chiếc bánh đều được tạo nên từ sự chu đáo, tỉ mỉ và tình yêu trọn vẹn dành cho nghề.
            </p>

        </section>



        <section class="noi-dung">

            <h2>NHIỆM VỤ</h2>
                     <img src="image/GioiThieu/anh7_GT.jpg"
                        alt="Nhiệm vụ của SweetCake"
                        class="anh-gioi-thieu" />
            <p>
                Nhiệm vụ của SweetCake là mang đến cho khách hàng những chiếc bánh ngọt tươi mới, an toàn và chuẩn vị mỗi ngày. Chúng mình không chỉ trao đến tay bạn một món ăn ngon, mà còn gửi gắm vào đó niềm vui, sự trân trọng và những lời chúc tốt đẹp nhất dành cho những dịp đặc biệt trong cuộc sống.
            </p>

        </section>





    <section class="noi-dung">
        <h2>CAM KẾT KINH DOANH</h2>

        <img src="image/GioiThieu/anh4_GT.jpg"
             alt="Cam kết chất lượng bánh SweetCake"
             class="anh-gioi-thieu" />

        <p>
            SweetCake luôn đặt chất lượng sản phẩm và sự hài lòng
            của khách hàng lên hàng đầu. Vì vậy, chúng tôi cam kết
            mang đến những sản phẩm bánh tươi ngon, an toàn và phù hợp
            với nhu cầu của khách hàng:
        </p>

        <div class="cam-ket-item">
            <strong>✓ Bánh tươi mới 100% trong ngày:</strong>
            Bánh chỉ được chế biến sau khi nhận đơn hoặc sản xuất
            giới hạn trong ngày, cam kết không bán bánh cũ, không
            sử dụng hàng lưu kho qua đêm.
        </div>

        <div class="cam-ket-item">
            <strong>✓ Công thức giảm ngọt độc quyền:</strong>
            Đảm bảo cốt bánh mềm mịn, lớp kem béo ngậy thanh nhẹ,
            độ ngọt vừa phải, phù hợp với xu hướng ăn uống lành mạnh
            của mọi lứa tuổi.
        </div>

        <div class="cam-ket-item">
            <strong>✓ Giao hàng an toàn &amp; đúng hẹn:</strong>
            Hệ thống đóng gói chuyên dụng và đội ngũ giao hàng cẩn thận
            giúp chiếc bánh giữ nguyên hình dáng hoàn hảo và đến tay
            bạn đúng khung giờ yêu cầu.
        </div>

        <div class="cam-ket-item">
            <strong>✓ Minh bạch &amp; trách nhiệm:</strong>
            Công khai rõ ràng nguồn gốc nguyên liệu, giá thành niêm yết
            minh bạch và sẵn sàng hỗ trợ giải quyết mọi phản hồi của
            khách hàng một cách nhanh chóng nhất.
        </div>
    </section>




    <section class="ket-thuc">
        <h2>CÙNG SWEETCAKE TẠO NÊN NHỮNG KỶ NIỆM NGỌT NGÀO!</h2>
        <img src="image/GioiThieu/anh5_GT.png"
     alt="Những chiếc bánh ngọt SweetCake"
     class="anh-gioi-thieu" />
        <p>
            "Dù bạn đang tìm kiếm một chiếc bánh sinh nhật lộng lẫy
            cho buổi tiệc lớn, một chiếc bánh kỷ niệm lãng mạn hay
            chỉ đơn giản muốn tự thưởng cho bản thân một lát bánh
            ngọt nhẹ nhàng sau ngày làm việc bận rộn, SweetCake
            luôn sẵn sàng đồng hành".
        </p>

        <p>
            Hãy để chúng mình có cơ hội biến mỗi khoảnh khắc thường
            ngày của bạn trở nên ấm áp, ngọt ngào và đáng nhớ hơn
            bao giờ hết!
        </p>
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
