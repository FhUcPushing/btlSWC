document.addEventListener("DOMContentLoaded", function () {
    var nutMenu = document.querySelector(".menu-toggle");
    if (nutMenu) {
        nutMenu.addEventListener("click", function () {
            if (typeof toggleMobileMenu === "function") {
                toggleMobileMenu();
            }
        });
    }

    var nutTimKiem = document.querySelector(".header-search button");
    if (nutTimKiem) {
        nutTimKiem.addEventListener("click", function () {
            if (typeof xuLyTimKiem === "function") {
                xuLyTimKiem();
            }
        });
    }

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
