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

    this.ajaxResponse =
        $.ajax({
            url: this.apiURL,
            success: function (result) {
                console.log("Player Game log AJAX Request successfully transmitted.");
                return result;
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                console.log("Status: " + textStatus); alert("Error: " + errorThrown);
                return null;
            }
        });

    return ajaxResponse;
}

function getObjectFromAJAX(ajaxResponse) {
    return JSON.parse(ajaxResponse.responseText);
}