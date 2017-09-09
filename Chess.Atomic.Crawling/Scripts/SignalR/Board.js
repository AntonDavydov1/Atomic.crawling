$(function () {

    $.connection.boardHub.client.UpdateBoardBlack = function UpdateBoardBlack(data) {
        var b_canvas = document.getElementById("board");
        b_canvas.width = 256;
        var b_context = b_canvas.getContext("2d");

        var x = 0;
        var y = 0;


        for (var i = 0; i < data.curState.length; i++) {
            if (data.curState[i] == -1) continue;
            else if (data.curState[i] == 1) b_context.fillStyle = "#EEEEEE";
            else if (data.curState[i] == 2) b_context.fillStyle = "#111111";

            x = i % 8;
            //y = parseInt(i / 8);

            y = (i / 8 | 0);

            b_context.fillRect(x * 32, y * 32, 32, 32);
        }

        b_context.fillStyle = "#0000AA";
        b_context.fillRect(data.curHint.moveFrom.x * 32, data.curHint.moveFrom.y * 32, 32, 32);
        b_context.fillRect(data.curHint.moveTo.x * 32, data.curHint.moveTo.y * 32, 32, 32);

    }

    $.connection.boardHub.client.UpdateBoardWhite = function UpdateBoardWhite(data) {
        var b_canvas = document.getElementById("board");
        b_canvas.width = 256;
        var b_context = b_canvas.getContext("2d");

        var x = 0;
        var y = 0;


        for (var i = 0; i < data.curState.length; i++) {
            if (data.curState[i] == -1) continue;
            else if (data.curState[i] == 1) b_context.fillStyle = "#EEEEEE";
            else if (data.curState[i] == 2) b_context.fillStyle = "#111111";

            x = i % 8;
            //y = parseInt(i / 8);

            y = (i / 8 | 0);

            b_context.fillRect((7 - x) * 32, (7 - y) * 32, 32, 32);
        }

        b_context.fillStyle = "#0000AA";
        b_context.fillRect((7 - data.curHint.moveFrom.x) * 32, (7 - data.curHint.moveFrom.y) * 32, 32, 32);
        b_context.fillRect((7 - data.curHint.moveTo.x) * 32, (7 - data.curHint.moveTo.y) * 32, 32, 32);

    }



    $.connection.hub.start();
});