var analyser = require("../analyse_data.js");

describe('analyse_data', function(){

  it('should read full CSV file', function(){
      runs(function() {
          var that = this;
          analyser.loadCsv(__dirname+"/sample-timelog.csv", function(data) {
              that.csvLoaded = true;
              that.csvData = data;
          });
      });

      waitsFor(function() {
          return this.csvLoaded;
      });

      runs(function(){
          //console.log(this.csvData);
          expect(this.csvData).toBeTruthy();
          expect(this.csvData.length).toBe(31);
      })
  });

  it('should extract and group all the memos', function() {
      var csvData = [
          [ 'Week', 'Date', 'mr_david_laingci - time', 'mr_david_laingci - memo' ],
          [ 'Wed 06/01/11 - Sun 06/05/11', '06/01/11', '08:40', '01:20 - [CIAPI.docs] Catchup with Sky\n07:20 - [CIAPI.Js] Authentication widget' ],
          [ 'Wed 06/01/11 - Sun 06/05/11', '06/02/11', '10:10', '03:30 - [Admin] Catchup & planning with Mike\n01:30 - [CIAPI.AspNet] Test widget skeleton in Ektron\n02:10 - [CIAPI.AspNet] Authentication Widget\n02:00 - [Admin] Shapado import\n01:00 - [CIAPI.Js] Authentication widget' ]
      ];

      var groups = analyser.extractGroups(csvData);

      console.log(groups);
      expect(groups['Admin'].memos.length).toBe(2);
      expect(groups['Admin'].totalTimeInMins).toBe(330);

  })
});
