document.addEventListener("DOMContentLoaded", function () {
    const typeSelector = document.getElementById("typeSelector");
    const specialFields = document.getElementById("specialFields");

    function toggleFields() {
        if (typeSelector.value === "Special") {
            specialFields.style.display = "block";
            // Hiệu ứng Fade in đơn giản
            specialFields.style.opacity = 0;
            setTimeout(() => { specialFields.style.transition = "opacity 0.5s"; specialFields.style.opacity = 1; }, 10);
        } else {
            specialFields.style.display = "none";
        }
    }

    typeSelector.addEventListener("change", toggleFields);

    // Kiểm tra ngay khi load (nếu có validation error quay lại)
    toggleFields();
});