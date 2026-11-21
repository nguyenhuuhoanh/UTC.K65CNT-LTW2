$(document).on('click', '.loai-link', function (e) {
    var box = $('#ds-hang-hoa');
    if (box.length == 0) return;
    e.preventDefault();
    $('.menu li').removeClass('active');
    $(this).parent().addClass('active');
    $.get('/Home/LocTheoLoai', { id: $(this).data('id') }, function (html) {
        box.html(html);
    });
});
