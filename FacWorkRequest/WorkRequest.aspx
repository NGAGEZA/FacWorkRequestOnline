<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="WorkRequest.aspx.vb" Inherits="FacWorkRequest.WorkRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/quicksearch.js"></script>
    <%--<link href="Content/rmodal.css" rel="stylesheet" />--%>
    <script src="Scripts/rmodal.js"></script>
    <script type="text/javascript">
        $(function() {
            $('.search_textbox').each(function(i) {
                $(this).quicksearch("[id*=gvDetails] tr:not(:has(th))",
                    {
                        'testQuery': function(query, txt, row) {
                            return $(row).children(":eq(" + i + ")").text().toLowerCase()
                                .indexOf(query[0].toLowerCase()) !=
                                -1;
                        }
                    });
            });
        });
    </script>
    <script type="text/javascript">
        //Initialize tooltip with jQuery
        $(document).ready(function() {
            $('.tooltips').tooltip();
        });
    </script>
    <%--'confirm delete--%>
    <script type="text/javascript">
        $(document).on("click",
            ".confirmdelete",
            function(e) {
                e.preventDefault();
                var lHref = $(this).attr('href');
                bootbox.confirm({
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
    </script>

    <%--'confirm Reject--%>
    <script type="text/javascript">
        $(document).on("click",
            ".confirmreject",
            function(e) {
                e.preventDefault();
                var lHref = $(this).attr('href');
                bootbox.confirm({
                    message: "Do you want to Reject !",
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

        function test() {
            e.preventDefault();
            var lHref = $(this).attr('href');
            bootbox.confirm({
                message: "Do you want to confirm !",
                title: "<h3 class='text-center'>Information</h3>",
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
        };


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

        function BootboxContentSetpr() {
            var frmStr = '<form id="datefind">' +
                '<table class="table table-bordered">' +
                '<thead>' +
                '<tr>' +
                '<th>#</th>' +
                '<th>PRno.</th>'
                //+ '<th>Detail</th>'
                +
                '</tr>' +
                '</thead>' +
                '<tbody>' +
                '<tr>' +
                '<th scope="row">1</th>' +
                '<td><input id="tbprno1" type="text" name="tbprno1" class="form-control input-sm prno1"  placeholder="PRno."/></td>'
                //+ '<td><input id="tbprdetail1" type="text" name="tbprdetail1" class="form-control input-sm"  placeholder="Detail."/></td>'
                +
                '</tr>' +
                '<tr>' +
                '<th scope="row">2</th>' +
                '<td><input id="tbprno2" type="text" name="tbprno2" class="form-control input-sm prno1"  placeholder="PRno."/></td>'
                //+ '<td><input id="tbprdetail2" type="text" name="tbprdetail2" class="form-control input-sm"  placeholder="Detail."/></td>'
                +
                '</tr>' +
                '<tr>' +
                '<th scope="row">3</th>' +
                '<td><input id="tbprno3" type="text" name="tbprno3" class="form-control input-sm prno1"  placeholder="PRno."/></td>'
                //+ '<td><input id="tbprdetail3" type="text" name="tbprdetail3" class="form-control input-sm"  placeholder="Detail."/></td>'
                +
                '</tr>' +
                '</tr>' +
                '<tr>' +
                '<th scope="row">4</th>' +
                '<td><input id="tbprno4" type="text" name="tbprno4" class="form-control input-sm prno1"  placeholder="PRno."/></td>'
                // + '<td><input id="tbprdetail4" type="text" name="tbprdetail4" class="form-control input-sm"  placeholder="Detail."/></td>'
                +
                '</tr>' +
                '</tr>' +
                '<tr>' +
                '<th scope="row">5</th>' +
                '<td><input id="tbprno5" type="text" name="tbprno5" class="form-control input-sm prno1"  placeholder="PRno."/></td>'
                //+ '<td><input id="tbprdetail5" type="text" name="tbprdetail5" class="form-control input-sm"  placeholder="Detail."/></td>'
                +
                '</tr>' +
                '</tbody>' +
                '</table>' +
                '</form>';


            var object = $('<div/>').html(frmStr).contents();

            object.find('.prno1').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetPRDetail")%>',
                        data: "{ 'prefix': '" + request + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {

                            var items = [];
                            var map = {};
                            $.each(data.d,
                                function(i, item) {
                                    var detail = item.split('-')[1];
                                    var prno = item.split('-')[0];


                                    map[prno] = { detail: detail, prno: prno };
                                    items.push(prno);

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


            return object;


        }


//Show the datepicker in the bootbox
        $(document).on("click",
            ".finddate",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContent,
                    title: "Find Work Request Date ",
                    buttons: {
                        ok: {
                            label: "Find",
                            className: "btn-primary",
                            callback: function() {
                                debugger;
                                var date1 = document.getElementById("tbfromdate");
                                var date2 = document.getElementById("tbtodate");
                                var datefrom = date1.value;
                                var dateto = date2.value;
                                var url = "WorkRequest.aspx?dtfrm=" + datefrom + "&dtto=" + dateto;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });


        //find with wrno
        $(document).on("click",
            ".findwrno",
            function(e) {
                e.preventDefault();
                bootbox.dialog({
                    size: "small",
                    message: BootboxContentfindwrno,
                    title: "Find Work Request WRNO. ",
                    buttons: {
                        ok: {
                            label: "Find",
                            className: "btn-primary",
                            callback: function() {
                                debugger;
                                var cwrno = document.getElementById("tbwrno");

                                var wrno = cwrno.value;

                                var url = "WorkRequest.aspx?findwrno=" + wrno;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });

        //Show the datepicker in the bootbox
        $(document).on("click",
            ".forsetpr",
            function(e) {
                e.preventDefault();
                var lHref = $(this).attr('href');
                bootbox.dialog({
                    size: "small",
                    message: BootboxContentSetpr,
                    title: "Set PRNo. for work request",
                    buttons: {
                        ok: {
                            label: "Save",
                            className: "btn-success",
                            callback: function() {
                                //debugger;
                                var p1 = document.getElementById("tbprno1");
                                var p2 = document.getElementById("tbprno2");
                                var pr1 = p1.value;
                                var pr2 = p2.value;
                                var url = "WorkRequest.aspx?pr1=" + pr1 + "&pr2=" + pr2;
                                window.location.href = url;
                            }
                        }
                    }
                });
            });

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
                                    window.location.href = "WorkRequest.aspx";

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
                                    window.location.href = "WorkRequest.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }


        function RejectComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Reject Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    window.location.href = "WorkRequest.aspx";

                                },
                                10);
                        }
                    }
                }
            });
        }

        function InsertComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Insert Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {

                                    window.location.href = "WorkRequest.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }

    </script>
    <script type="text/javascript">
        function openModalsetpr() {
            var modalsetpr = new RModal(document.getElementById('modalsetpr'),
                {
                });
            modalsetpr.open();

        }

        function openModalviewquotation() {
            var modalquotation = new RModal(document.getElementById('modalviewquotation'),
                {
                });
            modalquotation.open();

        }
    </script>

    <script>
        function clearMyField() {


            window.location.href = "WorkRequest.aspx";
        }
    </script>
    <script type="text/javascript">
        //Autocomplete1
        $(function() {
            $('.prno1').typeahead({
                hint: true,
                highlight: true,
                minLength: 1,
                source: function(request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Autocomplete.aspx/GetPRDetail")%>',
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



<script src="Scripts/jquery.cookie.js"></script>
<%--<script type="text/javascript">
    $(document).ready(function () {
            $(window).bind("beforeunload", function () {
              //  return confirm("You are about to close the window");
                $.cookie("logincookie", null);
            });
        });
 </script>--%>

 
    <style type="text/css">
        .badge:hover {
            color: #ffffff;
            cursor: pointer;
            text-decoration: none;
        }

        .badge-error { background-color: #b94a48; }

        .badge-error:hover { background-color: #953b39; }

        .badge-warning { background-color: #f89406; }

        .badge-warning:hover { background-color: #c67605; }

        .badge-success { background-color: #468847; }

        .badge-success:hover { background-color: #356635; }

        .badge-info { background-color: #3a87ad; }

        .badge-info:hover { background-color: #2d6987; }

        .badge-inverse { background-color: #333333; }

        .badge-inverse:hover { background-color: #1a1a1a; }


        .ShortDesc {
            height: 50px;
            Overflow: hidden;
        }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

<div class="container">

    <%-- <div id="add_class_form" style="display:none;">
            
              <div class="form-group">
                 <label for="tbfromdate">From Date</label>
                  <input id="tbfromdate" type="text" name="tbfromdate" class="form-control input-sm date"  placeholder="From Date"/>
              </div>
              <div class="form-group">
                   <label for="tbtodate">To Date</label>
                  <input id="tbtodate" type="text" name="tbtodate" class="form-control input-sm date"  placeholder="To Date"/>
              </div>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="finddata" OnClick="Finddata">LinkButton</asp:LinkButton>
        </div>--%>
    <div class="jumbotron">
        <p class="text-danger">User Work Request Information</p>
        <%--<span class="text-info">Desktop Tablet Phone Different layout </span>--%>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label>Name:</label>
                    <label class="text-danger">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Position:</label>
                    <label class="text-danger">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Division:</label>
                    <label class="text-danger">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Department:</label>
                    <label class="text-danger">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Section:</label>
                    <label class="text-danger">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
            </div>
        </div>
        <hr/>
        <div class="row">
            <a class="btn icon-btn btn-success" href="Entry.aspx?Type=ADD"><span class="fa fa-plus text-success "></span> Add</a>
           

            <div class="btn-group">
                <button class="btn btn-info" type="button"><span class="fa fa-search text-info "></span> Find</button>
                <button data-toggle="dropdown" class="btn btn-info dropdown-toggle" type="button">
                    <span class="caret"></span>
                </button>
                <ul class="dropdown-menu">
                    <li>
                        <a href="#" class="finddate">Date</a>
                    </li>
                    <li>
                        <a href="#" class="findwrno">Work Request No.</a>
                    </li>
                  

                </ul>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="table-responsive">
                <asp:GridView ID="gvDetails" Width="100%" CssClass="table table-striped table-hover "
                              AutoGenerateColumns="False" runat="server" ondatabound="gvDetails_DataBound" EmptyDataText="There are no data records to display." OnRowDataBound="gvDetails_RowDataBound" GridLines="None" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" PagerStyle-CssClass="pagination-ys text-center" PageSize="20">
                    <Columns>

                        <asp:BoundField DataField="WRNo" HeaderText="Work Request No." HeaderStyle-CssClass="text-center text-nowrap" ItemStyle-CssClass="text-center">
<HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Job Name">
                         
                            <ItemTemplate>
                             <%--   <asp:Label ID="Label1" runat="server" Text='<%# Bind("JobName") %>'></asp:Label>--%>

                                    <asp:Label ID="Label1" CssClass="ShortDesc" Text='<%# Eval("JobName").ToString().Substring(0, Math.Min(20, Eval("JobName").ToString().Length)) %>' runat="server"></asp:Label>


                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle CssClass="text-left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="NamePlace" HeaderText="Building" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left text-nowrap">
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-left text-nowrap"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NameFloor" HeaderText="Floor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Job Detail">
                          
                            <ItemTemplate>
                               <%-- <asp:Label ID="Label2" runat="server" Text='<%# Bind("JobDetail") %>'></asp:Label>--%>
                                 <asp:Label ID="Label2" CssClass="ShortDesc" Text='<%# Eval("JobDetail").ToString().Substring(0, Math.Min(50, Eval("JobDetail").ToString().Length)) %>' runat="server"></asp:Label>
                            </ItemTemplate>


                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle CssClass="text-left" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="<i class='fa fa-cog' aria-hidden='true'></i> Action" ItemStyle-CssClass="text-left text-nowrap" HeaderStyle-CssClass="text-center text-nowrap">

                            <ItemTemplate>

                                <asp:HyperLink runat="server" ID="lnk_edit" CssClass="btn btn-primary tooltips" data-placement="top" ToolTip="Edit" NavigateUrl='<%# String.Format("~/Entry.aspx?UPD={0},{1}", Eval("WRNo"), "WorkRequest.aspx")%>' Text="<i class='fa fa-wrench' aria-hidden='true'></i> Edit"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_del" CssClass="btn btn-danger tooltips confirmdelete" data-placement="top" ToolTip="Delete" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?DEL={0}", Eval("WRNo"))%>' Text="<i class='fa fa-trash-o' aria-hidden='true'></i> Delete"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_view" CssClass="btn btn-default tooltips " data-placement="top" ToolTip="Detail" NavigateUrl='<%# String.Format("~/Entry.aspx?VEW={0},{1}", Eval("WRNo"), "WorkRequest.aspx")%>' Text="<i class='fa fa-search' aria-hidden='true'></i> View"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_rpt" CssClass="btn btn-default tooltips" data-placement="top" ToolTip="Report" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?RPT={0}", Eval("WRNo"))%>' Text="<i class='fa fa-file' aria-hidden='true'></i> Report"></asp:HyperLink>
                               
                                <asp:HyperLink runat="server" ID="lnk_reject" CssClass="btn btn-warning tooltips confirmreject" data-placement="top" ToolTip="Reject" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?REJ={0}", Eval("WRNo"))%>' Text="<i class='fa fa-reply' aria-hidden='true'></i> Reject"></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_quotation" data-placement="top" CssClass="" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?QUO={0}", Eval("WRNo"))%>' Text=""></asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnk_pr" CssClass="btn btn-primary tooltips" data-placement="top" ToolTip="PR" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?PRSET={0}", Eval("WRNo"))%>' Text="<i class='fa fa-clone' aria-hidden=tru'></i> Set PR"></asp:HyperLink>
                             
                                <asp:HyperLink runat="server" ID="lnk_app" CssClass="btn btn-success tooltips" data-placement="top" ToolTip="Approve" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?APP={0}", Eval("WRNo"))%>' Text="<i class='fa fa-check' aria-hidden=tru'></i> Approve"></asp:HyperLink>



                            </ItemTemplate>

<HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

<ItemStyle CssClass="text-left text-nowrap"></ItemStyle>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="<i class='fa fa-cog' aria-hidden='true'></i> Status" ItemStyle-CssClass=" text-left text-nowrap" HeaderStyle-CssClass="text-center text-nowrap">

                            <ItemTemplate>

                                <asp:HyperLink runat="server" ID="lnk_approve" CssClass="tooltips" data-placement="top" NavigateUrl='<%# String.Format("~/WorkRequest.aspx?APP={0}", Eval("WRNo"))%>' Text=""></asp:HyperLink>
                            
                            </ItemTemplate>

<HeaderStyle CssClass="text-center text-nowrap"></HeaderStyle>

<ItemStyle CssClass=" text-left text-nowrap"></ItemStyle>

                        </asp:TemplateField>


                    </Columns>

<PagerStyle CssClass="pagination-ys text-center"></PagerStyle>
                </asp:GridView>

             


            </div>
        </div>
    </div>

   

</div>
<!-- modalsetpr -->
<div id="modalsetpr" class="modal">
    <div class="modal-dialog animated">
        <div class="modal-content">
            <form class="form-horizontal" method="get">
                <div class="modal-header">
                    <strong>Set PR Data for Work Request <asp:Label ID="lbwrno" runat="server" Text=""></asp:Label></strong>
                </div>

                <div class="modal-body">
                    <div>
                        <table class="table table-bordered">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>PRno.</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <th scope="row">1</th>
                                <td>
                                    <input id="tbprno1" type="text" name="tbprno1" runat="server" class="form-control input-sm prno1" placeholder="PRno."/>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">2</th>
                                <td>
                                    <input id="tbprno2" type="text" name="tbprno2" runat="server" class="form-control input-sm prno1" placeholder="PRno."/>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">3</th>
                                <td>
                                    <input id="tbprno3" type="text" name="tbprno3" runat="server" class="form-control input-sm prno1" placeholder="PRno."/>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">4</th>
                                <td>
                                    <input id="tbprno4" type="text" name="tbprno4" runat="server" class="form-control input-sm prno1" placeholder="PRno."/>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">5</th>
                                <td>
                                    <input id="tbprno5" type="text" name="tbprno5" runat="server" class="form-control input-sm prno1" placeholder="PRno."/>
                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-default" type="button" id="btnclose" onclick="clearMyField();">Cancel</button>
                    <asp:LinkButton ID="lnkprsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="Savepr"></asp:LinkButton>
                </div>
            </form>
        </div>
    </div>
</div>


<!-- modalquotation -->
<div id="modalviewquotation" class="modal">
    <div class="modal-dialog animated">
        <div class="modal-content">
            <form class="form-horizontal" method="get">
                <div class="modal-header">
                    <strong>View Quotation for Work Request <asp:Label ID="lbwrno_quotation" runat="server" Text=""></asp:Label></strong>
                </div>

                <div class="modal-body">
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" EmptyDataText="No files">
                            <Columns>

                                <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                <asp:BoundField DataField="QuotationAmt" HeaderText="Amount" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                <asp:BoundField DataField="FileName" HeaderText="File Name" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                <asp:TemplateField HeaderText="<i class='fa fa-cloud-download' aria-hidden='true'></i> Download ">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("FileAttach")%>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-default" type="button" id="btnclose" onclick="clearMyField();">Close</button>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="savepr" ></asp:LinkButton>--%>
                </div>
            </form>
        </div>
    </div>
</div>


</asp:Content>