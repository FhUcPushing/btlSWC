document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".tk-truong .tk-o").forEach(function (o) {
        o.addEventListener("input", function () {
            var loi = o.parentNode.querySelector(".tk-loi");
            if (loi) loi.textContent = "";
            o.classList.remove("tk-o-loi");
        });
    });
});