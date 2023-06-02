$(document).ready(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $(' button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURI(url);
        $.get(decodeUrl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
});
$(document).ready(function () {
    $(".table").dataTable(


    );
})


$(document).ready(function () { $('time.timeago').timeago(); });


$(document).ready(function () {
    $("#category").select2({
        placeholder: "Select Category",
        allowClear: true,

    });
    $("#selectRole").select2({
        placeholder: "Select Roles",
        allowClear: true,
    });
    $("#selectUser").select2({
        placeholder: "Select User",
        allowClear: true,
    });

});
