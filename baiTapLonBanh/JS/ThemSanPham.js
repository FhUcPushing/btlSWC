document.addEventListener("DOMContentLoaded", function () {

    var ten = document.getElementById("txtTenBanh");
    var gia = document.getElementById("txtGiaBanh");
    var loai = document.getElementById("ddlLoaiBanh");
    var moTa = document.getElementById("txtMoTa");
    var anh = document.getElementById("fuAnhBanh");

    var form = document.getElementById("form1");

    function baoLoi(id, noiDung) {
        document.getElementById(id).textContent = noiDung;
    }

    function kiemTra() {
        var hopLe = true;

        baoLoi("loiTenBanh", "");
        baoLoi("loiGiaBanh", "");
        baoLoi("loiLoaiBanh", "");
        baoLoi("loiMoTa", "");
        baoLoi("loiAnhBanh", "");

        if (ten.value.trim().length < 2 ||
            ten.value.trim().length > 100) {

            baoLoi("loiTenBanh",
                "Tên bánh phải có từ 2 đến 100 ký tự.");
            hopLe = false;
        }

        var giaTri = Number(gia.value);

        if (gia.value.trim() === "" ||
            !Number.isFinite(giaTri) ||
            giaTri <= 0 ||
            giaTri > 1000000000) {

            baoLoi("loiGiaBanh",
                "Giá bán phải lớn hơn 0 và không vượt quá 1 tỷ đồng.");
            hopLe = false;
        }

        if (loai.value === "") {
            baoLoi("loiLoaiBanh",
                "Vui lòng chọn loại bánh.");
            hopLe = false;
        }

        if (moTa.value.trim().length < 5 ||
            moTa.value.trim().length > 500) {

            baoLoi("loiMoTa",
                "Mô tả phải có từ 5 đến 500 ký tự.");
            hopLe = false;
        }

        if (!anh.files || anh.files.length === 0) {
            baoLoi("loiAnhBanh",
                "Vui lòng chọn ảnh sản phẩm.");
            hopLe = false;
        } else {
            var file = anh.files[0];
            var tenFile = file.name.toLowerCase();
            var duoiHopLe = /\.(jpg|jpeg|png|webp)$/.test(tenFile);

            if (!duoiHopLe) {
                baoLoi("loiAnhBanh",
                    "Ảnh phải có định dạng JPG, JPEG, PNG hoặc WEBP.");
                hopLe = false;
            }

            if (file.size > 5 * 1024 * 1024) {
                baoLoi("loiAnhBanh",
                    "Ảnh không được vượt quá 5 MB.");
                hopLe = false;
            }
        }

        return hopLe;
    }

    if (form) {
        form.addEventListener("submit", function (e) {
            if (!kiemTra()) {
                e.preventDefault();
            }
        });
    }
});