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
    $(".table").dataTable({
        buttons: [
            'copy', 'excel', 'pdf'
        ]
    }
    );
});


$(document).ready(function () { $('time.timeago').timeago(); });


$(document).ready(function () {
    
 

        $('.select2').select2({
            placeholder: 'Select an option'
        });
       
 });


    