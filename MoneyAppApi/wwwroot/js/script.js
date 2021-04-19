$(document).ready(function () {

    $("a.demo-btn").click(function () {
        $(".form-wrapper").fadeIn();
    });

    $(".close-icon").click(function () {
        $(".form-wrapper").fadeOut();
    });

    $(".usp-content").hide();

    $(".usp-content:first").show();

    $(".service_icon:first").addClass("select icon3");

    $('.service_icon').click(function () {

        $('.service_icon').removeClass('select icon3');
        $(".usp-content").hide();
        $(this).addClass('select icon3');
      
        //$(".usp-content").fadeOut(5);

        // Get Selected Tab
        var activeTab = $(this).attr("data-href");  //Find the href attribute value to identify the active tab + content
        
        $(activeTab).fadeIn(1000); //Fade in the active ID content

        return false;
    });
});