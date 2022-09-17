function Delete(id) {
    if (confirm("آیا از حذف این مورد مطمئن هستید؟")) {
        $.get("/Admin/Products/DeleteFeature/" + id,
            function () {
                $("#Feature_" + id).hide('slow');
            });
    }


} 