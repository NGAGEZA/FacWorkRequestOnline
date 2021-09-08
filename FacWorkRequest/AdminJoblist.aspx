<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdminJoblist.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FacWorkRequest.AdminJoblist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Scripts/quicksearch.js"></script>--%>
    
    
    <!-- Bootstrap -->
<%--    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
          media="screen" />--%>
    <!-- Bootstrap -->
    <link href="Content/rmodal.css" rel="stylesheet"/>
    <script src="Scripts/rmodal.js"></script>
    <script type="text/javascript">
        //$(function() {
        //    $('.search_textbox').each(function(i) {
        //        $(this).quicksearch("[id*=gvDetails] tr:not(:has(th))",
        //            {
        //                'testQuery': function(query, txt, row) {
        //                    return $(row).children(":eq(" + i + ")").text().toLowerCase()
        //                        .indexOf(query[0].toLowerCase()) !=
        //                        -1;
        //                }
        //            });
        //    });
        //});


        function setupFileUploadBox1() {
            //setup file upload 
            $("#input-upload-1").fileinput({
                uploadUrl: "ReceieveFile.aspx?ID=Q1",
                uploadAsync: true,
                showUpload: true,
                dropZoneEnabled: true,
                maxFileCount: 1,
                //mainClass: "input-group-lg",
                allowedFileExtensions: ["pdf"]
            });
        }

        function setupFileUploadBox2() {
            //setup file upload 
            $("#input-upload-2").fileinput({
                uploadUrl: "ReceieveFile.aspx?ID=Q2",
                uploadAsync: true,
                showUpload: true,
                dropZoneEnabled: true,
                maxFileCount: 1,
                //mainClass: "input-group-lg",
                allowedFileExtensions: ["pdf"]
            });
        }


        function ReceiveComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Receive Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }

        function AcceptComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Accept Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }

        function EndjobComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>End Job Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }

        function InspectionComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Inspection Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


        function SurveyComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Survey Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


         function ContactComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Contact Vendor Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


        
        function ApproveComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Approve Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


        function SetplanComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Set Working Plan Date Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


        function QuotationComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Quotation Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }

        function DeleteComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Delete Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "AdminJoblist.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


    </script>

    <%--'confirm delete--%>
    <script type="text/javascript">
        $(document).on("click",
            ".confirmdelete",
            function(e) {
                e.preventDefault();
                var lHref = $(this).attr('href');
                bootbox.confirm({
                    size: "small",
                    message: "Do you want to delete !",
                    title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                    buttons: {
                        confirm: {
                            label: 'Yes',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'No',
                            className: 'btn-danger'
                        }
                    },
                    callback: function(result) {
                        if (result == true) {
                            window.location.href = lHref;
                        }
                    }
                });
            });

        $(document).on("click",
            ".confirmend",
            function(e) {
                e.preventDefault();
                var lHref = $(this).attr('href');
                bootbox.confirm({
                    size: "small",
                    message: "Do you want to confirm end job !",
                    title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                    buttons: {
                        confirm: {
                            label: 'Yes',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'No',
                            className: 'btn-danger'
                        }
                    },
                    callback: function(result) {
                        if (result == true) {
                            window.location.href = lHref;
                        }
                    }
                });
            });
    </script>

    <script type="text/javascript">
        function openModalsetQuotation() {
            const modalsetquotation = new RModal(document.getElementById('modalsetquotation'),
                {
                });
            modalsetquotation.open();

        }

        function openModalworking() {
            const modalworking = new RModal(document.getElementById('modalworking'),
                {
                });
            modalworking.open();

        }

        function setplanworking() {
            bootbox.dialog({
                size: "small",
                message: ContentWorkingDate,
                title: "Set Plan Working Date",
                buttons: {
                    ok: {
                        label: "Save",
                        className: "btn-primary",
                        callback: function() {


                            var date1 = document.getElementById("tbfromdate");
                            var date2 = document.getElementById("tbtodate");
                            var datefrom = date1.value;
                            var dateto = date2.value;
                            var url = "AdminJoblist.aspx?dtfrm=" + datefrom + "&dtto=" + dateto;
                            window.location.href = url;
                        }
                    }
                }
            });
        };

        function setsurveydetails() {
            bootbox.dialog({
                size: "small",
                message: ContentSurveyDetails,
                title: "Survey Details Date",
                buttons: {
                    ok: {
                        label: "Save",
                        className: "btn-primary",
                        callback: function() {


                            var idsurvey = document.getElementById("tbsurveydate");
                            var idremark = document.getElementById("tbsurveyremark");
                            var surveydate = idsurvey.value;
                            var remarks = idremark.value;
                            var url = "AdminJoblist.aspx?dtsur=" + surveydate + "&remarksur=" + remarks;
                            window.location.href = url;
                        }
                    }
                }
            });
        };
    </script>

    <script>
        function clearMyField() {


            window.location.href = "AdminJoblist.aspx";
        }
    </script>

    <script type="text/javascript">
        //Autocomplete1
        $(function() {
            $('[id*=tbsupplier1]').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetSupplier")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var id = item.split('-')[1];
                                    var name = item.split('-')[0];
                                    map[name] = { id: id, name: name };
                                    items.push(name);
                                });
                            response(items);
                            $(".dropdown-menu").css("height", "auto");
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                }

            });
        });

        //Autocomplete2
        $(function() {
            $('[id*=tbsupplier2]').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetSupplier")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var id = item.split('-')[1];
                                    var name = item.split('-')[0];
                                    map[name] = { id: id, name: name };
                                    items.push(name);
                                });
                            response(items);
                            $(".dropdown-menu").css("height", "auto");
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                }

            });
        });

        //Autocomplete3
        $(function() {
            $('[id*=tbsupplier3]').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetSupplier")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var id = item.split('-')[1];
                                    var name = item.split('-')[0];
                                    map[name] = { id: id, name: name };
                                    items.push(name);
                                });
                            response(items);
                            $(".dropdown-menu").css("height", "auto");
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                }

            });
        });

        //Autocomplete4
        $(function() {
            $('[id*=tbsupplier4]').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetSupplier")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var id = item.split('-')[1];
                                    var name = item.split('-')[0];
                                    map[name] = { id: id, name: name };
                                    items.push(name);
                                });
                            response(items);
                            $(".dropdown-menu").css("height", "auto");
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                }

            });
        });

        //Autocomplete5
        $(function() {
            $('[id*=tbsupplier5]').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetSupplier")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var id = item.split('-')[1];
                                    var name = item.split('-')[0];
                                    map[name] = { id: id, name: name };
                                    items.push(name);
                                });
                            response(items);
                            $(".dropdown-menu").css("height", "auto");
                        },
                        error: function(response) {
                            alert(response.responseText);
                        },
                        failure: function(response) {
                            alert(response.responseText);
                        }
                    });
                }

            });
        });
    </script>


    <script type="text/javascript">


        function ContentWorkingDate() {
            var frmStr = '<form id="dateplan">' +
                '<div class="form-group">' +
                '<label for="tbfromdate">Start Plan Date</label>' +
                '<input id="tbfromdate" type="text" name="tbfromdate" class="form-control input-sm date"  placeholder="From Date"/>' +
                '</div>' +
                '<div class="form-group">' +
                '<label for="tbtodate">Finish Plan Date</label>' +
                ' <input id="tbtodate" type="text" name="tbtodate" class="form-control input-sm date"  placeholder="To Date"/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            object.find('.date').datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                calendarWeeks: true,
                todayBtn: "linked"
            }).on('changeDate',
                function(ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });


            return object;
        }

        function ContentSurveyDetails() {
            var frmStr = '<form id="SurveyDetails">' +
                '<div class="form-group">' +
                '<label for="tbsurveydate">Survey Date</label>' +
                '<input id="tbsurveydate" type="text" name="tbsurveydate" class="form-control input-sm date"  placeholder="Survey Date"/>' +
                '</div>' +
                '<div class="form-group">' +
                '<label for="tbsurveyremark">Remarks</label>' +
                ' <input id="tbsurveyremark" type="text" name="tbsurveyremark" class="form-control input-sm"  placeholder="Remarks"/>' +
                '</div>' +
                '</form>';
            //var frmStr = $('#add_class_form').html();

            var object = $('<div/>').html(frmStr).contents();

            object.find('.date').datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                calendarWeeks: true,
                todayBtn: "linked"
            }).on('changeDate',
                function(ev) {
                    $(this).blur();
                    $(this).datepicker('hide');
                });


            return object;
        }
        //function ShowpopQuotation(e) {
        //    e.preventDefault();
        //    $("#MyPopup").modal("show");
        //    // your code
        //}

        <%-- $(document).on("click",".setworkingdate", function(e) {
            e.preventDefault();
            bootbox.dialog({
                size: "small",
                message: ContentWorkingDate,
                title: "Set Plan Working Date",
                buttons: {
                    ok: {
                        label: "Save",
                        className: "btn-primary",
                        callback: function Read() {


                            //alert('Hi');
                            debugger;
                            var id = $(".NotifSent2", $(this).closest("tr")).html();
                            var id2 = $(this).next('.NotifSent2').val();

                            var val = $(this).closest('tr').find('[id$=lnk_working]').html();

                            var gv = document.getElementById("<%=gvDetails.ClientID %>");
                            var gvRowCount = gv.rows.length;
                            var rwIndex = 1;

                            //var tbl = document.getElementById('Gridview1');

                            var tbl_row = gv.rows[parseInt(1) + 1];

                            var tbl_Cell = tbl_row.cells[0];

                            var value = tbl_Cell.innerHTML.toString();

                            for (rwIndex; rwIndex <= gvRowCount - 1; rwIndex++) {             
                                alert(gv.rows[rwIndex].cells[0].innerHTML.toString());
                            }
                            
                        
                        





                            var date1 = document.getElementById("tbfromdate");
                            var date2 = document.getElementById("tbtodate");
                            var datefrom = date1.value;
                            var dateto = date2.value;
                            var url = "AdminJoblist.aspx?dtfrm=" + datefrom + "&dtto=" + dateto;
                            window.location.href = url;
                        }
                    }
                }
            });
        });--%>
    </script>
    
  <%--  <script type="text/javascript">
        function getConfirmation(sender, wrNo, message) {

            document.getElementById("lbwrno").text = wrNo;
            window.$("#lbwrno").text(wrNo);
            window.$("#spnMsg").text(message);
            window.$('#modalsetquotation').modal('show');
            //window.$('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + window.$(sender).prop('href') + "}, 50);");
            return false;
        }
    </script>--%>

    <style type="text/css">
       
        .modal .modal-dialog { width: 1024px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    //function datepicker bootstrap
    //On Page Load.
    $(function() {
        SetDatePicker();
    });

    //On UpdatePanel Refresh.
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm !== null) {
        prm.add_endRequest(function(sender) {
            if (sender._postBackSettings.panelsToUpdate !== null) {
                SetDatePicker();
            }
        });
    }

    function SetDatePicker() {
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,
            calendarWeeks: true,
            todayBtn: "linked"
        });


    }


    //<style type="text/css">
    //.ShortDesc
    //    {
    //    height:50px;
    //    Overflow:hidden;
    //}
    // </style>





</script>

<%--<script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html(title);
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
    }
</script>--%>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>


<div class="container-fluid">
    <div class="jumbotron">
        <p class="text-danger">Job List for Facility Control</p>
        <hr/>
        <div class="row">
            <div class="col-md-6">
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlsearch" runat="server" CssClass="form-control">
                       
                        <asp:ListItem Value="1">1.Work Request No</asp:ListItem>
                        <asp:ListItem Value="2">2.Construction Name</asp:ListItem>
                        <asp:ListItem Value="3">3.Job Detail</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="input-group">
                    <input id="tbsearch" type="text" name="tbsearch" runat="server" class="form-control " placeholder="..."/>
                    <span class="input-group-btn">
                        <asp:Button id="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                                    UseSubmitBehavior="False" ToolTip="Search..." 
                                     EnableViewState="false" />
                       
                    </span>
                </div>
            </div>
           
           
        </div>
    </div>
</div>

    <div class="row">
        
        <div class="col-lg-12">
           
            <div class="table-responsive">
                <asp:GridView ID="gvDetails" Width="100%" CssClass="table table-striped table-hover"  GridLines="None" AllowPaging="True"  OnPageIndexChanging="OnPageIndexChanging" OnRowDataBound="OnRowDataBound" PagerStyle-CssClass="pagination-ys text-center" PageSize="20"
                              AutoGenerateColumns="False"  runat="server" AutoPostBack="true"  EmptyDataText="There are no data records to display.">
                    <Columns>

                        <asp:BoundField DataField="WRNo" HeaderText="Work Request No." HeaderStyle-CssClass="text-center text-nowrap" ItemStyle-CssClass="text-center">

<HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:BoundField>

                        <%--<asp:BoundField DataField="JobName" HeaderText="Job Name" HeaderStyle-CssClass="text-center text-nowrap" ItemStyle-CssClass="text-left text-nowrap"/>--%>
                        <asp:TemplateField HeaderText="Construction Name" ItemStyle-CssClass="text-left text-nowrap" HeaderStyle-CssClass="text-center text-nowrap">
                            <ItemTemplate>
                             <%--   <asp:Label ID="Label3" runat="server" Text='<%# Bind("JobName")%>'></asp:Label>--%>
                                <asp:Label ID="Label3" CssClass="ShortDesc" Text='<%# Eval("JobName").ToString().Substring(0, Math.Min(20, Eval("JobName").ToString().Length)) %>' runat="server"></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

                            <ItemStyle CssClass="text-left text-nowrap"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NamePlace" HeaderText="Building" HeaderStyle-CssClass="text-center text-nowrap" ItemStyle-CssClass="text-center text-nowrap">
                            <HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

                            <ItemStyle CssClass="text-center text-nowrap"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NameFloor" HeaderText="Floor" HeaderStyle-CssClass="text-center text-nowrap" ItemStyle-CssClass="text-center text-nowrap">
                            <HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

                            <ItemStyle CssClass="text-center text-nowrap"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Job Detail">
                         
                            <ItemTemplate>
                              <%--  <asp:Label ID="Label1"   runat="server" Text='<%# Bind("JobDetail") %>'>  </asp:Label>--%>

                                <asp:Label ID="Label1" CssClass="ShortDesc" Text='<%# Eval("JobDetail").ToString().Substring(0, Math.Min(50, Eval("JobDetail").ToString().Length)) %>' runat="server"></asp:Label>

                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center text-nowrap" />
                            <ItemStyle CssClass="text-left text-nowrap" />
                        </asp:TemplateField>


                        <asp:TemplateField  HeaderText="<i class='fa fa-cog' aria-hidden='true'></i> Action" ItemStyle-CssClass="text-left text-nowrap" HeaderStyle-CssClass="text-center">

                            <ItemTemplate>
                            
                  <%--                <asp:HyperLink runat="server" ID="lnk_view" CssClass="btn btn-default tooltips " data-placement="top" ToolTip="Detail" NavigateUrl='<%# String.Format("~/Entry.aspx?VEW={0},{1}", Eval("WRNo"), "WorkRequest.aspx")%>' Text="<i class='fa fa-search' aria-hidden='true'></i> View"></asp:HyperLink>--%>


                               

                                <asp:HyperLink runat="server" ID="lnk_detail" CssClass="btn btn-default tooltips" NavigateUrl='<%# String.Format("~/Entry.aspx?VEW={0},{1}", Eval("WRNo"), "AdminJoblist.aspx")%>' ToolTip="Detail" Text="<i class='fa fa-search' aria-hidden='true'></i> Detail"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_edit" CssClass="btn btn-primary tooltips" data-placement="top" ToolTip="Edit" NavigateUrl='<%# String.Format("~/Entry.aspx?UPD={0},{1}", Eval("WRNo"), "AdminJoblist.aspx")%>' Text="<i class='fa fa-wrench' aria-hidden='true'></i> Edit"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_rpt" CssClass="btn btn-danger" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?RPT={0}", Eval("WRNo"))%>' ToolTip="Report" Text="<i class='fa fa-file' aria-hidden=tru'></i> Report"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_rec" CssClass="btn btn-warning" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP7={0}", Eval("WRNo"))%>' ToolTip="Rec" Text="<i class='fa fa-calendar' aria-hidden=tru'></i> Rec"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_accept" CssClass="btn btn-success " NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP1={0}", Eval("WRNo"))%>' ToolTip="Accept" Text="<i class='fa fa-check' aria-hidden='true'></i> Accept"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_survey" CssClass="btn btn-warning" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP2={0}", Eval("WRNo"))%>' ToolTip="Survey" Text="<i class='fa fa-star' aria-hidden='true'></i> Survey"></asp:HyperLink>

                                <asp:HyperLink runat="server" ID="lnk_quotation" CssClass="btn btn-warning" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP3={0}", Eval("WRNo"))%>' ToolTip ="Quotation"  Text="<i class='fa fa-clone' aria-hidden=tru'></i> Quotation"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_working" CssClass="btn btn-warning" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP4={0}", Eval("WRNo"))%>' ToolTip="Working" Text="<i class='fa fa-calendar' aria-hidden=true'></i> Working"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_end" CssClass="btn btn-warning confirmend" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP5={0}", Eval("WRNo"))%>' ToolTip="End Job" Text="<i class='fa fa-check-circle-o' aria-hidden=true'></i> End Job"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_app_inspec" CssClass="btn btn-success" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP6={0}", Eval("WRNo"))%>' ToolTip="Inspection" Text="<i class='fa fa-thumbs-o-up' aria-hidden=true'></i> Inspection"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_contact" CssClass="btn btn-warning" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP9={0}", Eval("WRNo"))%>' ToolTip="Contact Vendor" Text="<i class='fa fa-star' aria-hidden='true'></i> Contact Vendor"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_app" CssClass="btn btn-success" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP11={0}", Eval("WRNo"))%>' ToolTip="Approve" Text="<i class='fa fa-check' aria-hidden='true'></i> Approve"></asp:HyperLink>




                            </ItemTemplate>
                                                                                                              
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-left text-nowrap"></ItemStyle>
                                                                                                              
                        </asp:TemplateField>
                                               
                             <asp:TemplateField HeaderText="<i class='fa fa-cog' aria-hidden='true'></i> Status" ItemStyle-CssClass=" text-center text-nowrap" HeaderStyle-CssClass="text-center text-nowrap">

                            <ItemTemplate>

                              <asp:HyperLink runat="server" ID="lnk_status" CssClass="tooltips" data-placement="top" NavigateUrl='<%# String.Format("~/AdminJoblist.aspx?APP11={0}", Eval("WRNo"))%>' Text=""></asp:HyperLink>
                            </ItemTemplate>

<HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

<ItemStyle CssClass=" text-center text-nowrap"></ItemStyle>

                        </asp:TemplateField>




                    </Columns>

<PagerStyle CssClass="pagination-ys text-center"></PagerStyle>
                </asp:GridView>
            </div>
        </div>
        
        

    </div>







</ContentTemplate>

<Triggers>
     <%--<asp:AsyncPostBackTrigger ControlID = "lnk_quotation" EventName = "Click" />--%>
    <asp:PostBackTrigger ControlID="lnk_del1"/>
    <asp:PostBackTrigger ControlID="lnk_del2"/>
    <asp:PostBackTrigger ControlID="lnk_del3"/>
    <asp:PostBackTrigger ControlID="lnk_del4"/>
    <asp:PostBackTrigger ControlID="lnk_del5"/>

    <asp:PostBackTrigger ControlID="lnkquosave"/>
    <asp:PostBackTrigger ControlID="lnkdownload1"/>
    <asp:PostBackTrigger ControlID="lnkdownload2"/>
    <asp:PostBackTrigger ControlID="lnkdownload3"/>
    <asp:PostBackTrigger ControlID="lnkdownload4"/>
    <asp:PostBackTrigger ControlID="lnkdownload5"/>
    <%--<asp:PostBackTrigger ControlID="lnk_quotation"/>--%>
    



</Triggers>
</asp:UpdatePanel>
                    <!-- modalsetquotation -->
<div id="modalsetquotation" class="modal" >
<div class="modal-dialog animated">

<div class="modal-content">
<form class="form-horizontal" method="get">
<div class="modal-header">
    <strong>Set Quotation for Work Request <asp:Label ID="lbwrno" runat="server" Text=""></asp:Label></strong>
</div>

<div class="modal-body">
<table class="table">
<thead class="thead-dark">
<tr>

    <th scope="col">#</th>
    <th scope="col" class="text-center text-danger">Supplier</th>
    <th scope="col" class="text-center text-danger">File Quotation Upload</th>
    <th scope="col" class="text-center text-danger">Price</th>
    <th scope="col" class="text-center text-danger">Date</th>
</tr>
</thead>
<tbody>
<tr>
    <th scope="row">1</th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbsupplier1" type="text" name="tbsupplier1" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control input-sm"/>
        </div>
        <asp:Label ID="lblMessage1" runat="server"></asp:Label>

    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbprice1" type="text" name="price1" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbdate1" type="text" name="date1" class="form-control input-sm date"/>
        </div>
    </td>

</tr>
<tr runat="server" id="trlist1" Visible="False">
    <td class="text-nowrap">
        <div class="form-group">
            <asp:LinkButton ID="lnk_del1" runat="server" CssClass="btn btn-danger " OnClick="Lsdel1" Text="<i class='fa fa-trash-o' aria-hidden='true'></i>"> </asp:LinkButton>
            <asp:Label ID="lbls1" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
    </td>

    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lssupplier_1" type="text" name="tb_lssupplier_1" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="row">

            <div class="col-md-8">
                <div class="form-group">

                    <asp:Label ID="lbnamefile1" runat="server" Text="Name of file" Visible="True" CssClass="text-success"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload1" runat="server" CssClass="btn btn-block btn-success" OnClick="DownloadFile1" Visible="true" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i>"> </asp:LinkButton>
                </div>
            </div>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsprice1" type="text" name="tb_lsprice1" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsdate1" type="text" name="tb_lsdate1" class="form-control input-sm" disabled/>
        </div>
    </td>

</tr>

<tr >
    <th scope="row">2</th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbsupplier2" type="text" name="tbsupplier2" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload2" runat="server" class="form-control input-sm"/>
        </div>
        <asp:Label ID="lblMessage2" runat="server"></asp:Label>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbprice2" type="text" name="price2" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbdate2" type="text" name="date2" class="form-control input-sm date"/>
        </div>
    </td>
</tr>
<tr runat="server" id="trlist2" Visible="False">
    <th scope="row" class="text-nowrap">
        <asp:LinkButton ID="lnk_del2" runat="server" CssClass="btn btn-danger" OnClick="Lsdel2" Text="<i class='fa fa-trash-o' aria-hidden='true'></i>"> </asp:LinkButton>
        <asp:Label ID="lbls2" runat="server" Text="" CssClass="text-danger"></asp:Label>

    </th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lssupplier_2" type="text" name="tb_lssupplier_2" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="row">

            <div class="col-md-8">
                <div class="form-group">

                    <asp:Label ID="lbnamefile2" runat="server" Text="Name of file" Visible="True" CssClass="text-success"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload2" runat="server" CssClass="btn btn-block btn-success" OnClick="DownloadFile2" Visible="true" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i>"> </asp:LinkButton>
                </div>
            </div>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsprice2" type="text" name="tb_lsprice2" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsdate2" type="text" name="tb_lsdate2" class="form-control input-sm" disabled/>
        </div>
    </td>

</tr>
<tr>
    <th scope="row">3</th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbsupplier3" type="text" name="tbsupplier3" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload3" runat="server" class="form-control input-sm"/>
        </div>
        <asp:Label ID="lblMessage3" runat="server"></asp:Label>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbprice3" type="text" name="price3" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbdate3" type="text" name="date3" class="form-control input-sm date"/>
        </div>
    </td>
</tr>
<tr runat="server" id="trlist3" Visible="False">
    <th scope="row" class="text-nowrap">
        <asp:LinkButton ID="lnk_del3" runat="server" CssClass="btn btn-danger" OnClick="Lsdel3" Text="<i class='fa fa-trash-o' aria-hidden='true'></i>"> </asp:LinkButton>
        <asp:Label ID="lbls3" runat="server" Text="2019/06/03" CssClass="text-danger"></asp:Label>

    </th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lssupplier_3" type="text" name="tb_lssupplier_3" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="row">

            <div class="col-md-8">
                <div class="form-group">

                    <asp:Label ID="lbnamefile3" runat="server" Text="Name of file" Visible="True" CssClass="text-success"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload3" runat="server" CssClass="btn btn-block btn-success" OnClick="DownloadFile3" Visible="true" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i>"> </asp:LinkButton>
                </div>
            </div>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsprice3" type="text" name="tb_lsprice3" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsdate3" type="text" name="tb_lsdate3" class="form-control input-sm" disabled/>
        </div>
    </td>

</tr>
<tr>
    <th scope="row">4</th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbsupplier4" type="text" name="tbsupplier4" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload4" runat="server" class="form-control input-sm"/>
        </div>
        <asp:Label ID="lblMessage4" runat="server"></asp:Label>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbprice4" type="text" name="price4" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbdate4" type="text" name="date4" class="form-control input-sm date"/>
        </div>
    </td>
</tr>
<tr runat="server" id="trlist4" Visible="False">
    <th scope="row" class="text-nowrap">
        <asp:LinkButton ID="lnk_del4" runat="server" CssClass="btn btn-danger" OnClick="Lsdel4" Text="<i class='fa fa-trash-o' aria-hidden='true'></i>"> </asp:LinkButton>
        <asp:Label ID="lbls4" runat="server" Text="2019/06/03" CssClass="text-danger"></asp:Label>

    </th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lssupplier_4" type="text" name="tb_lssupplier_4" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="row">

            <div class="col-md-8">
                <div class="form-group">

                    <asp:Label ID="lbnamefile4" runat="server" Text="Name of file" Visible="True" CssClass="text-success"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload4" runat="server" CssClass="btn btn-block btn-success" OnClick="DownloadFile4" Visible="true" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i>"> </asp:LinkButton>
                </div>
            </div>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsprice4" type="text" name="tb_lsprice4" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsdate4" type="text" name="tb_lsdate4" class="form-control input-sm" disabled/>
        </div>
    </td>

</tr>
<tr>
    <th scope="row">5</th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbsupplier5" type="text" name="tbsupplier5" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload5" runat="server" class="form-control input-sm"/>
        </div>
        <asp:Label ID="lblMessage5" runat="server"></asp:Label>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbprice5" type="text" name="price5" class="form-control input-sm"/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tbdate5" type="text" name="date5" class="form-control input-sm date"/>
        </div>
    </td>
</tr>
<tr runat="server" id="trlist5" Visible="False">
    <th scope="row" class="text-nowrap">
        <asp:LinkButton ID="lnk_del5" runat="server" CssClass="btn btn-danger" OnClick="Lsdel5" Text="<i class='fa fa-trash-o' aria-hidden='true'></i>"> </asp:LinkButton>
        <asp:Label ID="lbls5" runat="server" Text="" CssClass="text-danger"></asp:Label>

    </th>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-user-o" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lssupplier_5" type="text" name="tb_lssupplier_5" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="row">

            <div class="col-md-8">
                <div class="form-group">

                    <asp:Label ID="lbnamefile5" runat="server" Text="Name of file" Visible="True" CssClass="text-success"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload5" runat="server" CssClass="btn btn-block btn-success" OnClick="DownloadFile5" Visible="true" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i>"> </asp:LinkButton>
                </div>
            </div>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-money" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsprice5" type="text" name="tb_lsprice5" class="form-control input-sm" disabled/>
        </div>
    </td>
    <td>
        <div class="input-group">
            <span class="input-group-addon">
                <i class="fa fa-calendar" aria-hidden="true"></i>
            </span>
            <input runat="server" id="tb_lsdate5" type="text" name="tb_lsdate5" class="form-control input-sm" disabled/>
        </div>
    </td>

</tr>
</tbody>
</table>

</div>

<div class="modal-footer">
    <div class="row">
        <div class="col-md-6 text-left">
            <asp:Label ID="lbmessage_ls" runat="server" Text="" CssClass="text-success"></asp:Label>
        </div>
        <div class="col-md-6 text-right">
            <button class="btn btn-default" type="button" id="btnclose" onclick="clearMyField();">Cancel</button>
            <asp:LinkButton ID="lnkquosave" runat="server" CssClass="btn btn-primary" Text="Save"></asp:LinkButton>
        </div>
    </div>


</div>
</form>
</div>

</div>
</div>


<!-- modalworking plan -->
<div id="modalworking" class="modal">
    <div class="modal-dialog animated">

        <div class="modal-content">
            <form class="form-horizontal" method="get">
                <div class="modal-header">
                    <strong>Set Working Plan for Work Request <asp:Label ID="lbwrno_workingdate" runat="server" Text=""></asp:Label></strong>
                </div>

                <div class="modal-body">
                    <table class="table">
                        <thead class="thead-dark">
                        <tr>

                            <th scope="col" class="text-center text-danger">Start Plan Date</th>
                            <th scope="col" class="text-center text-danger">Finish Plan Date</th>

                        </tr>
                        </thead>
                        <tbody>
                        <tr>

                            <td>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar" aria-hidden="true"></i>
                                    </span>
                                    <input runat="server" id="tb_startpl_dt" type="text" name="startpl_dt" class="form-control input-sm date"/>
                                </div>
                            </td>
                            <td>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar" aria-hidden="true"></i>
                                    </span>
                                    <input runat="server" id="tb_endpl_dt" type="text" name="endpl_dt" class="form-control input-sm date"/>
                                </div>
                            </td>
                        </tr>

                        </tbody>
                    </table>
                </div>

                <div class="modal-footer">

                    <button class="btn btn-default" type="button" id="btnclose" onclick="clearMyField();">Cancel</button>
                    <asp:LinkButton ID="lnksaveworkingdate" runat="server" CssClass="btn btn-primary" Text="Save"></asp:LinkButton>
                </div>
            </form>
        </div>

    </div>
</div>

<!-- Modal Popup -->
<%--<div id="MyPopup" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body">
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>--%>
<!-- Modal Popup -->

</asp:Content>