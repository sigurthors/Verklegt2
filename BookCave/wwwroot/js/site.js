// Write your JavaScript code.

function checkPasswordMatch() {
    var password = $("#password").val();
    var confirmPassword = $("#passwordAgain").val();

    if (password != confirmPassword)
        $("#checkPasswordMatch").html("Lykilorð eru ekki eins!");
    else
        $("#checkPasswordMatch").html("Lykilorð eru eins");
}

function checkPasswordLength() {
    var password = $("#password").val();
    var message = $("#passwordLengthMessage");

    if(password.length <= 5) {
        message.html("Lykilorð þarf að vera að minnsta kosti 6 stafir");
    }
    else if(password.length > 5) {
        message.html("");
    }
}

$( document ).ready(function() {
    console.log("ready");
    $("#passwordAgain").keyup(checkPasswordMatch);
    $("#password").keyup(checkPasswordLength);
});

$('.carousel').carousel({
    interval: 3000
  })
  $('.carousel2').carousel({
    interval: 3000
  })

  $('.carousel .item').each(function(){
    var next = $(this).next();
    if (!next.length) {
      next = $(this).siblings(':first');
    }
    next.children(':first-child').clone().appendTo($(this));
    
    if (next.next().length>0) {
      next.next().children(':first-child').clone().appendTo($(this));
    }
    else {
        $(this).siblings(':first').children(':first-child').clone().appendTo($(this));
    }
  });
  
  $(document).ready(function(){
    console.log("ready");
    $('#data').after('<div id="nav"></div>');
    var rowsShown = 10;
    var rowsTotal = $('#data tbody tr').length;
    var numPages = rowsTotal/rowsShown;
    for(i = 0;i < numPages;i++) {
        var pageNum = i + 1;
        $('#nav').append('<a href="#" rel="'+i+'">'+pageNum+'</a> ');
    }
    $('#data tbody tr').hide();
    $('#data tbody tr').slice(0, rowsShown).show();
    $('#nav a:first').addClass('active');
    $('#nav a').bind('click', function(){

        $('#nav a').removeClass('active');
        $(this).addClass('active');
        var currPage = $(this).attr('rel');
        var startItem = currPage * rowsShown;
        var endItem = startItem + rowsShown;
        $('#data tbody tr').css('opacity','0.0').hide().slice(startItem, endItem).
        css('display','table-row').animate({opacity:1}, 300);
    });
});