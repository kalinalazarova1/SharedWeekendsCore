$('#postReview').on('click', function () {
    var reviewsText = $('#reviewsCount').html();
    var reviewsIndex = reviewsText.indexOf(' reviews');
    var reviewsCount = parseInt(reviewsText.substr(0, reviewsIndex)) + 1;
    $('#reviewsCount').html(reviewsCount + ' reviews');
});

$('#review').on('click', function () {
    $('#review-form').show();
});

$('.fa-star').on('click', function () {
    var rating = $(this).data("rating");

    if ($(this).hasClass('fa-regular')) {
        $(this).removeClass('fa-regular').addClass('fa-solid');
    }
    $('.fa-star').each(function () {
        if ($(this).data("rating") < rating) {
            $(this).removeClass('fa-regular').addClass('fa-solid');
        } else if ($(this).data("rating") > rating) {
            $(this).removeClass('fa-solid').addClass('fa-regular');
        }
    });
    $('#rating-value').val(rating);
});