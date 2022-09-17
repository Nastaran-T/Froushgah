function SuccessComment()
{
    $("#Name").val("");
    $("#Email").val("");
    $("#WebSite").val("");
    $("#Comment").val("");
    $("#ParentID").val("");
}

function ReplyComment(id)
{
    $("#ParentID").val(id);
    $("html, body").delay(2000).animate({ scrollTop: $('#commentProduct').offset().top }, 2000);
}