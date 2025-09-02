var ClsItems = {
    GetAll: function () {
        var self = this;
        Helper.AjaxCallGet("/admin/Item/ajaxdata", {}, "json",
            function (data) {

                var htmlData = "";
                console.log(data);
                for (var i = 0; i < data.length; i++) {
                    htmlData += this.DrawItem(data[i]); // Use 'self'
                }
                console.log(htmlData);
                var d1 = document.getElementById('ItemArea');
                d1.innerHTML = htmlData;


            }, function () { });
    },
    DrawItem: function (item) {
        var data = `<tr>
                        <tb>${item.ItemName} </tb>
                        <tb>${item.CategoryName} </tb>
                        <tb>${item.CategoryName} </tb>
                        <tb>${item.PurchacePrice} </tb>
                      </tr>`

        return data;
    }
};
