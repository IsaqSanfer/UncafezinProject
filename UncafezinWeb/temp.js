jQuery(function () {
    jQuery(".RemoveLink").on('click', function () {
        var recordToDelete = jQuery(this).attr("data-id");

        if (recordToDelete != '') {
            jQuery.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
                function (data) {
                    data.ItemCount == 0 ? jQuery('#row-' + data.DeleteId).fadeOut('slow') : jQuery('#item-count-' + data.DeleteId).text(data.ItemCount);
                    
                    jQuery('#cart-total').text(data.CartTotal);
                    jQuery('#update-message').text(data.Message);
                    jQuery('#cart-status').text('Cart (' + data.CartCount + ')');
                });
        }
    });
});

function handleUpdate() {
    var json = context.get_data();
    var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

    data.ItemCount == 0 ? jQuery('#row-' + data.DeleteId).fadeOut('slow') : jQuery('#item-count-' + data.DeleteId).text(data.ItemCount);

    jQuery('#cart-total').text(data.CartTotal);
    jQuery('#update-message').text(data.Message);
    jQuery('#cart-status').text('Cart (' + data.CartCount + ')');
}