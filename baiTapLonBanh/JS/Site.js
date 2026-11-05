function laDienThoai() {
    return window.matchMedia("(max-width: 600px)").matches;
}
function toggleMobileMenu() {
    var menu = document.getElementById("mainNav");
    var nutMenu = document.querySelector(".menu-toggle");
    var khungTimKiem = document.getElementById("headerSearch");

    if (!menu || !nutMenu) return;
    if (khungTimKiem) khungTimKiem.classList.remove("is-open");

    var dangMo = menu.classList.toggle("is-open");

    nutMenu.setAttribute("aria-expanded", dangMo ? "true" : "false");
    nutMenu.setAttribute("aria-label", dangMo ? "Đóng menu" : "Mở menu");

    var icon = nutMenu.querySelector("i");
    if (icon) {
        icon.className = dangMo
            ? "fa-solid fa-xmark"
            : "fa-solid fa-bars";
    }
}

function xuLyTimKiem() {
    var khungTimKiem = document.getElementById("headerSearch");
    var oTimKiem = document.getElementById("txtTimKiem");

    if (!khungTimKiem || !oTimKiem) return;

    if (laDienThoai() && !khungTimKiem.classList.contains("is-open")) {
        var menu = document.getElementById("mainNav");
        if (menu && menu.classList.contains("is-open")) toggleMobileMenu();

        khungTimKiem.classList.add("is-open");
        oTimKiem.focus();
        return;
    }

    if (laDienThoai() && !oTimKiem.value.trim()) {
        khungTimKiem.classList.remove("is-open");
        return;
    }

    timKiemBanh();
}

function layDiaChiSanPham() {
    var khungTimKiem = document.getElementById("headerSearch");
    var diaChi = khungTimKiem ? khungTimKiem.getAttribute("data-url") : "";

    if (diaChi) return diaChi;

    var lienKet = document.querySelector('#mainNav a[href*="SanPham"]');

    if (lienKet) {
        return lienKet.href.split("?")[0].split("#")[0];
    }

    return "SanPham.aspx";
}
function timKiemBanh() {
    var oTimKiem = document.getElementById("txtTimKiem");

    if (!oTimKiem) return;

    var tuKhoa = oTimKiem.value.trim();

    if (!tuKhoa) {
        alert("Cậu hãy nhập tên bánh cần tìm nhé!");
        oTimKiem.focus();
        return;
    }

    window.location.href =
        layDiaChiSanPham() + "?q=" + encodeURIComponent(tuKhoa) + "#khuDanhSach";
}

document.addEventListener("DOMContentLoaded", function () {

  
    function chuanHoaDuongDan(p) {
        p = p.toLowerCase().replace(/\.aspx$/, "");
        if (p.endsWith("/default")) p = p.slice(0, -8);
        p = p.replace(/\/+$/, "");
        return p || "/";
    }

    var duongDanHienTai = chuanHoaDuongDan(window.location.pathname);

    document.querySelectorAll("#mainNav a").forEach(function (muc) {
        var duongDanMenu = chuanHoaDuongDan(new URL(muc.href).pathname);

        if (duongDanMenu === duongDanHienTai) {
            muc.classList.add("active");
            muc.setAttribute("aria-current", "page");
        } else {
            muc.classList.remove("active");
            muc.removeAttribute("aria-current");
        }
    });

    var oTimKiem = document.getElementById("txtTimKiem");

    if (oTimKiem) {
        oTimKiem.addEventListener("keydown", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                timKiemBanh();
            }
        });
    }

    document.addEventListener("click", function (event) {
        var khungTimKiem = document.getElementById("headerSearch");

        if (khungTimKiem && laDienThoai() &&
            !khungTimKiem.contains(event.target)) {
            khungTimKiem.classList.remove("is-open");
        }
    });

    var tuKhoaURL = new URLSearchParams(window.location.search).get("q");

    if (tuKhoaURL && oTimKiem) {
        oTimKiem.value = tuKhoaURL;
    }
});
window.addEventListener("resize", function () {
    if (window.innerWidth > 600) {
        var menu = document.getElementById("mainNav");
        var nutMenu = document.querySelector(".menu-toggle");
        var khungTimKiem = document.getElementById("headerSearch");

        if (menu) menu.classList.remove("is-open");
        if (khungTimKiem) khungTimKiem.classList.remove("is-open");

        if (nutMenu) {
            nutMenu.setAttribute("aria-expanded", "false");

            var icon = nutMenu.querySelector("i");

            if (icon) {
                icon.className = "fa-solid fa-bars";
            }
        }
    }
});