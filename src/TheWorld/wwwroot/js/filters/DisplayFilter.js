'use strict';
ngCooking.filter("displayFilter",function(){
    return function(data,dispNumber){
        var Rctlist=[];
        var counter =0;
        if(data != null){
            while(counter <Math.min(dispNumber,data.length) ){
                Rctlist.push(data[counter]);
                counter++;
            }

                }

        return Rctlist;





    }
});