<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="DChart.aspx.vb" Inherits="FacWorkRequest.DChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<script src="Chart/jquery.js"></script>--%>
    <script src="Chart/utils.js"></script>
    <script src="Chart/Chart.js"></script>
    <script src="Chart/chartjs-plugin-labels.js"></script>


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
                                var getDataRole1 = function() {
                                    var date1 = document.getElementById("tbfromdate");
                                    var date2 = document.getElementById("tbtodate");
                                    var datefrom = date1.value;
                                    var dateto = date2.value;

                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        contentType: 'application/json',
                                        url: '<%=ResolveUrl("~/WebService.asmx/getData_ChartSummaryByStatus")%>',
                                        data: "{StartRange: '" + datefrom + "', EndRange: '" + dateto + "',Role:'1' }",
                                        success: OnSuccessRole1_,
                                        error: OnErrorCall_
                                    });

                                };

                                // logic to get new data
                                var getDataRole2 = function() {
                                    var date1 = document.getElementById("tbfromdate");
                                    var date2 = document.getElementById("tbtodate");
                                    var datefrom = date1.value;
                                    var dateto = date2.value;

                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        contentType: 'application/json',
                                        url: '<%=ResolveUrl("~/WebService.asmx/getData_ChartSummaryByStatus")%>',
                                        data: "{StartRange: '" + datefrom + "', EndRange: '" + dateto + "',Role:'2' }",
                                        success: OnSuccessRole2_,
                                        error: OnErrorCall_
                                    });

                                };

                                // logic to get new data
                                var getDataRole3 = function() {
                                    var date1 = document.getElementById("tbfromdate");
                                    var date2 = document.getElementById("tbtodate");
                                    var datefrom = date1.value;
                                    var dateto = date2.value;

                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        contentType: 'application/json',
                                        url: '<%=ResolveUrl("~/WebService.asmx/getData_ChartSummaryByStatus")%>',
                                        data: "{StartRange: '" + datefrom + "', EndRange: '" + dateto + "',Role:'3' }",
                                        success: OnSuccessRole3_,
                                        error: OnErrorCall_
                                    });

                                };

                                // logic to get new data
                                var getDataRoleTotal = function() {
                                    var date1 = document.getElementById("tbfromdate");
                                    var date2 = document.getElementById("tbtodate");
                                    var datefrom = date1.value;
                                    var dateto = date2.value;

                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        contentType: 'application/json',
                                        url: '<%=ResolveUrl("~/WebService.asmx/getData_ChartSummaryByStatusTotal")%>',
                                        data: "{StartRange: '" + datefrom + "', EndRange: '" + dateto + "' }",
                                        success: OnSuccessRoleTotal_,
                                        error: OnErrorCall_
                                    });

                                };

                                function OnSuccessRole1_(response) {

                                    var aData = response.d;

                                    var arr1 = [];
                                    var arr2 = [];

                                    var ict_unit = [];
                                    var efficiency = [];
                                    var coloR = [];

                                    var default_colors = [
                                        '#3366CC', '#DC3912', '#FF9900', '#109618', '#990099',
                                        '#3B3EAC', '#0099C6', '#DD4477', '#66AA00', '#B82E2E',
                                        '#316395', '#994499', '#22AA99', '#AAAA11', '#6633CC',
                                        '#E67300', '#8B0707', '#329262', '#5574A6', '#3B3EAC'
                                    ];


                                    //var dynamicColors = function () {
                                    //    var r = Math.floor(Math.random() * 255);
                                    //    var g = Math.floor(Math.random() * 255);
                                    //    var b = Math.floor(Math.random() * 255);
                                    //    return "rgb(" + r + "," + g + "," + b + ")";
                                    //};

                                    //for (var i in aData) {
                                    //    ict_unit.push("ICT Unit " + aData[i].ict_unit);
                                    //    efficiency.push(aData[i].efficiency);
                                    //    coloR.push(dynamicColors());
                                    //}

                                    for (var i in aData) {
                                        coloR.push(default_colors[i]);
                                    }

                                    $.each(aData,
                                        function(inx, val) {
                                            arr1.push(val.Process);
                                            arr2.push(val.Total);
                                        });


                                    var config = {
                                        type: 'pie',
                                        data: {
                                            datasets: [
                                                {
                                                    data: arr2,
                                                    backgroundColor: coloR,
                                                    label: '#On Progress Group-1#'
                                                }
                                            ],
                                            labels: arr1
                                        },

                                        options: {
                                            responsive: true,
                                            title: {
                                                display: true,
                                                text: '#On Progress Group-1#'
                                            },
                                            tooltips: {
                                                enabled: false
                                            },
                                            plugins: {
                                                labels: [
                                                    {
                                                        render: 'label',
                                                        position: 'outside'
                                                    },
                                                    {
                                                        render: 'percentage',
                                                        precision: 2,
                                                        fontSize: 14,
                                                        fontStyle: 'bold',
                                                        fontColor: '#000',
                                                        fontFamily: '"Lucida Console", Monaco, monospace'
                                                    }
                                                ]
                                            }

                                        }

                                    };

                                    var ctx = document.getElementById('canvas1').getContext('2d');
                                    window.myPie = new Chart(ctx, config);

                                }


                                function OnSuccessRole2_(response) {
                                    var aData = response.d;

                                    var arr1 = [];
                                    var arr2 = [];

                                    var ict_unit = [];
                                    var efficiency = [];
                                    var coloR = [];

                                    var default_colors = [
                                        '#3366CC', '#DC3912', '#FF9900', '#109618', '#990099',
                                        '#3B3EAC', '#0099C6', '#DD4477', '#66AA00', '#B82E2E',
                                        '#316395', '#994499', '#22AA99', '#AAAA11', '#6633CC',
                                        '#E67300', '#8B0707', '#329262', '#5574A6', '#3B3EAC'
                                    ];

                                    for (var i in aData) {
                                        coloR.push(default_colors[i]);
                                    }

                                    $.each(aData,
                                        function(inx, val) {
                                            arr1.push(val.Process);
                                            arr2.push(val.Total);
                                        });


                                    var config = {
                                        type: 'pie',
                                        data: {
                                            datasets: [
                                                {
                                                    data: arr2,
                                                    backgroundColor: coloR,
                                                    label: '#On Progress Group-2#'
                                                }
                                            ],
                                            labels: arr1
                                        },

                                        options: {
                                            responsive: true,
                                            title: {
                                                display: true,
                                                text: '#On Progress Group-2#'
                                            },
                                            tooltips: {
                                                enabled: false
                                            },
                                            plugins: {
                                                labels: [
                                                    {
                                                        render: 'label',
                                                        position: 'outside'
                                                    },
                                                    {
                                                        render: 'percentage',
                                                        precision: 2,
                                                        fontSize: 14,
                                                        fontStyle: 'bold',
                                                        fontColor: '#000',
                                                        fontFamily: '"Lucida Console", Monaco, monospace'
                                                    }
                                                ]
                                            }

                                        }

                                    };

                                    var ctx = document.getElementById('canvas2').getContext('2d');
                                    window.myPie = new Chart(ctx, config);

                                }


                                function OnSuccessRole3_(response) {

                                    var aData = response.d;

                                    var arr1 = [];
                                    var arr2 = [];

                                    var ict_unit = [];
                                    var efficiency = [];
                                    var coloR = [];

                                    var default_colors = [
                                        '#3366CC', '#DC3912', '#FF9900', '#109618', '#990099',
                                        '#3B3EAC', '#0099C6', '#DD4477', '#66AA00', '#B82E2E',
                                        '#316395', '#994499', '#22AA99', '#AAAA11', '#6633CC',
                                        '#E67300', '#8B0707', '#329262', '#5574A6', '#3B3EAC'
                                    ];

                                    for (var i in aData) {
                                        coloR.push(default_colors[i]);
                                    }

                                    $.each(aData,
                                        function(inx, val) {
                                            arr1.push(val.Process);
                                            arr2.push(val.Total);
                                        });


                                    var config = {
                                        type: 'pie',
                                        data: {
                                            datasets: [
                                                {
                                                    data: arr2,
                                                    backgroundColor: coloR,
                                                    label: '#On Progress Group-3#'
                                                }
                                            ],
                                            labels: arr1
                                        },

                                        options: {
                                            responsive: true,
                                            title: {
                                                display: true,
                                                text: '#On Progress Group-3#'
                                            },
                                            tooltips: {
                                                enabled: false
                                            },
                                            plugins: {
                                                labels: [
                                                    {
                                                        render: 'label',
                                                        position: 'outside'
                                                    },
                                                    {
                                                        render: 'percentage',
                                                        precision: 2,
                                                        fontSize: 14,
                                                        fontStyle: 'bold',
                                                        fontColor: '#000',
                                                        fontFamily: '"Lucida Console", Monaco, monospace'
                                                    }
                                                ]
                                            }

                                        }

                                    };

                                    var ctx = document.getElementById('canvas3').getContext('2d');
                                    window.myPie = new Chart(ctx, config);
                                }

                                function OnSuccessRoleTotal_(response) {
                                    var aData = response.d;

                                    var arr1 = [];
                                    var arr2 = [];

                                    var ict_unit = [];
                                    var efficiency = [];
                                    var coloR = [];

                                    var default_colors = [
                                        '#3366CC', '#DC3912', '#FF9900', '#109618', '#990099',
                                        '#3B3EAC', '#0099C6', '#DD4477', '#66AA00', '#B82E2E',
                                        '#316395', '#994499', '#22AA99', '#AAAA11', '#6633CC',
                                        '#E67300', '#8B0707', '#329262', '#5574A6', '#3B3EAC'
                                    ];

                                    for (var i in aData) {
                                        coloR.push(default_colors[i]);
                                    }

                                    $.each(aData,
                                        function(inx, val) {
                                            arr1.push(val.Process);
                                            arr2.push(val.Total);
                                        });


                                    var config = {
                                        type: 'pie',
                                        data: {
                                            datasets: [
                                                {
                                                    data: arr2,
                                                    backgroundColor: coloR,
                                                    label: 'Total On Progress'
                                                }
                                            ],
                                            labels: arr1
                                        },

                                        options: {
                                            responsive: true,
                                            title: {
                                                display: true,
                                                text: 'Total On Progress'
                                            },
                                            tooltips: {
                                                enabled: false
                                            },
                                            plugins: {
                                                labels: [
                                                    {
                                                        render: 'label',
                                                        position: 'outside'
                                                    },
                                                    {
                                                        render: 'percentage',
                                                        precision: 2,
                                                        fontSize: 14,
                                                        fontStyle: 'bold',
                                                        fontColor: '#000',
                                                        fontFamily: '"Lucida Console", Monaco, monospace'
                                                    }
                                                ]
                                            }

                                        }

                                    };

                                    var ctx = document.getElementById('canvas4').getContext('2d');
                                    window.myPie = new Chart(ctx, config);
                                }

                                function OnErrorCall_(response) {
                                    alert("Load Data Error..");

                                }


                                //// get new data every 10 seconds
                                $(function() {
                                    getDataRole1();
                                    getDataRole2();
                                    getDataRole3();
                                    getDataRoleTotal();
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
            <p class="text-danger">Job On Progress</p>


            <hr/>
            <div class="row">

                <a class="btn icon-btn btn-success finddate" href="#"><span class="fa fa-calendar text-success "></span> Date View</a>


            </div>

        </div>
        <div class="col-md-6">
            <canvas id="canvas1"></canvas>
        </div>
        <div class="col-md-6">
            <canvas id="canvas2"></canvas>
        </div>
        <div class="col-md-6">
            <canvas id="canvas3"></canvas>
        </div>
        <div class="col-md-6">
            <canvas id="canvas4"></canvas>
        </div>
    </div>


</asp:Content>