function CreateNewGroup(parentId) {
    $.get("/Admin/Product_Groups/Create/"+parentId,
        function (result) {
            $("#myModal").modal();
            $("#myModalLabel").html("افزودن گروه جدید");
            $("#myModalBody").html(result);

        });
}

function EditGroup(id)
{
    $.get("/Admin/Product_Groups/Edit/"+id,
        function (result)
        {
            $("#myModal").modal();
            $("#myModalLabel").html("ویرایش گروه");
            $("#myModalBody").html(result);
        }
    );
}

function DeleteGroup(id)
{
    if (confirm("آیا از حذف این مورد مطمئن هستید؟") )
    {
        $.get("/Admin/Product_Groups/Delete/" + id,
            function () {
                $("#Group_" + id).hide('slow');
            });
    }
   
    
}


function CloseModal() {
    $("#myModal").modal("hide");
}