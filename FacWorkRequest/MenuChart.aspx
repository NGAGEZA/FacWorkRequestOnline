<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="MenuChart.aspx.vb" Inherits="FacWorkRequest.MenuChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body { background-image: url('Images/menuchart.png'); }
                
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <!-- Boxes de Acoes -->
            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="chart1">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox1">
                            <i class="fa fa-bar-chart"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Total Monthly</h3>     
                             <p>
                               Datail Total Monthly
                            </p>                      
                            <div class="more">
                                <a href="AChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="chart2">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox2">
                            <i class="fa fa-line-chart"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Total Monthly By Group</h3>
                            <p>
                               Datail Total Monthly By Group
                            </p>
                            <div class="more">
                                <a href="BChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>


            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="chart3">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox3">
                            <i class="fa fa-pie-chart"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Quantity Job On Work</h3>
                            <p>
                               Datail Quantity Job On Work
                            </p>
                            <div class="more">
                                <a href="CChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Chart4">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox4">
                            <i class="fa fa-line-chart"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Job On Progress</h3>
                            <p>
                                Datail Job On Progress<
                            </p>
                            <div class="more">
                                <a href="DChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Chart5">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox4">
                            <i class="fa fa-file-pdf-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">ISO Report</h3>
                            <p>
                               Datail ISO Report
                            </p>
                            <div class="more">
                                <a href="EChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

              <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Div1">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox4">
                            <i class="fa fa-file-pdf-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Work Request List</h3>
                            <p>
                               Datail Work Request List
                            </p>
                            <div class="more">
                                <a href="FChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
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