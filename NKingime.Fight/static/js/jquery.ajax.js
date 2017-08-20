var _$ajax = (function (mod) {
    mod.get = function (options) {
        var settings = $.extend(true, {}, mod.defaults, options);
        settings.type = 'GET';
        $.ajax(settings);
    };
    mod.post = function (options) {
        var settings = $.extend(true, {}, mod.defaults, options);
        settings.type = 'POST';
        $.ajax(settings);
    };
    mod.defaults = {
        url: null,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        async: true,
        cache: false,
        data: null,
        type: null,
        dataType: 'json',
        global: true,
        timeout: 30000,
        beforeSend: function (XMLHttpRequest) {

        },
        complete: function (XMLHttpRequest, textStatus) {

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    };
    return mod;
})(window._$ajax || {});