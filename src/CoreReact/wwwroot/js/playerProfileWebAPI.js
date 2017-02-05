//js wrapper-layer for external NBA stats REST API calls.
//sample player game log api call: http://stats.nba.com/stats/playergamelog/?PlayerID=201566&Season=2016-17&SeasonType=Regular%20Season
// y=getPlayerGameLogAJAX("201566","2016-17","Regular Season");
//KEEP IN MIND CROSS ORIGIN RESOURCE SHARING WHEN YOU ARE BUILDING OTHER STUFF/PUBLISHING TO PRODUCTION. 
function getPlayerGameLogAJAX(playerId, season, seasonType) {
    this.PlayerID = playerId;
    this.Season = season;
    this.SeasonType = seasonType;
    this.queryString = "?PlayerID=" + playerId + "&Season=" + season + "&SeasonType=" + seasonType;
    this.apiURL = "http://stats.nba.com/stats/playergamelog/" + this.queryString;

    return $.ajax({
            url: this.apiURL,
            success: function (result) {
                console.log("Player Game log AJAX Request successfully transmitted.");
                return result; // this return is for the "success" function call, not the return for the getPlayerGameLogAjax call.
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                console.log("Status: " + textStatus); alert("Error: " + errorThrown);
                return null;
            }
        });
   
}

function getObjectFromAJAX(ajaxResponse) {
    return JSON.parse(ajaxResponse.responseText);
}

function postJSONStringToServerAJAX(urlAction, playerJsonString) {
    $.ajax({
        url: urlAction,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: playerJsonString,
        error: function(response) {
            alert(response.responseText);
        },
        success: function(response) {
            alert(response);
        }

    });
}

$("#updateStats")
    .click(function() {
        var playerLogJson = getPlayerGameLogAJAX("201566", "2016-17", "Regular Season")
           .done(function (result) {
               var playerLogString = JSON.stringify([playerLogJson]);
                postJSONStringToServerAJAX("/PlayerProfiles/UpdateAverages", playerLogString);
                console.log(playerLogString);
                return result;
            });

        
    });

      