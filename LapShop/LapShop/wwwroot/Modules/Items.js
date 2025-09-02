﻿var ClsItems = {
    GetAll: function () {
        var self = this;
        Helper.AjaxCallGet("/Home/getallite", {}, "json",
            function (data) {

                var htmlData = "";
                console.log(data);
                for (var i = 0; i < data.length; i++) {
                    console.log(self.DrawItem(data[i])); // Use 'self'
                    htmlData += self.DrawItem(data[i]); // Use 'self'
                }
                console.log(htmlData);
                var d1 = document.getElementById('ItemArea');
                d1.innerHTML = htmlData;

            
    }, function() { });
    },
    DrawItem: function (item) {
        var data = "<div class='col-xl-3 col-6 col-grid-box'>";
        data += "<div class='product-box'><div class='img-wrapper'>";
        data += "<div class='front'> <a href='#'><img src='#' class='img-fluid blur-up lazyload bg-img' alt=''></a></div>";
        data += "<div class='back'> <a href='#'><img src='#' class='img-fluid blur-up lazyload bg-img' alt=''></a></div>";
        data += "<div class='cart-info cart-wrap'>";
        data += "<button data-toggle='modal' data-target='#addtocart' title='Add to cart'><i class='ti-shopping-cart'></i></button>";
        data += "<a href='javascript: void (0)' title='Add to Wishlist'><i class='ti-heart' aria-hidden='true'></i></a>";
        data += "<a href='#' data-toggle='modal' data-target='#quick - view' title='Quick View'><i class='ti-search' aria-hidden='true'></i></a>";
        data += "<a href='compare.html' title='Compare'><i class='ti-reload' aria-hidden='true'></i></a></div></div>";
        data += "<div class='product-detail'><div class='rating'> <i class='fa fa-star'></i> <i class='fa fa-star'></i> <i class='fa fa-star'></i>";
        data += "<i class='fa fa-star'></i> <i class='fa fa-star'></i></div>";
        data += "<a href='product-page(no - sidebar).html'><h6>" + item.ItemName + "</h6></a> <p> </p>";
        data += "<h4>$" + item.SalesPrice + "</h4>";
        data += "<ul class='color-variant'><li class='bg-light0'></li><li class='bg-light1'></li><li class='bg-light2'></li></ul> </div> </div> </div>";
   
        return data;
    }
};