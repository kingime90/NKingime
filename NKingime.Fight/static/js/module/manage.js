$(function () {
    _$manage.setWidth();
    _$manage.setSidebar();
    _$manage.setCarousel();
})
$(window).resize(function () {
    _$manage.setWidth();
})
$(window).scroll(function () {
    _$manage.setScrollToTop();
});

/*
* init page when page load
*/
var _$manage = (function (mod) {
    mod.setCarousel = function () {
        try {
            $('.carousel').hammer().on('swipeleft', function () {
                $(this).carousel('next');
            });
            $('.carousel').hammer().on('swiperight', function () {
                $(this).carousel('prev');
            });
        } catch (e) {
            console.log("you mush import hammer.js and jquery.hammer.js to let the carousel can be touched on mobile");
        }
    };
    mod.setWidth = function () {
        if ($(window).width() < 768) {
            $(".sidebar").css({ left: -220 });
            $(".all").css({ marginLeft: 0 });
        } else {
            $(".sidebar").css({ left: 0 });
            $(".all").css({ marginLeft: 220 });
        }
    };
    mod.setScrollToTop = function () {
        var top = $(window).scrollTop();
        if (top < 60) {
            $('#goTop').hide();
        } else {
            $('#goTop').show();
        }
    };
    mod.setSidebar = function () {
        $('[data-target="sidebar"]').click(function () {
            var asideleft = $(".sidebar").offset().left;
            if (asideleft == 0) {
                $(".sidebar").animate({ left: -220 });
                $(".all").animate({ marginLeft: 0 });
            }
            else {
                $(".sidebar").animate({ left: 0 });
                $(".all").animate({ marginLeft: 220 });
            }
        });
        $(".has-sub>a").click(function () {
            $(this).parent().siblings().find(".sub-menu").slideUp();
            $(this).parent().find(".sub-menu").slideToggle();
        })
        var _strcurrenturl = window.location.href.toLowerCase();
        $(".navbar-nav a[href],.sidebar a[href]").each(function () {
            var href = $(this).attr("href").toLowerCase();
            var isActive = false;
            $(".breadcrumb>li a[href]").each(function (index) {
                if (href == $(this).attr("href").toLowerCase()) {
                    isActive = true;
                    return false;
                }
            })
            if (_strcurrenturl.indexOf(href) > -1 || isActive) {
                $(this).parent().addClass("active");
                if ($(this).parents("ul").attr("class") == "sub-menu") {
                    $(this).parents("ul").slideDown();
                    $(this).parents(".has-sub").addClass("active");
                }
            }
        })
    };
    /*
    *用户登出
    */
    mod.logout = function () {
        $.confirm({
            title: '温馨提示!',
            content: '确定要注销当前登录用户吗?',
            buttons: {
                confirm: {
                    text: '确定',
                    action: function () {
                        _$ajax.post({
                            url: '/User/Logout', success: function (data, textStatus) {
                                if (data.success === true) {
                                    //跳转并且不能后退
                                    window.location.replace('/User/Login');
                                }
                            }
                        });
                    }
                },
                cancel: {
                    text: '取消'
                }
            }
        });
    };
    return mod;
})(window._$manage || {});
