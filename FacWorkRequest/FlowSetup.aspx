<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="FlowSetup.aspx.vb" Inherits="FacWorkRequest.FlowSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="Scripts/quicksearch.js"></script>
    <style type="text/css">
    /*body { background-image: url('Images/flowsetup.jpg') no-repeat center center fixed; }*/
        body {
            -moz-background-size: cover; /* Mozilla*/
            -o-background-size: cover; /* Opera*/
            -webkit-background-size: cover; /* For WebKit*/
            background: url(Images/BG_HOME.png) no-repeat center center fixed;
            background-size: cover; /* Generic*/
        }
    </style>
    <script type="text/javascript">
        function InsertComplete() {
            bootbox.dialog({
                message: "Insert Data Complete",
                title: 'WORK REQUEST SYSTEM ONLINE',
                buttons: {
                    danger: {
                        label: 'ok',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    //txtemail.focus();
                                    //window.location.href="home.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }

        function UpdateComplete() {
            bootbox.dialog({
                message: "Update Data Complete",
                title: 'WORK REQUEST SYSTEM ONLINE',
                buttons: {
                    danger: {
                        label: 'ok',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {
                                    //txtemail.focus();
                                    //window.location.href="home.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function() {
            $('.search_textbox').each(function(i) {
                $(this).quicksearch("[id*=gvflow] tr:not(:has(th))",
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-md-8">
                <div class="wellz">
                    <h2 class="text-danger"><asp:Label ID="lbhead1" runat="server" Text="Add"></asp:Label> Flow List</h2>
                    <hr/>
                    <div class="table-responsive">
                        <asp:GridView ID="gvflow" Width="100%" CssClass="table table-bordered text-white" GridLines="None" HeaderStyle-ForeColor="White" AutoGenerateColumns="False" runat="server" OnDataBound="gvflow_DataBound" EmptyDataText="There are no data records to display.">
                            <Columns>
                                <asp:BoundField DataField="GroupID" HeaderText="GroupID" ItemStyle-CssClass="text-center"/>
                                <asp:BoundField DataField="OPID" HeaderText="OPID" ItemStyle-CssClass="text-center"/>
                                <asp:BoundField DataField="NameEng" HeaderText="Name" ItemStyle-CssClass="text-center"/>
                                <%--   <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="text-center"/>
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="text-nowarp" />
                                    <asp:BoundField DataField="SeqNo" HeaderText="#" />--%>
                                <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">

                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkupdate" CssClass="fa fa-pencil-square-o fa-lg" OnClick="GetDataGridview"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lnkdelete" CssClass="fa fa-trash fa-lg"></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <%--<asp:HyperLinkField DataTextField="Role" ItemStyle-CssClass="fa fa-pencil-square-o fa-lg" DataNavigateUrlFields="Role" DataNavigateUrlFormatString="~/FlowSetup.aspx?Role={1}"
                                                        HeaderText="Action"  />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>


            <div class="col-md-4">
                <div class="wellz">

                    <h2 class="text-danger"><asp:Label ID="lbhead2" runat="server" Text="Add"></asp:Label> Flow Setup</h2>
                    <hr/>
                    <form class="form-horizontal">

                        <%--   <div class='form-group'>
                            <label class="text-danger">FLOW TYPE</label>
                            <asp:DropDownList ID="ddlflowtype" runat="server" class="form-control input-sm">
                              <asp:ListItem Text="REQ" Value="1"></asp:ListItem>
                              <asp:ListItem Text="FAC" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>

                        <div class="form-group">
                            <label class="text-danger">GroupID</label>
                            <input id="tbreqopno" type="text" name="tbopnoreq" class="form-control input-sm" runat="server" placeholder="REQ OPNO."/>
                        </div>

                        <div class="form-group">
                            <label class="text-danger">OPID</label>
                            <input id="tbopno" type="text" name="tbopno" class="form-control input-sm" runat="server" placeholder="OPNO."/>
                        </div>

                        <%-- <div class='form-group'>
                            <label class="text-danger">NAME</label>
                            <input id="tbname" type="text" name="tbname" class="form-control input-sm" runat="server" placeholder="NAME"/>
                        </div>
                        <div class='form-group'>
                            <label class="text-danger">EMAIL</label>
                            <input id="tbemail" type="text" name="tbopno" class="form-control input-sm" runat="server" placeholder="EMAIL"/>
                        </div>--%>

                        <div class="form-group">
                            <asp:LinkButton ID="lnksave" runat="server" CssClass="btn btn-primary" OnClick="Callfunction" Text="Add"></asp:LinkButton>
                        </div>

                    </form>
                </div>
            </div>
        </div>

    </div>

</asp:Content>