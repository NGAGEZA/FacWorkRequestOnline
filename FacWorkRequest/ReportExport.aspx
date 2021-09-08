<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReportExport.aspx.vb" Inherits="FacWorkRequest.ReportExport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body { background-image: url('Images/ExportMenu.png'); }
                
    </style>

    <script type="text/javascript">


        function BootboxContentfindwrno() {
            var frmStr = '<form id="wrnofind">' +
                '<div class="form-group">' +
                '<label for="tbwrno">WRNo.</label>' +
                '<input id="tbwrno" type="text" name="tbwrno" class="form-control input-sm"  placeholder="WRNo."/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            return object;
        }

        //find with wrno
        $(document).on("click",
            ".findwrno",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContentfindwrno,
                    title: "Export Work Request WRNO. ",
                    buttons: {
                        ok: {
                            label: "Find",
                            className: "btn-primary",
                            callback: function() {
                                debugger;
                                var cwrno = document.getElementById("tbwrno");

                                var wrno = cwrno.value;

                                var url = "ReportExport.aspx?findwrno=" + wrno;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });

        function BootboxContent() {
            var frmStr = '<form id="datefind">' +
                '<div class="form-group">' +
                '<label for="tbdate">Date</label>' +
                '<input id="tbdate" type="text" name="tbdate" class="form-control input-sm date"  placeholder="Year Month"/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            object.find('.date').datepicker({
                minViewMode: 1,
                autoclose: true,
                format: 'mm/yyyy'
            }).on('changeDate',
                function(ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });


            return object;
        }

        $(document).on("click",
            ".findmonthyeariso",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContent,
                    title: "Export Report Standard",
                    buttons: {
                        ok: {
                            label: "Find",
                            className: "btn-primary",
                            callback: function() {
                                debugger;
                                var date1 = document.getElementById("tbdate");
                                var datetmonth = date1.value;
                                var url = "ReportExport.aspx?dtmonth=" + datetmonth;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });

        function BootboxContentISOFac() {
            var frmStr = '<form id="isofac">' +
                '<div class="form-group">' +
                '<label for="tbisofac">Date</label>' +
                '<input id="tbisofac" type="text" name="tbisofac" class="form-control input-sm date"  placeholder="Year Month"/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            object.find('.date').datepicker({
                minViewMode: 1,
                autoclose: true,
                format: 'mm/yyyy'
            }).on('changeDate',
                function(ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });


            return object;
        }

        $(document).on("click",
            ".findmonthyearisofac",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContentISOFac,
                    title: "Export Report Standard Facility",
                    buttons: {
                        ok: {
                            label: "Find",
                            className: "btn-primary",
                            callback: function() {
                                debugger;
                                var dateISO = document.getElementById("tbisofac");
                                var datetmonthiso = dateISO.value;
                                var url = "ReportExport.aspx?dtmonthfac=" + datetmonthiso;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <!-- Boxes de Acoes -->
            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="report1">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox1">
                            <i class="fa fa-file-pdf-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Report Work Request</h3>
                            <p>
                                Export Report Work Request PDF File
                            </p>
                            <div class="more">
                                <a class="findwrno" href="ReportExport.aspx" title="Title Link">
                                    Click <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="report2">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox2">
                            <i class="fa fa-file-excel-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Report Standard (ISO)</h3>
                            <p>
                                Export Report Standard Excel file
                            </p>
                            <div class="more">
                                <a class="findmonthyeariso" href="ReportExport.aspx" title="Title Link">
                                    Click <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>


            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="report3">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox3">
                            <i class="fa fa-file-excel-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Report Standard Facility</h3>
                            <p>
                                Export Report Standard Facility Excel file
                            </p>
                            <div class="more">
                                <a class="findmonthyearisofac" href="ReportExport.aspx" title="Title Link">
                                    Click <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>


            <!-- /Boxes de Acoes -->
        </div>
    </div>
</asp:Content>