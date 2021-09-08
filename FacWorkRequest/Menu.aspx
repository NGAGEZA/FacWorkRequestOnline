<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Menu.aspx.vb" Inherits="FacWorkRequest.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body { background-image: url('Images/BG_HOME.png'); }
                
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <!-- Boxes de Acoes -->
            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="WorkReq">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox1">
                            <i class="fa fa-desktop"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Work Request Entry</h3>
                            <p>
                                Entry job work request with system online.
                            </p>
                            <div class="more">
                                <a href="WorkRequest.aspx" title="Title Link">
                                    Entry Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Report">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox2">
                            <i class="fa fa-file-pdf-o"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Report Work Request</h3>
                            <p>
                                View Report job Work Request.
                            </p>
                            <div class="more">
                                <a href="MenuChart.aspx" title="Title Link">
                                    View Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>


            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Admin">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox3">
                            <i class="fa fa-list"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Admin Job List</h3>
                            <p>
                                Receive Job Update Quotation.
                            </p>
                            <div class="more">
                                <a href="AdminJoblist.aspx" title="Title Link">
                                    Go Now <i class="fa fa-angle-double-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="space"></div>
                </div>
            </div>

            <%-- <div class="col-xs-12 col-sm-6 col-lg-4" runat ="server" id="Maintenance" >
              <div class="box">							
                  <div class="icon">
                      <div class="image bgbox4"><i class="fa fa-lock"></i></div>
                      <div class="info">
                          <h3 class="title">Admin Control</h3>
                          <p>
                              Set the master data.
                          </p>
                          <div class="more">
                              <a href="FlowSetup.aspx" title="Title Link">
                                  Go Now <i class="fa fa-angle-double-right"></i>
                              </a>
                          </div>
                      </div>
                  </div>
                  <div class="space"></div>
              </div> 
          </div>--%>

            <div class="col-xs-12 col-sm-6 col-lg-4" runat="server" id="Timeline">
                <div class="box">
                    <div class="icon">
                        <div class="image bgbox4">
                            <i class="fa fa-spinner fa-pulse"></i>
                        </div>
                        <div class="info">
                            <h3 class="title">Time Line</h3>
                            <p>
                                View Timeline Work
                            </p>
                            <div class="more">
                                <a href="Timeline.aspx" title="Title Link">
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