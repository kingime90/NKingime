window.ui = window.ui || {};
/*
* 页签
*/
ui.tabs = (function (mod) {
    mod.frameLoad = function (frame) {
        var mainheight = $(frame).contents().find('body').height();
        $(frame).parent().height(mainheight);
    };
    mod.addTab = function (options) {
        var defaults = {
            container: {
                tabSelector: null,
                panelSelector: null,
            },
            tab: {
                itemId: null,
                itemName: null,
                itemUrl: null,
                closable: null,
            }
        };
        var opts = $.extend(true, {}, defaults, options);
        var itemId = mod.settings.itemPrefix + opts.tab.itemId;
        var panelId = mod.settings.panelPrefix + opts.tab.itemId;
        $('.ui-tabs-nav,.ui-tabs-panel').removeClass('active');
        var $tabItem = $('#' + itemId);
        if (!$tabItem || !$tabItem.length) {
            var tabItemHtml = '<li role="presentation" class="ui-tabs-nav" id="' + itemId + '"><a href="javascript:void(0);#' + panelId + '"  role="tab" data-toggle="tab" style="position:relative;padding:2px 20px 2px 15px;">' + opts.tab.itemName;
            if (opts.tab.closable) {
                tabItemHtml += '<i class="glyphicon glyphicon-remove small" tabclose="' + opts.tab.itemId + '" style="position: absolute;right:4px;top:4px;"  onclick="ui.tabs.closeTab(this);"></i></a></li> ';
            } else {
                tabItemHtml += '</a></li>';
            }
            var panelHtml = '<div role="tabpanel" class="tab-pane ui-tabs-panel" id="' + panelId + '" style="width:100%;height:100%;">' +
	    					  '<iframe src="' + opts.tab.itemUrl + '" frameborder="0" style="overflow-x:hidden;overflow-y:hidden;width:100%;height:100%;"></iframe>' +
	    				   '</div>';
            $(opts.container.tabSelector).append(tabItemHtml);
            $(opts.container.panelSelector).append(panelHtml);
        }
        $("#" + itemId).addClass("active");
        $("#" + panelId).addClass("active");
    };
    mod.closeTab = function (item) {
        var id = $(item).attr('tabclose');
        var itemId = mod.settings.itemPrefix + id;
        var panelId = mod.settings.panelPrefix + id;
        var $tabItem = $('#' + itemId);
        var $panel = $('#' + panelId);
        if ($panel.hasClass('active')) {
            $tabItem.prev().addClass('active');
            $panel.prev().addClass('active');
        }
        $tabItem.remove();
        $panel.remove();
    };
    mod.settings = {
        itemPrefix: 'tabs-nav-',
        panelPrefix: 'tabs-panel-'
    };
    return mod;
})(ui.tabs = ui.tabs || {});