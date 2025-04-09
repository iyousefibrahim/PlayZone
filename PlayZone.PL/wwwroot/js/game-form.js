javascript// Add this to your game-form.js file
$(document).ready(function () {
    // Image preview functionality
    $('input[type="file"]').change(function () {
        const file = this.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                // Update the image preview
                $('.cover-preview').attr('src', e.target.result);
                $('.cover-preview').removeClass('d-none');
            }
            reader.readAsDataURL(file);
        }
    });
});