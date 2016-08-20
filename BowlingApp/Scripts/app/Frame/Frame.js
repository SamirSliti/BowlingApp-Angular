angular.module('frame', [])

.controller('FrameController', ['$http', function ($http) {
    var frame = this;

    frame.form = {};

    frame.frameResult = {};

    frame.showThirdInput = function (currentFrame) {
        var displayThirdInput = false;

        if (frame.frameResult != undefined && currentFrame == 10) {
            var first = parseInt(frame.frameResult.first, 10);
            var second = parseInt(frame.frameResult.second, 10);

            if (first == 10 || ((first + second) == 10)) {
                displayThirdInput = true;
            }
        }
        return displayThirdInput;
    };

    frame.addFrame = function (scoreBoard) {
        scoreBoard.currentFrame += 1;

        scoreBoard.frames.frames.push(frame.frameResult)

        $http({
            method: 'POST',
            url: '/api/HomeApi/CalculateScore',
            data: scoreBoard.frames

        }).then(function successCallback(response) {
            scoreBoard.score = response.data.score;

        }, function errorCallback(response) {
            alert("Error : " +  response.data.message);

        });

        frame.frameResult = {};
        frame.form.frameForm.$setPristine();
    };
}])