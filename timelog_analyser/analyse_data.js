var csv = require('csv');
var _ = require('underscore');

exports.loadCsv = function(absolutePath, onReadComplete) {
    var allData = [];
    csv()
            .fromPath(absolutePath)
            .on('data', function(data, index) {
                allData.push(data);
                //console.log('#'+index+' '+JSON.stringify(data));
            })
            .on('end', function(count) {
                //console.log('Number of lines: '+count);
                onReadComplete(allData);
            })
            .on('error', function(error) {
                console.log(error.message);
            });
};

exports.extractGroups = function(csvData) {
    csvData.shift(); //drop the header
    var allMemos = _(csvData).chain()
            .map(function(item) {
                if (!item[3]) return ['00:00 - [empty] nothing happened'];
                return item[3].split('\n'); // position 4 is the memo field
            })
            .flatten()
            .value();
    allMemos = _(allMemos).chain()
            .map(function (item) {
                var piece = item.split(/( - \[)|(] )/);
                var timePieces = piece[0].split(/:/);
                return { category: _.isUndefined(piece[3]) ? "undefined" : piece[3].trim().toLowerCase(),
                    time: piece[0],
                    timeInMins : 60 * parseInt(timePieces[0]) + parseInt(timePieces[1]),
                    notes: piece[6],
                    orig: item
                };
            })
            .value();
    var grouped = {};
    _(allMemos).each(function(item) {
        var k = item['category'];
        var v = grouped[k];
        if (!v) v = grouped[k] = { totalTimeInMins: 0, memos: [] };
        v.memos.push(item);
        v.totalTimeInMins += item.timeInMins;
    });
    return grouped;
}


// Print sth like:
// #0 ["2000-01-01","20322051544","1979.0","8.8017226E7","ABC","45"]
// #1 ["2050-11-27","28392898392","1974.0","8.8392926E7","DEF","23"]
// Number of lines: 2