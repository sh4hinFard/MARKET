"use strict";

// countdown timer
var daysEl = document.getElementById("days");
var hoursEl = document.getElementById("hours");
var minsEl = document.getElementById("mins");
var secondsEl = document.getElementById("seconds"); //

var daysEl2 = document.getElementById("days2");
var hoursEl2 = document.getElementById("hours2");
var minsEl2 = document.getElementById("mins2");
var secondsEl2 = document.getElementById("seconds2"); //

var daysEl3 = document.getElementById("days3");
var hoursEl3 = document.getElementById("hours3");
var minsEl3 = document.getElementById("mins3");
var secondsEl3 = document.getElementById("seconds3");
var newYears = "31 Dec 2023";

function countdown() {
  var newYearsDate = new Date(newYears);
  var currentDate = new Date();
  var totalSeconds = (newYearsDate - currentDate) / 1000;
  var days = Math.floor(totalSeconds / 3600 / 24);
  var hours = Math.floor(totalSeconds / 3600) % 24;
  var mins = Math.floor(totalSeconds / 60) % 60;
  var seconds = Math.floor(totalSeconds) % 60;
  daysEl.innerHTML = days;
  hoursEl.innerHTML = formatTime(hours);
  minsEl.innerHTML = formatTime(mins);
  secondsEl.innerHTML = formatTime(seconds); //

  daysEl2.innerHTML = days;
  hoursEl2.innerHTML = formatTime(hours);
  minsEl2.innerHTML = formatTime(mins);
  secondsEl2.innerHTML = formatTime(seconds); //

  daysEl3.innerHTML = days;
  hoursEl3.innerHTML = formatTime(hours);
  minsEl3.innerHTML = formatTime(mins);
  secondsEl3.innerHTML = formatTime(seconds);
}

function formatTime(time) {
  return time < 10 ? "0".concat(time) : time;
} // initial call


countdown();
setInterval(countdown, 1000);