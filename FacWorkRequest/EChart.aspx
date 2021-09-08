<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="EChart.aspx.vb" Inherits="FacWorkRequest.EChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                                var date1 = document.getElementById("tbfromdate");
                                var date2 = document.getElementById("tbtodate");
                                var datefrom = date1.value;
                                var dateto = date2.value;
                                var url = "EChart.aspx?dtfrm=" + datefrom + "&dtto=" + dateto;
                                window.location.href = url;
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
    <div class="container">

        <div class="jumbotron">
            <p class="text-danger">ISO Report</p>


            <hr/>
            <div class="row">

                <a class="btn icon-btn btn-success finddate" href="#"><span class="fa fa-calendar text-success "></span> Date View</a>


            </div>

        </div>
    </div>
</asp:Content>