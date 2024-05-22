document.addEventListener("DOMContentLoaded", function() {
    const burgerMenu = document.getElementById("burgerMenu");
    const menu = document.getElementById("menu");

    burgerMenu.addEventListener("click", function() {
        menu.classList.toggle("d-flex");
    });
});



window.onscroll = function() {
    var navbar = document.getElementById("navbar");
    if (window.pageYOffset > 100) {
        navbar.classList.add("fixed");
    } else {
        navbar.classList.remove("fixed");
    }
};

$('.dropdown-toggle').on('click', function(e) {
    // e.preventDefault();
    $(this).children('.dropdown').toggleClass('active');
});