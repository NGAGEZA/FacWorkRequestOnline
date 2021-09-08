<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Demo.aspx.vb" Inherits="FacWorkRequest.Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.14.0/jquery.validate.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.14.0/additional-methods.min.js"></script>

    <script type="text/javascript">
        $('[id*=defaultForm]').validate({
            rules: {
                datetimepicker: {
                    required: true,
                    date: true
                },
                commercialText: {
                    required: true,
                    minlength: 5
                },
                terms: {
                    required: true,
                    minlength: 1
                },
                'number[]': {
                    required: true,
                    minlength: 1,
                    maxlength: 1
                }
            },

            messages: {
                datetimepicker: {
                    required: "Please enter a date."
                },
                commercialText: {
                    required: "Please enter your message."
                },
                terms: {
                    required: "Please agree to terms."
                },
                'number[]': {
                    required: "Please check at least 1 option.",
                    minlength: "Please check at least {0} option."
                }
            },

            //submitHandler: function(form) {
            //    var text = $("#customtext").val();
            //    var date = $("#datetimepicker").val();
            //    var stand = 2;
            //    $.ajax({
            //        url: 'savedatanow.php',
            //        type: "POST",
            //        data: {
            //            text: text,
            //            date: date,
            //            stand: stand

            //        },
            //        dataType: 'text',
            //        success: function(response) {

            //            alert(response);
            //        }
            //    });
            //    //alert('outside ajax');
            //},

            highlight: function(element) {
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            },
            unhighlight: function(element) {
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
            },

            errorClass: 'help-block',
            errorPlacement: function(error, element) {
                if (element.parent('.form-group').length) {
                    error.insertAfter(element.parent());
                } else {
                    error.insertAfter(element.parent());
                }
                if (element.attr('name') == 'number[]') {
                    error.insertAfter('#checkboxGroup');
                } else {
                    error.appendTo(element.parent().next());
                }
            }

        });
    </script>
    <div class="container">
        <%--<form role="form" id="myform">--%>
        <div class="form-group">
            <label>what is your number?</label>
            <div class="col-lg-12">
                <div class="col-lg-6" name="number[]">
                    <div class="checkbox">
                        <label>
                            <input name="number[]" type="checkbox" value=""/>one
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input name="number[]" type="checkbox" value=""/>two
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input name="number[]" type="checkbox" value="" runat="server"/>three
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input name="number[]" type="checkbox" value="" runat="server"/>four
                        </label>
                    </div>
                </div>
                <%--<div class="col-lg-6">
          <div class="checkbox">
            <label>
              <input name="number[]" type="checkbox" value="">five</label>
          </div>
          <div class="checkbox">
            <label>
              <input name="number[]" type="checkbox" value="">six</label>
          </div>
          <div class="checkbox">
            <label>
              <input name="number[]" type="checkbox" value="">seven</label>
          </div>
          <div class="checkbox">
            <label>
              <input name="number[]" type="checkbox" value="">eight</label>
          </div>
        </div>--%>
            </div>
            <div id="checkboxGroup"></div>
        </div>
        <div class="form-group">
            <label for="datetimepicker">When do you want to go?</label>
            <input type="text" class="form-control" id="datetimepicker" name="datetimepicker"/>
        </div>
        <div class="form-group">
            <label>How long will it last?</label>
            <select class="form-control">
                <option>5 seconds</option>
                <option>10 seconds</option>
                <option>15 seconds</option>
                <option>20 seconds</option>
                <option>30 seconds</option>
            </select>
        </div>
        <div class="form-group">
            <label for="commercialText">Write a text that:</label>
            <textarea class="form-control" rows="3" id="commercialText" name="commercialText" placeholder="hello"></textarea>
        </div>
        <div class="form-group">
            <label class="checkbox-inline">
                <input type="checkbox" id="terms" name="terms">I accept the terms
            </label>
        </div>
        <button type="submit" class="btn btn-default">Submit</button>
        <%--  </form>--%>
    </div>
</asp:Content>