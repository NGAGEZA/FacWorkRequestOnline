<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="FacWorkRequest.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        body { background-image: url('Images/BG_HOME.png'); }
    </style>
    <%--<link href="Content/csslogin.css" rel="stylesheet"/>--%>
    
    <!-- CSS -->
<%--    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">--%>
    <link href="assets-login/css/font-roboto.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="assets-login/bootstrap/css/bootstrap.min.css">--%>
    <link rel="stylesheet" href="assets-login/font-awesome/css/font-awesome.min.css">
    <%--<link rel="stylesheet" href="assets-login/css/form-elements.css">--%>
    <link rel="stylesheet" href="assets-login/css/style.css">
    <script type="text/javascript">
        $(function() {
            $('#login-form-link').click(function(e) {
                $("#login-form").delay(100).fadeIn(100);
                $("#register-form").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
            $('#register-form-link').click(function(e) {
                $("#register-form").delay(100).fadeIn(100);
                $("#login-form").fadeOut(100);
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });

        });
    </script>
    <script type="text/javascript">
        function LoginNotComplete() {
            bootbox.dialog({
                message:
                    "<h4 class='text-center'><i class='fa fa-times fa-3x text-danger'></i><br/>User Or Password Missing.</h4>",
                title: "<h3 class='text-center'>FAC SYSTEM ONLINE</h3>",
                buttons: {
                    danger: {
                        label: 'CLOSE',
                        className: "btn-danger",
                        callback: function() {
                            setTimeout(function() {

                                    window.location.href = "Login.aspx";
                                },
                                10);
                        }
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function() {
            $('[id*=btnlogin]').on("click",
                function() {
                    var validator = $('[id*=defaultForm]').data('bootstrapValidator');
                    validator.validate();
                    return validator.isValid();
                });
            ValidateForm();
        });

        function ValidateForm() {
            $('[id*=defaultForm]').bootstrapValidator({
                message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    opno: {
                        message: 'The username is not valid',
                        validators: {
                            notEmpty: {
                                message: 'The Operator No. is required and can\'t be empty'
                            },
                            numeric: {
                                message: 'The Operator No. must be a number'
                            },
                            stringLength: {
                                min: 6,
                                max: 6,
                                message: 'The Operator No. must be more than 6 and less than 6 characters long'
                            }
                        }
                    },
                    password: {
                        message: 'The password is not valid',
                        validators: {
                            notEmpty: {
                                message: 'The password is required'
                            },
                            blank: {}
                        }
                    }

                }
            });
        }


    </script>
    <!-- text announcement -->
    <div class="text-annoucement">
        <h1 class="text-scrolling">
            <marquee behavior="scroll" direction="left" scrollamount="12">**ติดขัดหรือมีข้อซักถาม กรุณาติดต่อผู้ดูแลงานเพื่อประสานงานการดำเนินการ ติดต่อ คุณธนโชค (เอ) 2284 ติดต่อ คุณกมลโลจน์ (โลจน์) 2158 </marquee>
        </h1>
    </div>
    <!-- /text announcement -->
            <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-7 text ">
                            <h1><strong>Facility</strong><span class="#"> Work Request System</span> </h1>
                            <div class="description">
                            	<p>
	                            	This is web site for request work online facility system. 
	                            	<%--Download it on <a href="http://azmind.com"><strong>AZMIND</strong></a>, customize and use it as you like!--%>
                            	</p>
                            </div>
                         
                        </div>
                        <div class="col-sm-5 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>Login now</h3>
                            		<p>Fill in the form below to get instant access:</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-pencil"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form role="form" action="" method="post" class="#">

			                    	<div class="form-group">
			                    		<label class="sr-only" for="opno">OPNO</label>
                                        <input type="text" name="opno" id="opno" tabindex="1" class="form-control" placeholder="Operator No" value="">
			                        </div>

			                        <div class="form-group">
			                        	<label class="sr-only" for="password">Password</label>
                                        <input type="password" name="password" id="password" tabindex="2" class="form-control" placeholder="Password">
                                  </div>
			                      
                                    <asp:LinkButton ID="btnlogin" runat="server" CssClass="btn btn-primary"  OnClick="Validatelogin" TabIndex="-1">Sign In</asp:LinkButton>
			                    </form>
		                    </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    <%--<div class="row">
        <div class="col-md-8">

        </div>
        <div class="col-md-offset-4 col-md-4">
            <div class="panel panel-login">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12 col-xs-12">
                            <form id="login-form" action="#" method="post" role="form" style="display: block;">
                                <h2>Sign in</h2>
                                <div class="form-group">
                                    <input type="text" name="opno" id="opno" tabindex="1" class="form-control" placeholder="Operator No" value="">
                                </div>
                                <div class="form-group">
                                    <input type="password" name="password" id="password" tabindex="2" class="form-control" placeholder="Password">
                                </div>
                                <div class="col-xs-6 form-group pull-left checkbox">
                                    <input id="checkbox1" type="checkbox" name="remember">
                                    <label for="checkbox1">Remember Me</label>
                                </div>
                                <div class="col-xs-6 form-group pull-right">
                                    <asp:LinkButton ID="btnlogin" runat="server" CssClass="form-control btn btn-login" OnClick="Validatelogin" TabIndex="-1">Sign In</asp:LinkButton>

                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>