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