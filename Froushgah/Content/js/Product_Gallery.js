function DeleteGallery(id) {
    if (confirm("آیا از حذف این مورد مطمئن هستید؟")) {
        $.get("/Admin/Products/DeleteGallery/" + id,
            function () {
                $("#Gallery_" + id).hide('slow');
            });
    }


} 