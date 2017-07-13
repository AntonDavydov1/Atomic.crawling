$(function () {

    $.connection.progressHub.client.update = function (vall, playerName) {
        $(".percentage[data-player='" + playerName + "']").html(vall);
    }

    $('.start').click(function () {
        $.connection.progressHub.server.crawling($(this).attr("data-player"));
    });


    $.connection.hub.start();
});