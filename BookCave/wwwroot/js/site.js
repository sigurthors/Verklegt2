// Write your JavaScript code.

function checkPasswordMatch() {
    var password = $("#password").val();
    var confirmPassword = $("#passwordAgain").val();

    if (password != confirmPassword)
        $("#checkPasswordMatch").html("Lykilorð eru ekki eins!");
    else
        $("#checkPasswordMatch").html("Lykilorð eru eins");
}

$( document ).ready(function() {
    console.log("ready");
    $("#passwordAgain").keyup(checkPasswordMatch);

});