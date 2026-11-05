/* ==========================================
   TRANGCHU.JS - Thêm vào giỏ hàng không tải lại trang
   Bấm nút giỏ hàng (.add-cart) -> gọi ThemGioHang.ashx bằng fetch
   -> hiện thông báo nhỏ ở góc phải, tự ẩn sau 3 giây.
   ========================================== */
document.addEventListener("DOMContentLoaded", function () {
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

        // Bấm nhiều lần khi thông báo đang hiện: cho nó "nảy" lại để thấy rõ
        thongBao.classList.remove("an-thong-bao", "vua-them");
        void thongBao.offsetWidth;
        thongBao.classList.add("vua-them");

        clearTimeout(henGioAn);
        henGioAn = setTimeout(function () {
            thongBao.classList.add("an-thong-bao");
        }, 2000);
    }

    document.addEventListener("click", function (e) {
        var nut = e.target.closest(".add-cart");
        if (!nut || !thongBao) return;

        e.preventDefault();

        var maBanh = nut.getAttribute("data-ma-banh");
        if (!maBanh) return;

        fetch(thongBao.getAttribute("data-url"), {
            method: "POST",
            credentials: "same-origin",
            headers: { "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8" },
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
});