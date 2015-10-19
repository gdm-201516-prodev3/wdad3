//NAMELESS FUNCTION - AUTO EXECUTED WHEN DOCUMENT IS LOADED
(function () {

    //PUSH SIDEBAR
    var sidebar = $('#sidebar'),
        main = $('#main'),
        sidebarToggle = $('.sidebar-toggle');

    if (Modernizr.csstransforms3d) {
        sidebarToggle.on('click', function (e) {
            e.preventDefault();
            toggleSidebar();
            return false;
        });
    } else {

    }

    //TOGGLE SIDEBAR AND MAIN
    function toggleSidebar() {
        main.toggleClass('main-push');
        sidebar.toggleClass('sidebar-push-left sidebar-push-open')
    }

    //UI
    function refreshUI() {
        if ($(window).width() >= 800) {
            $('#sidebar').removeClass('sidebar-push-open');
            $('#sidebar').removeClass('sidebar-push-left');
            $('#main').removeClass('main-push');
            $('#main').addClass('main-full');
            $('.sidebar-toggle').addClass('hidden');
        } else {
            $('.sidebar-toggle').removeClass('hidden');
            $('#sidebar').addClass('sidebar-push-left');
            $('#main').removeClass('main-full');
        }
    }

    //SUMENU COLLAPSE
    $('.submenu').on('click', function (ev) {
        if ($(this).hasClass('open')) {
            $(this).find('ul').animate({
                height: "toggle"
            }, 360, function () {
                $(this).parent().removeClass('open');
            });
        } else {
            $.each($(this).parent().find('.submenu.open'), function (key, obj) {
                $(obj).find('ul').animate({
                    height: "toggle"
                }, 360, function () {
                    $(this).parent().removeClass('open');
                });
            });
            $(this).find('ul').animate({
                height: "toggle"
            }, 360, function () {
                $(this).parent().addClass('open');
            });
        }
    });

    //Resize Window
    $(window).on('resize', function (ev) {
        refreshUI();
    });

    refreshUI();
})();