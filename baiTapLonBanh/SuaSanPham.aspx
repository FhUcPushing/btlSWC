<%@ Page Title="Sửa sản phẩm"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="SuaSanPham.aspx.cs"
    Inherits="baiTapLonBanh.SuaSanPham" %>
<!DOCTYPE html>
<html lang="vi">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SweetCake</title>

    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="fontawesome/css/all.min.css" />
    <link href="CSS/QuanTri.css"
          rel="stylesheet" />
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
            <div class="container admin-orders admin-add-product">

        <h1>Sửa sản phẩm</h1>
        <p>Cập nhật thông tin bánh của SweetCake.</p>

        <span ID="lblThongBao"
            runat="server" class="admin-message">
        </span>

        <div class="admin-product-form">

            <div class="admin-form-group">
                <label>Mã bánh</label>
                <span ID="lblMaBanh"
                    runat="server">
                </span>
            </div>

            <div class="admin-form-group">
                <label for="txtTenBanh">Tên bánh</label>

                <input ID="txtTenBanh"
                    runat="server"
                    ClientIDMode="Static" maxlength="100" type="text" />

                <span ID="loiTenBanh"
                    runat="server"
                    ClientIDMode="Static" class="admin-field-error">
                </span>
            </div>

            <div class="admin-form-group">
                <label for="txtGiaBanh">Giá bán (VNĐ)</label>

                <input ID="txtGiaBanh"
                    runat="server"
                    ClientIDMode="Static" type="number" />

                <span ID="loiGiaBanh"
                    runat="server"
                    ClientIDMode="Static" class="admin-field-error">
                </span>
            </div>

            <div class="admin-form-group">
                <label for="ddlLoaiBanh">Loại bánh</label>

                <select ID="ddlLoaiBanh"
                    runat="server">

                    <option value="">-- Chọn loại bánh --</option>

                    <option value="Bánh Mousse">Bánh Mousse</option>

                    <option value="Bánh Sinh Nhật">Bánh Sinh Nhật</option>

                    <option value="Bánh Kem">Bánh Kem</option>

                    <option value="Bánh Tươi">Bánh Tươi</option>

                    <option value="Bánh Mì">Bánh Mì</option>

                </select>

                <span ID="loiLoaiBanh"
                    runat="server"
                    ClientIDMode="Static" class="admin-field-error">
                </span>
            </div>

            <div class="admin-form-group">
                <label for="txtMoTa">Mô tả</label>

                <textarea ID="txtMoTa"
                    runat="server"
                    ClientIDMode="Static" rows="4" maxlength="500">
                </textarea>

                <span ID="loiMoTa"
                    runat="server"
                    ClientIDMode="Static" class="admin-field-error">
                </span>
            </div>

            <div class="admin-form-group">
                <label>Ảnh hiện tại</label>

                <img ID="imgAnhHienTai"
                    runat="server" class="admin-current-image" alt="Ảnh sản phẩm hiện tại"  />
            </div>

            <div class="admin-form-group">
                <label for="fuAnhBanh">Thay ảnh mới (không bắt buộc)</label>

                <input type="file" ID="fuAnhBanh"
                    runat="server"  />

                <small>
                    JPG, JPEG, PNG hoặc WEBP; tối đa 5 MB.
                    Không chọn ảnh mới thì giữ ảnh cũ.
                </small>

                <span ID="loiAnhBanh"
                    runat="server"
                    ClientIDMode="Static" class="admin-field-error">
                </span>
            </div>

            <div class="admin-product-actions">

                <button ID="btnCapNhat"
                    runat="server" class="admin-btn" onserverclick="btnCapNhat_Click" >Lưu thay đổi</button>

                <a href="QuanLySanPham.aspx"
                   class="admin-detail-link">
                    Quay lại
                </a>

            </div>

        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var form = document.getElementById("form1");
            var ten = document.getElementById("txtTenBanh");
            var gia = document.getElementById("txtGiaBanh");
            var loai = document.getElementById("ddlLoaiBanh");
            var moTa = document.getElementById("txtMoTa");
            var anh = document.getElementById("fuAnhBanh");

            function baoLoi(id, noiDung) {
                document.getElementById(id).textContent = noiDung;
            }

            if (form) {
                form.addEventListener("submit", function (e) {
                    var hopLe = true;

                    baoLoi("loiTenBanh", "");
                    baoLoi("loiGiaBanh", "");
                    baoLoi("loiLoaiBanh", "");
                    baoLoi("loiMoTa", "");
                    baoLoi("loiAnhBanh", "");

                    var tenBanh = ten.value.trim();
                    var giaBanh = Number(gia.value);
                    var moTaBanh = moTa.value.trim();

                    if (tenBanh.length < 2 || tenBanh.length > 100) {
                        baoLoi("loiTenBanh",
                            "Tên bánh phải có từ 2 đến 100 ký tự.");
                        hopLe = false;
                    }

                    if (gia.value.trim() === "" ||
                        !Number.isFinite(giaBanh) ||
                        giaBanh <= 0 ||
                        giaBanh > 1000000000) {
                        baoLoi("loiGiaBanh", "Giá bán không hợp lệ.");
                        hopLe = false;
                    }

                    if (loai.value === "") {
                        baoLoi("loiLoaiBanh", "Vui lòng chọn loại bánh.");
                        hopLe = false;
                    }

                    if (moTaBanh.length > 500 ||
                        (moTaBanh.length > 0 && moTaBanh.length < 5)) {
                        baoLoi("loiMoTa",
                            "Mô tả để trống hoặc có từ 5 đến 500 ký tự.");
                        hopLe = false;
                    }

                    if (anh.files && anh.files.length > 0) {
                        var file = anh.files[0];

                        if (!/\.(jpg|jpeg|png|webp)$/i.test(file.name)) {
                            baoLoi("loiAnhBanh",
                                "Ảnh phải là JPG, JPEG, PNG hoặc WEBP.");
                            hopLe = false;
                        }

                        if (file.size <= 0 ||
                            file.size > 5 * 1024 * 1024) {
                            baoLoi("loiAnhBanh",
                                "Ảnh phải lớn hơn 0 và không vượt quá 5 MB.");
                            hopLe = false;
                        }
                    }

                    if (!hopLe) {
                        e.preventDefault();
                    }
                });
            }
        });
    </script>
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
