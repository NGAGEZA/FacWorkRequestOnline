<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Entry.aspx.vb" Inherits="FacWorkRequest.Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/awesome-bootstrap-checkbox.css" rel="stylesheet"/>

    <script type="text/javascript">
        //function uppercase
        function toUpperCase(ctrl) {
            $(ctrl).val($(ctrl).val().toUpperCase());

        }

        //function key only English
        function EnglishKey(evt) {
            const ew = evt.which;
            if(ew === 32)
                return true;
            if(48 <= ew && ew <= 57)
                return true;
            if(65 <= ew && ew <= 90)
                return true;
            if(97 <= ew && ew <= 122)
                return true;
            return false;
           
        }

       

        function ValidateDropDown() {
            bootbox.dialog({
                message: "Please Select Floor",
                title: 'FAC SYSTEM ONLINE',
                buttons: {
                    danger: {
                        label: 'ok',
                        className: "btn-danger",
                        callback: function() {
                            setTimeout(function() {
                                    //txtemail.focus();
                                    //window.location.href="Entry.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }


        function ValidateCookie() {
            bootbox.dialog({
                message: "Cookie Expires Please login again..",
                title: 'FAC SYSTEM ONLINE',
                buttons: {
                    danger: {
                        label: 'ok',
                        className: "btn-danger",
                        callback: function() {
                            setTimeout(function() {
                                    //txtemail.focus();
                                    window.location.href="Login.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }

        function InsertComplete_1() {
            bootbox.dialog({
                message: "Insert data complete",
                title: 'FAC SYSTEM ONLINE',
                buttons: {
                    danger: {
                        label: 'ok',
                        className: "btn-danger",
                        callback: function() {
                            setTimeout(function() {
                                    //txtemail.focus();
                                    window.location.href = "Home.aspx";
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


           function CancelComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Cancel Job Complete</h4>",
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



        function checkuploadfile() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-times fa-3x text-danger'></i><br/>Please Upload file Drawing</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'Close',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {

                                },
                                10);
                        }
                    }
                }
            });
        }


        function UpdateComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-check fa-3x text-success'></i><br/>Update Data Complete</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",

                        callback: function() {
                            //setTimeout(function() {

                            //       window.location.href = "WorkRequest.aspx";
                            //    },
                            //   10);
                        }

                    }
                }
            });
        }


        function checkjobtype() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-times fa-3x text-danger'></i><br/>Please Select Job Type.</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'OK',
                        className: "btn-success",
                        callback: function() {
                            setTimeout(function() {

                                    //window.location.href="WorkRequest.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }

        function Confirmdelete() {
            //bootbox.confirm("Are you sure?", function(result) {
            //    alert('You clicked: ' + result);
            //});
            bootbox.confirm({
                message: "This is a confirm with custom button text and color! Do you like it?",
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

                    alert('You clicked: ' + result);
                    //setTimeout(function () {

                    //    window.location.href="WorkRequest.aspx";
                    //}, 10);
                }
            });
        }

        function SetCheckBox(value) {
            $("input:checkbox[value=" + value + "]").attr("checked", true);
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

    <%-- Validate Data--%>
    <script type="text/javascript">

        $(document).ready(function() {
            $('[id*=btnSave]').on("click",
                function() {
                    var validator = $('[id*=defaultForm]').data('bootstrapValidator');
                    validator.validate();
                    return validator.isValid();
                });
            ValidateForm();
        });

        function ValidateForm() {
            //debugger;
            $('[id*=defaultForm]').bootstrapValidator({
                message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    <%=tbjobname.UniqueID%>: {
                        message: 'The Job name is empty',
                        validators: {
                            notEmpty: {
                                message: 'Job name field can\'t be empty'
                            }
                        }
                    },
                    <%=tbtel.UniqueID%>: {
                        message: 'The Telephone is empty',
                        validators: {
                            notEmpty: {
                                message: 'Telephone field can\'t be empty'
                            }
                        }
                    },
                    <%=tbquodelidate.UniqueID%>: {
                        message: 'Quotation date is empty',
                        validators: {
                            notEmpty: {
                                message: 'Quotation date field can\'t be empty'
                            },
                            date: {
                                format: 'DD/MM/YYYY'
                            }
                        }
                    },
                    <%=tbexpectdate.UniqueID%>: {
                        message: 'Expect date is empty',
                        validators: {
                            notEmpty: {
                                message: 'Expect date field can\'t be empty'
                            },
                            date: {
                                format: 'DD/MM/YYYY'
                            }
                        }
                    },
                   <%=tbdetailjob.UniqueID%>: {
                        message: 'Detail Job is empty',
                        validators: {
                            notEmpty: {
                                message: 'Detail Job field can\'t be empty'
                            }
                        }
                    }
                    <%--,
                    <%=FileUpload1.UniqueID%>: {
                        message: 'File upload is empty',
                        validators: {
                            notEmpty: {
                                message: 'Please choose file upload'
                            }
                        }
                    }--%>
                }
            });
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
        $("input[id*='tbquodelidate']").datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,
            calendarWeeks: true,
            todayBtn: "linked"
        });

        $("input[id*='tbexpectdate']").datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,
            calendarWeeks: true,
            todayBtn: "linked"
        });
    }


</script>


<div class="container well">


<div class="row">
    <div class="form-group">
        <label class="col-md-6  text-left">Jop Type / ประเภท</label>
        <label class="col-md-6  text-right">
            <asp:Label ID="lbwrno_detail" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </label>
        <div class="col-md-12">

            <div id="checkbox checkbox-success">

                <div class="checkbox checkbox-success ">
                    <input type="checkbox" id="chk_job1" name="checkboxtype[]" class="checkjob styled" value="1" clientIdMode="Static" runat="server"/>
                    <label for="chk_job1">For Operate / เพื่อดำเนินการ</label>
                </div>


                <div class="checkbox checkbox-success">
                    <input type="checkbox" id="chk_job2" name="checkboxtype[]" class="checkjob styled" value="2" clientIdMode="Static" runat="server"/>
                    <label for="chk_job2">For Repair / เพื่อซ่อม</label>
                </div>


                <div class="checkbox checkbox-success">
                    <input type="checkbox" id="chk_job3" name="checkboxtype[]" class="checkjob styled" value="3" clientIdMode="Static" runat="server"/>
                    <label for="chk_job3">For Installation / เพื่อติดตั้งใหม่/ก่อสร้าง</label>
                </div>
            </div>
        </div>
        <div>

        </div>
    </div>
</div>

<hr/>

<div class="row">

<div class="col-md-12">
    <div class="form-group">
        <label>Job Name / ชื่องาน</label>
        <input id="tbjobname" type="text" name="tbjobname" runat="server" class="form-control input-sm" onkeyup="toUpperCase(this);" onkeypress="return EnglishKey(event)" oncopy="return false" onpaste="return false"

               oncut="return false"  placeholder="Job Name / ชื่องาน"/>
        <%--<input id="tbjobtest" type="text" name="tbjobtest" class="form-control input-sm"  placeholder="Job Name / ชื่องาน"/>--%>
    </div>
</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="col-md-4">
            <div class="form-group">
                <label>Building / อาคาร</label>

                <asp:DropDownList ID="drplace" runat="server" CssClass="form-control input-sm" AutoPostBack="True" onselectedindexchanged="ddlplace_SelectedIndexChanged" placeholder="Select Building" AppendDataBoundItems="False">
                </asp:DropDownList>

            </div>
        </div>


        <div class="col-md-4">
            <div class="form-group">
                <label>Floor / ชั้น</label>
                <asp:DropDownList ID="tbfloor" runat="server" CssClass="form-control input-sm" placeholder="Floor / ชั้น" AutoPostBack="True" AppendDataBoundItems="False">
                </asp:DropDownList>

            </div>
        </div>
    </ContentTemplate>

</asp:UpdatePanel>


<div class="col-md-4">
    <div class="form-group">
        <label>Process / กระบวนการ</label>
        <input id="tbprocess" type="text" name="tbprocess" class="form-control input-sm" placeholder="Process / กระบวนการ" runat="server"/>
    </div>
</div>

<div class="col-md-4">
    <div class="form-group">
        <label>Division / หน่วยงาน</label>
        <input id="tbdivision" type="text" name="tbdivision" class="form-control input-sm" placeholder="Division / หน่วยงาน" runat="server"/>
    </div>
</div>
<div class="col-md-4">
    <div class="form-group">
        <label>Department / ฝ่าย</label>
        <input id="tbdept" type="text" name="tbdept" class="form-control input-sm" placeholder="Department / ฝ่าย" runat="server"/>
    </div>
</div>
<div class="col-md-4">
    <div class="form-group">
        <label>Section / แผนก</label>
        <input id="tbsection" type="text" name="tbsection" class="form-control input-sm" placeholder="Section / แผนก" runat="server"/>
    </div>
</div>

<div class="col-md-6">
    <div class="form-group">
        <label>Requester Name / ชื่อผู้แจ้งซ่อม</label>
        <input id="tbreqname" type="text" name="tbreqname" class="form-control input-sm" placeholder="Requester Name / ชื่อผู้แจ้งซ่อม" runat="server"/>
    </div>
</div>
<div class="col-md-6">
    <div class="form-group">
        <label>Tel. / เบอร์ติดต่อ</label>
        <input id="tbtel" type="text" name="tbtel" runat="server" class="form-control input-sm" placeholder="Tel. / เบอร์ติดต่อ"/>
    </div>
</div>

<div class="col-md-6">
    <div class="form-group">
        <label>Quo. Delivery Date / วันที่ต้องการใบเสนอราคา</label>
        <input id="tbquodelidate" type="text" name="tbquodelidate" class="form-control input-sm" runat="server" placeholder="Quo. Delivery Date / วันที่ต้องการใบเสนอราคา"/>
    </div>
</div>
<div class="col-md-6">
    <div class="form-group">
        <label>Expected Date / วันที่ต้องการงาน</label>
        <input id="tbexpectdate" type="text" name="tbexpectdate" class="form-control input-sm" runat="server" placeholder="Expected Date / วันที่ต้องการงาน"/>
    </div>
</div>


<div class="col-md-4">


    <div class="form-group">
        <label>Drawing (PDF,PNG,JPG,JPEG) <span class="text-danger h6">Size limit:5 MB :</span></label>
        <div class="input-group" id ="divupload1" runat ="server" >
            <span class="input-group-addon danger">
                <i class="fa fa-file-pdf-o text-danger" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>

          <%--  <span class="input-group-btn">

                <button runat="server" id="btnupload1" onserverclick="uploadfile_1" class="btn btn-primary" title="Upload">
                    <i class="fa fa-cloud-upload"></i> Upload
                </button>
            </span>--%>
        </div>
<%--        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ErrorMessage="* Required Field" ControlToValidate="FileUpload1">
        </asp:RequiredFieldValidator>--%>
        <asp:Label ID="lblMessage1" runat="server"></asp:Label>
    </div>

    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">

                    <h5>
                        <asp:Label ID="lbnamefile1" runat="server" Text="File Drawing" Visible="False" CssClass="text-success"></asp:Label>
                    </h5>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload1" runat="server" CssClass="btn btn-success" OnClick="DownloadFile1" Visible="False" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i> Download "> </asp:LinkButton>
                </div>
            </div>

        </div>

    </div>
</div>

<div class="col-md-4">
    <div class="form-group">
        <label>Specification (PDF,PNG,JPG,JPEG) <span class="text-danger h6">Size limit:5 MB :</span></label>
        <div class="input-group" id ="divupload2" runat ="server">
            <span class="input-group-addon danger">
                <i class="fa fa-file-pdf-o text-danger " aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control"/>

           <%-- <span class="input-group-btn">

                <button runat="server" id="btnuload2" onserverclick="uploadfile_2" class="btn btn-primary" title="Upload">
                    <i class="fa fa-cloud-upload"></i> Upload
                </button>
            </span>--%>
        </div>
        <asp:Label ID="lblMessage2" runat="server"></asp:Label>
    </div>
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <h5>
                        <asp:Label ID="lbnamefile2" runat="server" Text="File Spec" Visible="False" CssClass="text-success"></asp:Label>
                    </h5>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload2" runat="server" CssClass="btn  btn-success" OnClick="DownloadFile2" Visible="False" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i> Download "> </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="col-md-4">
    <div class="form-group">
        <label>Other (PDF,PNG,JPG,JPEG) <span class="text-danger h6">Size limit:5 MB :</span></label>
        <div class="input-group" id ="divupload3" runat ="server" >
            <span class="input-group-addon ">
                <i class="fa fa-file-pdf-o text-danger" aria-hidden="true"></i>
            </span>
            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" AllowMultiple="True"/>

            <%--<span class="input-group-btn">

                <button runat="server" id="btnuload3" onserverclick="uploadfile_3" class="btn btn-primary" title="Upload">
                    <i class="fa fa-cloud-upload"></i> Upload
                </button>
            </span>--%>
        </div>
        <asp:Label ID="lblMessage3" runat="server"></asp:Label>
    </div>
    <div class="row">
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">

                    <h5>
                        <asp:Label ID="lbnamefile3" runat="server" Text="File Other" Visible="False" CssClass="text-success"></asp:Label>
                    </h5>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:LinkButton ID="lnkdownload3" runat="server" CssClass="btn btn-success" OnClick="DownloadFile3" Visible="False" Text="<i class='fa fa-cloud-download' aria-hidden='true'></i> Download "> </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="col-md-12">
    <div class="form-group">
        <label>Detail Job / รายละเอียดงาน</label>
        <textarea id="tbdetailjob" cols="20" rows="10" class="form-control input-sm" runat="server" placeholder="Detail Job / รายละเอียดงาน"></textarea>
    </div>
</div>


<div class="row">
    <hr/>
    <div class="col-md-offset-2 col-md-8">
        <div class="form-group">
            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success btn-lg btn-block " data-style="zoom-out" OnClick="Callfunction" Text="SAVE"></asp:LinkButton>

            <asp:LinkButton ID="btnRej" runat="server" CssClass="btn btn-warning btn-lg btn-block " data-style="zoom-out" OnClick="CallfunctionCancel" Text="Cancel Job" Visible="False"></asp:LinkButton>

        </div>
    </div>
</div>


</div>
</div>


<asp:HiddenField ID="HidGroupID" runat="server"/>
<asp:HiddenField ID="HidEmailReq" runat="server"/>
<asp:HiddenField ID="HidWorkNo" runat="server"/>

</asp:Content>