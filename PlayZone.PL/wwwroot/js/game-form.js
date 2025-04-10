document.addEventListener('DOMContentLoaded', function () {
    const fileInput = document.querySelector('input[type="file"]');
    const previewImg = document.querySelector('.cover-preview');

    if (!fileInput || !previewImg) {
        return;
    }

    fileInput.addEventListener('change', function (e) {
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (event) {
                previewImg.src = event.target.result;
                previewImg.classList.remove('d-none');
            };
            reader.readAsDataURL(file);
        }
    });
});