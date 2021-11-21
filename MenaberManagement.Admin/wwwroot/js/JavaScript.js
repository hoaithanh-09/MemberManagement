
    $(document).ready(function () {
        $("#Province").change(function () {
            var id = $(this).val();
            $("#state").empty();
            $.get("GetAll", { level1_id: id }, function (data) {
                var v = "<option>---Select---</option>";
                $.each(data, function (i, v1) {
                    v += "<option value=" + v1.Value + ">" + v1.Text + "</option>";
                });
                $("#state").html(v);
            });
          
        });


        //$(document).ready(function () {
        //    $("#Province").change(function () {
        //        var id = $(this).val();
        //        $("#state").empty();
        //        $.get("State_Bind", { level1_id: id }, function (data) {
        //            var v = "<option>---Select---</option>";
        //            $.each(data, function (i, v1) {
        //                v += "<option value=" + v1.Value + ">" + v1.Text + "</option>";
        //            });
        //            $("#state").html(v);
        //        });
        //        //$.get("GetAll", function (data) {
        //        //    var v = "<option>---Select---</option>";
        //        //    $.each(data, function (i, v1) {
        //        //        v += "<option value=" + v1.Value + ">" + v1.Text + "</option>";

        //        //        // v += "<option value=" +sadasd + ">" + asdasd + "</option>";
        //        //    });
        //        //    $("#state").html(v);
        //        //});
        //    });

    $("#state").change(function () {
                var id = $(this).val();
    $("#city").empty();
    $.get("City_Bind", {state_id: id }, function (data) {
                    var v = "<option>---Select---</option>";
    $.each(data, function (i, v1) {
        v += "<option value=" + v1.Value + ">" + v1.Text + "</option>";
                    });
    $("#city").html(v);
                });
            });
    });
