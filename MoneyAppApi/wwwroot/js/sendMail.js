$(document).ready(function () {
    $('#submit').click(function () {
        var Name = $("#fName").val(),
        Title = $("#title").val(),
        CompanyName = $("#company").val(),
        ContactNo = $("#mNumber").val(),
        EmailId = $("#emailId").val();
        if (Name != "" && Title != "" && CompanyName != "" && ContactNo != "" && EmailId != "") {
            $.ajax({
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'http://localhost:1069/cumulusinv.co.uk/send_mail.aspx/Submit_Details',
                data: '{Name: "' + Name +
                      '",Title: "' + Title +
                      '",CompanyName: "' + CompanyName +
                      '",ContactNo: "' + ContactNo +
                      '",EmailId: "' + EmailId + '"}'
            }).done(function (data) {
                if (data.d == "Success") {
                    alert('Thank You! Your Details have been sent. Our team will Contact you soon!')
                    clearForm();
                }
                else if (data.d == "Sending_Failed") {
                    alert('Unable to send details. Please try again.')
                    return;
                }
            }).fail(function (e) {
                alert(e);
            });
        } else {
            alert("Please fill the form");
            return false;
        };

    });
    
    function clearForm() {
        $("#fName").val("");
        $("#title").val("");
        $("#company").val("");
        $("#mNumber").val("");
        $("#emailId").val("");
    }
});