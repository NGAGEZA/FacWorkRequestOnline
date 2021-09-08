<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Map.aspx.vb" Inherits="FacWorkRequest.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        body { background-image: url('Images/BG_HOME.png'); }
             
    </style>


    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.rwdImageMaps.min.js"></script>

    <script >
        $(document).ready(function(e) {
            $('img[usemap]').rwdImageMaps();

            //$('area').on('click', function () {
            //   // alert($(this).attr('alt') + ' clicked');


            //});
        });
    </script>
    <script>

        function popup(url) {
            var width = 800;
            var height = 600;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            var newwin = window.open(url, 'windowname5', params);
            if (window.focus) {
                newwin.focus()
            }
            return false;
        }

    </script>

    <asp:Panel ID="Panel1" runat="server">


        <div style="line-height: 200px; text-align: center;">

            <img src="Images/Layout.jpg"" width="1024" height="768" usemap="#usemap"/>
            <%-- List ID On Master Place --%>
            <map name="usemap">
                <area alt="A" coords="174, 483, 188, 480, 190, 489, 215, 492, 215, 554, 191, 556, 194, 530, 184, 526, 176, 520, 165, 509, 165, 508, 163, 489, 176, 489"
                      href="#" shape="poly" title="A Building" onclick="popup('Chart.aspx?id=1')">
                <area alt="B" coords="248, 533, 318, 612" href="#" shape="rect" title="B Building" onclick="popup('Chart.aspx?id=2')">
                <area alt="C" coords="321, 535, 394, 614" href="#" shape="rect" title="C Building" onclick="popup('Chart.aspx?id=10')">
                <area alt="D" coords="393, 532, 501, 611" href="#" shape="rect" title="D Building" onclick="popup('Chart.aspx?id=10')">
                <area alt="E" coords="233, 424, 363, 507" href="#" shape="rect" title="E Building" onclick="popup('Chart.aspx?id=10')">
                <area alt="F" coords="381, 425, 513, 508" href="#" shape="rect" title="F Building" onclick="popup('Chart.aspx?id=13')">
                <area alt="G" coords="583, 535, 723, 614" href="#" shape="rect" title="G Building" onclick="popup('Chart.aspx?id=10')">
            </map>

        </div>


    </asp:Panel>

</asp:Content>