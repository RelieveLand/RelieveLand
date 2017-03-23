//$(document).ready (function (){
//    document.getElementById("mySidenav").style.width = "100%";
//})

/* Open the sidenav */
function openNav() {
    document.getElementById("mySidenav").style.width = "100%";
}

/* Close/hide the sidenav */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

$(document).ready(function () {

    $(".reviews").animate({ left: '0px' }, 1250);
    $(".text-over").delay(1250).animate({ right: '0px' }, 1250);
});

/*For Google API sign-in*/
//function onSignIn(googleUser) {
//    var profile = googleUser.getBasicProfile();
//    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
//    console.log('Name: ' + profile.getName());
//    console.log('Image URL: ' + profile.getImageUrl());
//    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
//}

