$(document).ready(function() {

    var modalsetpermission = new RModal(document.getElementById("modalsetpermission"),
        {
        });


    document.getElementById("btnclose").addEventListener("click",
        function(ev) {
            ev.preventDefault();
            modalsetpermission.close();
        },
        false);


});