<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Report.aspx.vb" Inherits="FacWorkRequest.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        body { background-image: url('Images/BG_HOME.png'); }
             
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">

        var popUpObj;

        function NewWindow(mypage, myname, w, h, scroll) {
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings =
                'height=' +
                h +
                ',width=' +
                w +
                ',top=' +
                TopPosition +
                ',left=' +
                LeftPosition +
                ',scrollbars=' +
                scroll +
                ',resizable';
            popUpObj = window.open(mypage, myname, settings);

            popUpObj.focus();


        }


    </script>


    <div class="container">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--     <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>


        <asp:GridView ID="GridView1" runat="server" Width="881px"
                      AutoGenerateColumns="False" Font-Names="Arial"
                      Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                      HeaderStyle-BackColor="green" AllowPaging="True" ShowFooter="True"
                      Height="16px" BackColor="White" BorderColor="#3366CC"
                      BorderStyle="None" BorderWidth="1px" CellPadding="4"
                      style="font-family: Tahoma; font-size: small; text-align: center;">
            <Columns>

                <asp:TemplateField ItemStyle-Width="100px" HeaderText="WRNo">
                    <ItemTemplate>
                        <asp:Label ID="lblWRNo" runat="server"
                                   Text='<%# Eval("WRNo")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="100px" HeaderText="JobType">
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server"
                                   Text='<%# Eval("Jobtypename")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="JobName">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server"
                                   Text='<%# Eval("JobName")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Place">
                    <ItemTemplate>
                        <asp:Label ID="lblPlace" runat="server"
                                   Text='<%# Eval("Place")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Floor">
                    <ItemTemplate>
                        <asp:Label ID="lblFloor" runat="server"
                                   Text='<%# Eval("Floor")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Process">
                    <ItemTemplate>
                        <asp:Label ID="lblProcess" runat="server"
                                   Text='<%# Eval("Process")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Division">
                    <ItemTemplate>
                        <asp:Label ID="lblDivision" runat="server"
                                   Text='<%# Eval("Division")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Dept">
                    <ItemTemplate>
                        <asp:Label ID="lblDept" runat="server"
                                   Text='<%# Eval("Dept")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Section">
                    <ItemTemplate>
                        <asp:Label ID="lblSection" runat="server"
                                   Text='<%# Eval("Section")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="RequesterName">
                    <ItemTemplate>
                        <asp:Label ID="lblRequesterName" runat="server"
                                   Text='<%# Eval("RequesterName")%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="50px"/>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="30px" HeaderText="Preview">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgPV" runat="server" Height="22px" ImageUrl="Images/zoom_out.png" Width="25px"
                                         CommandArgument='<%# String.Format("{0}", Eval("WRNo"))%>'
                                         OnClick="ImageButton10_Click"/>
                    </ItemTemplate>

                    <ItemStyle Width="30px"/>
                </asp:TemplateField>


            </Columns>


            <FooterStyle BackColor="#99CCCC" ForeColor="#003399"/>
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"/>
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left"/>
            <RowStyle BackColor="White" ForeColor="#003399"/>
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"/>
            <SortedAscendingCellStyle BackColor="#EDF6F6"/>
            <SortedAscendingHeaderStyle BackColor="#0D4AC4"/>
            <SortedDescendingCellStyle BackColor="#D6DFDF"/>
            <SortedDescendingHeaderStyle BackColor="#002876"/>


        </asp:GridView>
        <br/>
        <br/>
        <br/>

        <br/>
        <br/>
        <br/>
        <br/>
        <br/>


        <%--      </asp:UpdatePanel>--%>



    </div>


</asp:Content>