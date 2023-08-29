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
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
        
    }
    );
});


$(document).ready(function () { $('time.timeago').timeago(); });


$(document).ready(function () {
    
 

        $('.select2').select2({
            placeholder: 'Select an option',
         
            maximumSelectionLength:1
        });
       
 });

$(document).ready(function () {
    $('#btn1').click(function () {
        $('input').attr('disabled', 'disabled');
    });
    $('#btn2').click(function () {
        $('input').removeAttr('disabled');
    });
});

$(document).ready(function () {
    document.getElementById('btnorganization').onclick = function () {
        var disabled = document.getElementById("txtorganization").disabled;
        if (disabled) {
            
            document.getElementById("txtorganization").disabled = false;
            document.getElementById("btnorganization").ariaValueText = "Save";
        } else {
            document.getElementById("txtorganization").disabled = true;
            document.getElementById("btn").textContent = "Update";
        }
    }
});

$(document).ready(function () { $('time.timeago').timeago(); });
$(document).ready(function () { $('.idCard').fittext(); });


//$(document).ready(function () {
//    $("#selectDocument").select2({
//        placeholder: "Select Document",
//        allowClear: true,

//    });
//    $("#selectRole").select2({
//        placeholder: "Select Roles",
//        allowClear: true,
//    });
//    $("#selectUser").select2({
//        placeholder: "Select Training Type",
//        allowClear: true,
//    });

//});

//google.maps.event.addDomListener(window, 'load', function () {
//    var places = new google.maps.places.Autocomplete(document.getElementById('<%=txtLocation.ClientID %>'));
//    google.maps.event.addListener(places, 'place_changed', function () {
//        var place = places.getPlace();
//        document.getElementById('<%=txtAddress.ClientID %>').value = place.formatted_address;
//    });})


 









$(document).ready(function () {
    tinymce.init({
        selector: 'textarea#additionalNotes',



        height: '400',
        plugins: [
            'advlist autolink lists link image charmap print preview anchor textcolor',
            'searchreplace visualblocks code fullscreen media Image',
            'insertdatetime media table contextmenu paste code help autoresize',],
        toolbar:
            'insert | undo redo | styleselect | bold italic backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help'
    });
});


$(document).ready(function () {
    tinymce.init({
        selector: 'textarea#detail',

        readonly: true,
        menubar: false,
        statusbar: false,
        toolbar: false,
        plugins: 'autoresize',
    });


});
$(function () {
    // SmartWizard initialize
    $('#smartwizard').smartWizard({
    theme:'arrows'});
});


$(function () {

    Webcam.set({
        width: 320,
        height: 240,
        image_format: 'jpeg',
        jpeg_quality: 90
    });
    Webcam.attach('#my_camera');
    $("#btnCapture").click(function () {
        Webcam.snap(function (data_uri) {
            $("#image")[0].src = data_uri;
            $("#image")[0].filename = "webcam.jpg";
          
        });

    })
})

$(document).ready( function Confirm() {
    
    $("#btnAddMember").click(function (e) {
        e.preventDefault();
        Swal.fire({ title: 'Swal Notification', icon: 'question', showButtonCancel: true, text:'Do you want to save changes?' }).then(result => { if (result.isConfirmed) { const memberForm = document.getElementById("AddMember"); memberForm.submit() } });


    })
})
  