var analyser = require("./analyse_data.js");
var _ = require('underscore');

//analyser.loadCsv(__dirname+"/DL-timelog-all.csv", function(data) {
analyser.loadCsv(__dirname+"/DL-timelog-all.csv", function(data) {
   var groups = analyser.extractGroups(data);
   _(groups).each(function(groupData, groupName) {
       console.log(groupName + " : " + groupData.totalTimeInMins);
   });
   console.log(groups['undefined']);
})
