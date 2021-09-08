

(function($) {


    "use strict";

    // logic to get new data
    var getData = function() {


        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            url: "../WebService.asmx/getData_Default", //เรียก webmethod ที่เตรียมไว้ใน code behind
            data: "{label:  '" + label + "' }",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    };


    function OnSuccess_(response) {


        //debugger


        var chartData = {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    type: "line",
                    label: "Dataset 1",
                    borderColor: window.chartColors.blue,
                    borderWidth: 2,
                    fill: false,
                    data: [
                        //randomScalingFactor(),
                        //randomScalingFactor(),
                        //randomScalingFactor(),
                        //randomScalingFactor(),
                        //randomScalingFactor(),
                        //randomScalingFactor(),
                        //randomScalingFactor()
                        5, 20, 30, 40, 50, 60, 70
                    ]
                }, {
                    type: "line",
                    label: "Dataset 2",
                    borderColor: window.chartColors.green,
                    borderWidth: 2,
                    fill: false,
                    data: [
                        12, 50, 10, 30, 80, 20, 55
                    ],
                }, {
                    type: "bar",
                    label: "Dataset 3",
                    backgroundColor: window.chartColors.red,
                    data: [
                        3, 20, 30, 40, 50, 60, 70
                    ],
                    borderColor: "white",
                    borderWidth: 2
                }, {
                    type: "bar",
                    label: "Dataset 4",
                    backgroundColor: window.chartColors.orange,
                    data: [
                        5, 20, 30, 40, 50, 60, 70
                    ],
                    borderColor: "white",
                    borderWidth: 2
                }, {
                    type: "bar",
                    label: "Dataset 5",
                    backgroundColor: window.chartColors.green,
                    data: [
                        8, 20, 30, 40, 50, 60, 70
                    ]
                }
            ]

        };

        var ctx = document.getElementById("canvas").getContext("2d");
        window.myMixedChart = new Chart(ctx,
            {
                type: "bar",
                data: chartData,
                options: {
                    responsive: true,
                    title: {
                        display: true,
                        text: "Chart.js Combo Bar Line Chart"
                    },
                    tooltips: {
                        //mode: 'index',
                        //intersect: true
                        enabled: false

                    },
                    plugins: {
                        datalabels: {
                            backgroundColor: function(context) {
                                return context.dataset.backgroundColor;
                            },
                            borderRadius: 4,
                            color: "red",
                            font: {
                                weight: "bold"
                            },
                            formatter: Math.round
                        }
                    }

                    //animation: {
                    //    "duration": 1,
                    //    "onComplete": function () {
                    //        var chartInstance = this.chart,
                    //            ctx = chartInstance.ctx;

                    //        //ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                    //        ctx.textAlign = 'center';
                    //        ctx.textBaseline = 'bottom';

                    //        this.data.datasets.forEach(function (dataset, i) {
                    //            var meta = chartInstance.controller.getDatasetMeta(i);
                    //            meta.data.forEach(function (bar, index) {
                    //                var data = dataset.data[index];
                    //                ctx.fillText(data, bar._model.x, bar._model.y - 5);
                    //                ctx.defaultFontColor = 'red';

                    //            });
                    //        });
                    //    }
                    //} 

                }
            });
    }

    function OnErrorCall_(response) {
        alert("Load Data Error..");


    }


    // get new data every 10 seconds
    $(function() {
        getData();
    });

    setInterval(getData, 10000);


}).apply(this, [jQuery]);