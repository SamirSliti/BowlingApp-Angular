angular.module('bowling', [])

.controller('BowlingController', function () {
    var bowling = this;

    bowling.scoreBoard = {};

    bowling.scoreBoard.frames = { frames: [] };

    bowling.scoreBoard.score = 0;

    bowling.scoreBoard.currentFrame = 1;
})



