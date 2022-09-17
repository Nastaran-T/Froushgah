function AddToCart(id)
{
    $.ajax({
        url: "/ShopCart/AddToCart/" + id,
        type: "Get"
    }).done(function (result) {
        $("#shopcart").html(result);

        });

    UpdateToShowCart();
}

function UpdateToShowCart()
{
    $("#showCart").load("/ShopCart/ShowCart").fadeOut(800).fadeIn(800);
}

function CommandOrder(id, count)
{
    $.ajax({
        url: "/ShopCart/CommandOrder/" + id,
        type: "get",
        data: { count: count }
    }).done(function (result)
    {
        $("#showOrder").html(result);
        });
    
}