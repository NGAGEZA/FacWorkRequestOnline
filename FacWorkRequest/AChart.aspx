<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AChart.aspx.vb" Inherits="FacWorkRequest.AChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<script src="Chart/jquery.js"></script>--%>
    <script src="Chart/utils.js"></script>
    <script src="Chart/Chart.js"></script>
    <script src="Chart/chartjs-plugin-datalabels.js"></script>

    <script type="text/javascript">

        //Show the datepicker in the bootbox
        $(document).on("click",
            ".finddate",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContent,
                    title: "View Chart Date ",
                    buttons: {
                        ok: {
                            label: "View",
                            className: "btn-primary",
                            callback: function() {

                                'use strict';

                                // logic to get new data
                                var getData = function() {
                                    //debugger;
                                    //var StartRange = document.getElementById("TextBox1");
                                    //var EndRange = document.getElementById("TextBox2");                                                                                                                                             

                                    //var StartRangeValue = StartRange.value;
                                    //var EndRangeValue = EndRange.value; 
                                    var date1 = document.getElementById("tbfromdate");
                                    var date2 = document.getElementById("tbtodate");
                                    var datefrom = date1.value;
                                    var dateto = date2.value;

                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        contentType: 'application/json',
                                        url: '<%=ResolveUrl("~/WebService.asmx/getData_ChartSummary")%>',
                                        //url:'../WebService.asmx/getData_Default', //เรียก webmethod ที่เตรียมไว้ใน code behind
                                        //data: "{StartRange:  '" + StartRangeValue + "',EndRange:  '" + EndRangeValue + "' }",

                                        data: "{StartRange: '" + datefrom + "', EndRange: '" + dateto + "'}",
                                        success: OnSuccess_,
                                        error: OnErrorCall_
                                    });

                                };

                                function OnSuccess_(response) {

                                    var aData = response.d;

                                    var arr1 = [];
                                    var arr2 = [];
                                    var arr3 = [];
                                    var arr4 = [];
                                    var arr5 = [];
                                    var arr6 = [];
                                    $.each(aData,
                                        function(inx, val) {
                                            arr1.push(val.MonthYear);
                                            arr2.push(val.TotalRequest);
                                            arr3.push(val.TotalFinish);
                                            arr4.push(val.TotalRemain);
                                            arr5.push(val.AccumulateRequest);
                                            arr6.push(val.AccumulateFinish);
                                        });

                                    var chartData = {
                                        labels: arr1,
                                        datasets: [
                                            {
                                                type: 'line',
                                                label: 'AccumulateRequest',
                                                borderColor: window.chartColors.blue,
                                                borderWidth: 2,
                                                fill: false,
                                                data: arr5
                                            }, {
                                                type: 'line',
                                                label: 'AccumulateFinish',
                                                borderColor: window.chartColors.green,
                                                borderWidth: 2,
                                                fill: false,
                                                data: arr6,
                                            }, {
                                                type: 'bar',
                                                label: 'TotalRequest',
                                                backgroundColor: window.chartColors.red,
                                                data: arr2,
                                                borderColor: 'white',
                                                borderWidth: 2
                                            }, {
                                                type: 'bar',
                                                label: 'TotalFinish',
                                                backgroundColor: window.chartColors.orange,
                                                data: arr3,
                                                borderColor: 'white',
                                                borderWidth: 2
                                            }, {
                                                type: 'bar',
                                                label: 'TotalRemain',
                                                backgroundColor: window.chartColors.green,
                                                data: arr4
                                            }
                                        ]

                                    };

                                    var ctx = document.getElementById('canvas').getContext('2d');
                                    window.myMixedChart = new Chart(ctx,
                                        {
                                            type: 'bar',
                                            data: chartData,

                                            options: {
                                                responsive: true,
                                                legend: {
                                                    position: 'bottom',
                                                    display: true,

                                                },
                                                "hover": {
                                                    "animationDuration": 0
                                                },
                                                "animation": {
                                                    "duration": 1,
                                                    "onComplete": function () {
                                                        var chartInstance = this.chart,
                                                          ctx = chartInstance.ctx;

                                                        ctx.font = Chart.helpers.fontString('12', 'normal', 'sans - serif');
                                                        ctx.fillStyle = '#666';
                                                        ctx.textAlign = 'center';
                                                        ctx.textBaseline = 'bottom';

                                                        this.data.datasets.forEach(function (dataset, i) {
                                                            var meta = chartInstance.controller.getDatasetMeta(i);
                                                            meta.data.forEach(function (bar, index) {
                                                                var data = dataset.data[index];
                                                                ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                                            });
                                                        });
                                                    }
                                                },

                                                title: {
                                                    display: true,
                                                    text: 'Master Construction Job Quantity'
                                                },
                                                plugins: {
                                                    datalabels: {
                                                        display: false
                                                    }
                                                },
                                            }


                                            //options: {
                                            //    responsive: true,
                                            //    title: {
                                            //        display: true,
                                            //        text: 'Master Construction Job Quantity'
                                            //    },
                                            //    tooltips: {
                                            //        //mode: 'index',
                                            //        //intersect: true
                                            //        enabled: false

                                            //    },
                                            //    plugins: {
                                            //        datalabels: {
                                            //            backgroundColor: function(context) {
                                            //                return context.dataset.backgroundColor;
                                            //            },
                                            //            //borderRadius: 4,
                                            //            color: 'blue',
                                            //            font: {
                                            //                weight: 'bold',
                                            //                size : '12'

                                            //            },
                                            //            formatter: Math.round
                                            //        }
                                            //    }

                                            //}


                                        });
                                }

                                function OnErrorCall_(response) {
                                    alert("Load Data Error..");

                                }


                                //// get new data every 10 seconds
                                $(function() {
                                    getData();
                                });

                            }
                        }
                    }
                });
            });


        function BootboxContent() {
            var frmStr = '<form id="datefind">' +
                '<div class="form-group">' +
                '<label for="tbfromdate">From Date</label>' +
                '<input id="tbfromdate" type="text" name="tbfromdate" class="form-control input-sm date"  placeholder="From Date"/>' +
                '</div>' +
                '<div class="form-group">' +
                '<label for="tbtodate">To Date</label>' +
                ' <input id="tbtodate" type="text" name="tbtodate" class="form-control input-sm date"  placeholder="To Date"/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            object.find('.date').datepicker({
                format: "mm/yyyy",
                autoclose: true,
                minViewMode: 1
            }).on('changeDate',
                function(ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });


            return object;
        }


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="jumbotron">
            <p class="text-danger">Total Monthly</p>


            <hr/>
            <div class="row">

                <a class="btn icon-btn btn-success finddate" href="#"><span class="fa fa-calendar text-success "></span> Date View</a>


            </div>


        </div>

        <div class="row">
            <div class="col-md-12">
                <canvas id="canvas"></canvas>
            </div>


        </div>
    </div>
</asp:Content>