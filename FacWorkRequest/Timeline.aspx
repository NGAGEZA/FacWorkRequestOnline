<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Timeline.aspx.vb" Inherits="FacWorkRequest.Timeline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        tr {
            height: 55px !important;
            max-height: 55px !important;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick"></asp:Timer>
            <div class="container-fluid">
                <h2>Work Status</h2>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="table-responsive">
                            <asp:GridView ID="gvtimeline" Width="100%" CssClass="table   table-hover " GridLines="None" HeaderStyle-CssClass="info" OnRowDataBound="OnRowDataBound" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PagerStyle-CssClass="pagination-ys text-center" PageSize="20"
                                          AutoGenerateColumns="False" runat="server" EmptyDataText="There are no data records to display.">
                                <Columns>

                                    <asp:TemplateField HeaderText="<i class='fa fa-inbox' aria-hidden='true'></i> WR. No." ItemStyle-CssClass="text-center text-nowrap " HeaderStyle-CssClass="text-center text-nowrap">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("WRNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="<i class='fa fa-list-alt' aria-hidden='true'></i> Construction Name" ItemStyle-CssClass="text-left text-nowrap" HeaderStyle-CssClass="text-left text-nowrap">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("JobName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="<i class='fa fa-building' aria-hidden='true'></i> Department" ItemStyle-CssClass="text-left text-nowrap" HeaderStyle-CssClass="text-left text-nowrap">
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Dept")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="<i class='fa fa-users' aria-hidden='true'></i> Vendor Name" ItemStyle-CssClass="text-left " HeaderStyle-CssClass="text-left text-nowrap">
                                        <ItemTemplate>

                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("SupplierName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>

                                            <i class="fa fa-spinner fa-pulse" aria-hidden="true"></i> Status:

                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm"
                                                              OnSelectedIndexChanged="StatusChanged" AutoPostBack="true"
                                                              AppendDataBoundItems="true">


                                            </asp:DropDownList>

                                        </HeaderTemplate>

                                        <ItemTemplate>

                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Status")%>'></asp:Label>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="<i class='fa fa-clock-o' aria-hidden='true'></i> Last Date" ItemStyle-CssClass="text-center text-nowrap" HeaderStyle-CssClass="text-center text-nowrap">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("UpdDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<i class='fa fa-clock-o' aria-hidden='true'></i> Seq" ItemStyle-CssClass="text-center text-nowrap" HeaderStyle-CssClass="text-center text-nowrap" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Seq")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>