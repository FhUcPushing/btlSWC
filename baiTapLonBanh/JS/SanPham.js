/* ==========================================
   SANPHAM.JS - Trang sản phẩm (dùng GET)
   Lọc, sắp xếp, phân trang đều do server (SanPham.aspx.cs) xử lý
   qua query string:  ?loai=...&q=...&xem=...&sapxep=...&trang=...
   File này làm 2 việc:
   1. Đổi ô "Xem" hoặc "Sắp xếp" thì chuyển sang URL mới, giữ nguyên các tham số còn lại (kể cả từ khóa q).
   2. Bấm nút giỏ hàng thì thêm bánh bằng fetch (ThemGioHang.ashx), TRANG KHÔNG TẢI LẠI.
   ========================================== */
document.addEventListener("DOMContentLoaded", function () {
    var selectSoLuong = document.getElementById("soLuongHienThi");
    var selectSapXep = document.getElementById("sapXepSanPham");

    // Chuyển sang URL mới: cập nhật các tham số trong "thayDoi", bỏ tham số rỗng,
    // luôn bỏ "trang" để quay về trang 1 khi đổi lựa chọn.
    function chuyenTrang(thayDoi) {
        var thamSo = new URLSearchParams(window.location.search);

        thamSo.delete("trang");

        Object.keys(thayDoi).forEach(function (ten) {
            var giaTri = thayDoi[ten];

            if (giaTri === "" || giaTri === null) {
                thamSo.delete(ten);
            } else {
                thamSo.set(ten, giaTri);
            }
        });

        var chuoi = thamSo.toString();

        // #khuLoaiBanh: tải xong tự cuộn tới khu vực loại bánh + bộ lọc + danh sách
        window.location.href = window.location.pathname + (chuoi ? "?" + chuoi : "") + "#khuLoaiBanh";
    }

    // Đổi số lượng hiển thị (Xem)
    if (selectSoLuong) {
        selectSoLuong.addEventListener("change", function () {
            chuyenTrang({ xem: selectSoLuong.value });
        });
    }

    // Đổi cách sắp xếp
    if (selectSapXep) {
        selectSapXep.addEventListener("change", function () {
            chuyenTrang({ sapxep: selectSapXep.value });
        });
    }

    // ---------- THÊM VÀO GIỎ HÀNG (không tải lại trang) ----------
    var thongBao = document.getElementById("thongBaoGioHang");
    var henGioAn = null;

    function hienThongBao(noiDung, loi) {
        if (!thongBao) return;

        // Icon + chữ (dùng Font Awesome có sẵn trong site)
        thongBao.textContent = "";
        var icon = document.createElement("i");
        icon.className = loi ? "fa-solid fa-circle-exclamation" : "fa-solid fa-cart-shopping";
        var chu = document.createElement("span");
        chu.textContent = noiDung;
        thongBao.appendChild(icon);
        thongBao.appendChild(chu);
        thongBao.classList.toggle("loi", !!loi);

        // Bấm lần 2, 3... khi thông báo đang hiện: cho nó "nảy" lại để thấy rõ là đã thêm
        thongBao.classList.remove("an-thong-bao", "vua-them");
        void thongBao.offsetWidth;
        thongBao.classList.add("vua-them");

        clearTimeout(henGioAn);
        henGioAn = setTimeout(function () {
            thongBao.classList.add("an-thong-bao");
        }, 3000);
    }


    document.addEventListener("click", function (e) {
        var nut = e.target.closest(".nut-them-gio");
        if (!nut || !thongBao) return;

        e.preventDefault();

        var maBanh = nut.getAttribute("data-ma-banh");
        if (!maBanh) return;

        fetch(thongBao.getAttribute("data-url"), {
            method: "POST",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
            },
            body: "maBanh=" + encodeURIComponent(maBanh)
        })
            .then(function (res) {
                if (!res.ok) throw new Error("loi");
                return res.json();
            })
            .then(function () {
                hienThongBao("Bạn đã thêm vào giỏ hàng thành công!", false);
            })
            .catch(function () {
                hienThongBao("Không thêm được bánh, bạn thử lại nhé.", true);
            });
    });

    // NÚT LÊN ĐẦU TRANG
    var btnLenDau = document.getElementById("btnLenDauTrang");

    if (btnLenDau) {
        function capNhatNutLenDau() {
            if (window.scrollY > 300) {
                btnLenDau.classList.add("hien");
            } else {
                btnLenDau.classList.remove("hien");
            }
        }

        window.addEventListener("scroll", capNhatNutLenDau);

        btnLenDau.addEventListener("click", function () {
            window.scrollTo({
                top: 0,
                behavior: "smooth"
            });
        });

        capNhatNutLenDau();
    }
});
