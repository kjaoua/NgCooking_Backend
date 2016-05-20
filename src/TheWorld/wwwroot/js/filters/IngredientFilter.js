'use strict';
ngCooking.filter("caloryFilter",function(){
    return function(data,minCalory,maxCalory) {
        var Rctlist = [];

        if (data != undefined) {

            if (minCalory != undefined) {
                if (maxCalory != undefined) {

                    for (var i = 0; i < data.length; i++) {
                        if ((data[i].calories <= maxCalory) && (data[i].calories >= minCalory)) {
                            Rctlist.push(data[i]);
                        }
                    }

                }
                else {

                    for (var i = 0; i < data.length; i++) {
                        if (data[i].calories >= minCalory) {
                            Rctlist.push(data[i]);

                        }
                    }
                }
            }
            else {
                if (maxCalory != undefined) {

                    for (var i = 0; i < data.length; i++) {
                        if (data[i].calories <= maxCalory) {
                            Rctlist.push(data[i]);
                        }
                    }
                }
                else {
                    Rctlist = data;
                }
            }
        }
        return Rctlist;

    }


});
ngCooking.filter("categoryFilter",function(){
    return function(data,category,existelement){
        var Rctlist=[];
        if(data != undefined){
            for(var i = 0;i <data.length;i++){
                if((data[i].name != existelement)&&(data[i].category== category)){
                    Rctlist.push(data[i]);

                }
            }

        }

        return Rctlist;





    }
});